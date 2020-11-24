using Microsoft.AspNetCore.Mvc;
using RestApi.Contracts;
using RestApi.Domain;
using System;
using System.Collections.Generic;

namespace RestApi.Controllers.v1
{
    public class PostsController : Controller
    {
        private List<Post> _posts;
        public PostsController()
        {
            _posts = new List<Post>();
            for (int i = 0; i < 5; i++)
            {
                _posts.Add(new Post { Id = Guid.NewGuid().ToString() });
            }
        }

        [HttpGet(ApiRoutes.Posts.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_posts);
        }
    }
}
