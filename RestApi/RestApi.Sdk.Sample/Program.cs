using Refit;
using RestApi.Contracts.v1.Requests;
using System;
using System.Threading.Tasks;

namespace RestApi.Sdk.Sample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var cachedToken = string.Empty;

            var identityApi = RestService.For<IIdentityApi>("https://localhost:5001/");
            var postsApi = RestService.For<IPostApi>("https://localhost:5001/", new RefitSettings
            {
                AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
            });

            var registerResponse = await identityApi.RegisterAsync(new UserRegistrationRequest
            {
                Email = "from3@sdk.com",
                Password = "Test123!"
            });

            var loginResponse = await identityApi.LoginAsync(new UserLoginRequest
            {
                Email = "from3@sdk.com",
                Password = "Test123!"
            });

            cachedToken = loginResponse.Content.Token;

            var allPosts = await postsApi.GetAllAsync();

            var createdPost = await postsApi.CreateAsync(new CreatePostRequest
            {
                Name = "this is created by the sdk",
                Tags = new[] { "sdk" }
            });

            var retreivedPost = await postsApi.GetAsync(createdPost.Content.Id);

            var updatedPost = await postsApi.UpdateAsync(createdPost.Content.Id, new UpdatePostRequest
            {
                Name = "this is updated by sdk"

            });

            var deletePost = await postsApi.DeleteAsync(createdPost.Content.Id);
        }
    }
}
