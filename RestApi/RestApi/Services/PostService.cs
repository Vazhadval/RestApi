using Microsoft.EntityFrameworkCore;
using RestApi.Data;
using RestApi.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestApi.Services
{
    public class PostService : IPostService
    {
        private readonly DataContext _dataContext;

        public PostService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<List<Post>> GetPostsAsync()
        {
            return await _dataContext.Posts.Include(x => x.Tags).ToListAsync();
        }

        public async Task<Post> GetPostbyIdAsync(Guid postId)
        {
            return await _dataContext.Posts.SingleOrDefaultAsync(x => x.Id == postId);
        }

        public async Task<bool> CreatePostAsync(Post post)
        {
            await _dataContext.Posts.AddAsync(post);
            int created = await _dataContext.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> UpdatePostAsync(Post postToUpdate)
        {
            _dataContext.Posts.Update(postToUpdate);
            int updated = await _dataContext.SaveChangesAsync();
            return updated > 0;
        }

        public async Task<bool> DeletePostAsync(Guid postId)
        {
            var post = await GetPostbyIdAsync(postId);
            if (post == null)
            {
                return false;
            }

            _dataContext.Posts.Remove(post);
            int deleted = await _dataContext.SaveChangesAsync();
            return deleted > 0;
        }

        public async Task<bool> UserOwnsPostAsyn(Guid postId, string userId)
        {
            var post = await _dataContext.Posts.AsNoTracking().SingleOrDefaultAsync(x => x.Id == postId);
            if (post == null) return false;

            return post.UserId == userId;
        }

        public async Task<List<Tag>> GetTagsAsync()
        {
            return await _dataContext.Tags.ToListAsync();
        }

        public async Task<bool> CreateTagAsync(Tag tag)
        {
            await _dataContext.Tags.AddAsync(tag);
            int created = await _dataContext.SaveChangesAsync();
            return created > 0;
        }

        public async Task<Tag> GetTagByNameAsync(string tagName)
        {
            return await _dataContext.Tags.FirstOrDefaultAsync(x => x.Name == tagName);
        }

        public async Task<bool> DeleteTagAsync(string tagName)
        {
            var tag = await GetTagByNameAsync(tagName);
            if (tag == null)
            {
                return false;
            }

            _dataContext.Tags.Remove(tag);
            int deleted = await _dataContext.SaveChangesAsync();
            return deleted > 0;
        }
    }
}
