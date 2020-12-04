using RestApi.External.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Services
{
    public interface IFacebookAuthService
    {
        Task<FacebookTokenValidationResult> ValidateAccessTokenAsync(string accessToken);
        Task<FacebookUserInfoResult> GetUserInfoAsync(string accessToken);
    }
}
