using RestApi.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestApi.Services
{
    public interface IPostService
    {
        Task<List<Post>> GetPostsAsync(GetAllPostsFilter filter = null, PaginationFilter paginationFilter = null);
        Task<Post> GetPostbyIdAsync(Guid postId);
        Task<bool> CreatePostAsync(Post post);
        Task<bool> UpdatePostAsync(Post postToUpdate);
        Task<bool> DeletePostAsync(Guid postId);
        Task<bool> UserOwnsPostAsyn(Guid postId, string userId);
        Task<List<Tag>> GetTagsAsync();
        Task<bool> CreateTagAsync(Tag tag);
        Task<Tag> GetTagByNameAsync(string tagName);
        Task<bool> DeleteTagAsync(string tagName);
    }
}
