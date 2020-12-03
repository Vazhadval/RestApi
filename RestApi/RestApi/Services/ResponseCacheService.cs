using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace RestApi.Services
{
    public class ResponseCacheService:IResponseCacheService
    {
        private readonly IDistributedCache _distributedCache;

        public ResponseCacheService(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task CacheResponseAsync(string cacheKey, object response, TimeSpan timeToLive)
        {
            if (response==null)
            {
                return;
            }

            var serializedObject = JsonConvert.SerializeObject(response);
            await _distributedCache.SetStringAsync(cacheKey, serializedObject,new DistributedCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = timeToLive
            });
            
        }

        public async Task<string> GetCachedResponseAsync(string cacheKey)
        {
            var cachedResponse = await _distributedCache.GetStringAsync(cacheKey);
            return string.IsNullOrEmpty(cacheKey) ? null : cachedResponse;
        }
    }
}