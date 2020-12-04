using Newtonsoft.Json;
using RestApi.External.Contracts;
using RestApi.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RestApi.Services
{
    public class FacebookAuthService : IFacebookAuthService
    {
        private const string TokenValidationUrl = "https://graph.facebook.com/debug_token?input_token={0}&access_token={1}|{2}";
        private const string UserInfoUrl = "https://graph.facebook.com/me?fields=first_name,last_name,picture,email&access_token={0}";
        private readonly FaceBookAuthSettings _faceBookAuthSettings;
        private readonly IHttpClientFactory _httpClientFactory;
        public FacebookAuthService(FaceBookAuthSettings faceBookAuthSettings, IHttpClientFactory httpClientFactory)
        {
            _faceBookAuthSettings = faceBookAuthSettings;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<FacebookUserInfoResult> GetUserInfoAsync(string accessToken)
        {
            var formatedUrl = string.Format(UserInfoUrl, accessToken);

            var result = await _httpClientFactory.CreateClient().GetAsync(formatedUrl);
            result.EnsureSuccessStatusCode();

            var responseAsString = await result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<FacebookUserInfoResult>(responseAsString);
        }

        public async Task<FacebookTokenValidationResult> ValidateAccessTokenAsync(string accessToken)
        {
            var formatedUrl = string.Format(TokenValidationUrl, accessToken, _faceBookAuthSettings.AppId, _faceBookAuthSettings.AppSecret);

            var result = await _httpClientFactory.CreateClient().GetAsync(formatedUrl);
            result.EnsureSuccessStatusCode();

            var responseAsString = await result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<FacebookTokenValidationResult>(responseAsString);
        }
    }
}
