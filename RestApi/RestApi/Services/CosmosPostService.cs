using Cosmonaut;
using Cosmonaut.Extensions;
using RestApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Services
{
    public class CosmosPostService : IPostService
    {
        private readonly ICosmosStore<CosmosPostDto> _cosmosStore;

        public CosmosPostService(ICosmosStore<CosmosPostDto> cosmosStore)
        {
            _cosmosStore = cosmosStore;
        }
        public async Task<bool> CreatePostAsync(Post post)
        {
            var cosmosPost = new CosmosPostDto
            {
                Id = Guid.NewGuid().ToString(),
                Name = post.Name
            };

            var response = await _cosmosStore.AddAsync(cosmosPost);
            post.Id = Guid.Parse(cosmosPost.Id);
            return response.IsSuccess;
        }

        public Task<bool> CreateTagAsync(Tag tag)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeletePostAsync(Guid postId)
        {
            var response = await _cosmosStore.RemoveByIdAsync(postId.ToString(), postId.ToString());
            return response.IsSuccess;
        }

        public Task<bool> DeleteTagAsync(string tagName)
        {
            throw new NotImplementedException();
        }

        public async Task<Post> GetPostbyIdAsync(Guid postId)
        {
            var post = await _cosmosStore.FindAsync(postId.ToString());
            if (post == null) return null;
            return new Post { Id = Guid.Parse(post.Id), Name = post.Name };
        }

        public async Task<List<Post>> GetPostsAsync()
        {
            var posts = await _cosmosStore.Query().ToListAsync();

            return posts.Select(x => new Post { Id = Guid.Parse(x.Id), Name = x.Name }).ToList();
        }

        public Task<Tag> GetTagByNameAsync(string tagName)
        {
            throw new NotImplementedException();
        }

        public Task<List<Tag>> GetTagsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdatePostAsync(Post postToUpdate)
        {
            var cosmosPost = new CosmosPostDto
            {
                Id = postToUpdate.Id.ToString(),
                Name = postToUpdate.Name
            };

            var response = await _cosmosStore.UpdateAsync(cosmosPost);
            return response.IsSuccess;
        }

        public Task<bool> UserOwnsPostAsyn(Guid postId, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
