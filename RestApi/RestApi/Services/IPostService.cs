using RestApi.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestApi.Services
{
    public interface IPostService
    {
        Task<List<Post>> GetPostsAsync();
        Task<Post> GetPostbyIdAsync(Guid postId);
        Task<bool> CreatePostAsync(Post post);
        Task<bool> UpdatePostAsync(Post postToUpdate);
        Task<bool> DeletePostAsync(Guid postId);
        Task<bool> UserOwnsPostAsyn(Guid postId, string userId);
    }
}
