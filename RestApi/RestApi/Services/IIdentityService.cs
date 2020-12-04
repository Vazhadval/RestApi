﻿
using RestApi.Domain;
using System.Threading.Tasks;

namespace RestApi.Services
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> RegisterAsync(string email, string password);
        Task<AuthenticationResult> LoginAsync(string email, string password);
        Task<AuthenticationResult> RefreshTokenAsync(string token, string refreshToken);
        Task<AuthenticationResult> LoginWithFacebookAsync(string accessToken);
    }
}
