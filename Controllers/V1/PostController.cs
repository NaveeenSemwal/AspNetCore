using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TweetBook.Contracts.V1;
using TweetBook.Domain.V1;

namespace TweetBook.Controllers.V1
{
    [Route(ApiRoutes.ControllerRoute)]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly List<Post> _posts;

        public PostController()
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