using RestApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Services
{
    public class PostService : IPostService
    {
        private readonly List<Post> _posts;
        public PostService()
        {
            _posts = new List<Post>();
            for (int i = 0; i < 5; i++)
            {
                _posts.Add(new Post
                {
                    Id = Guid.NewGuid(),
                    Name = $"Post Name {i}"
                });
            }
        }

        public bool DeletePost(Guid postId)
        {
            var post = GetPostbyId(postId);

            if (post == null)
            {
                return false;
            }
            _posts.Remove(post);
            return true;
        }

        public Post GetPostbyId(Guid postId)
        {
            return _posts.SingleOrDefault(x => x.Id == postId);
        }

        public List<Post> GetPosts()
        {
            return _posts;
        }

        public bool UpdatePost(Post postToUpdate)
        {
            var exists = GetPostbyId(postToUpdate.Id) != null;
            if (!exists) return false;

            var index = _posts.FindIndex(x => x.Id == postToUpdate.Id);
            _posts[index] = postToUpdate;
            return true;

        }
    }
}
