using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TweetBook.Contracts.V1;
using TweetBook.Contracts.V1.Request;
using TweetBook.Contracts.V1.Response;
using TweetBook.Domain;
using TweetBook.Services.Abstract;

namespace TweetBook.Controllers.V1
{
    [Route(ApiRoutes.ControllerRoute)]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet(ApiRoutes.Posts.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_postService.GetAllPost());
        }

        [HttpGet(ApiRoutes.Posts.Get)]
        public IActionResult Get([FromRoute]string postId)
        {
            var post = _postService.GetPostById(postId);

            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }


        [HttpPost(ApiRoutes.Posts.Create)]
        public IActionResult Create([FromBody] PostRequest request)
        {
            if (request == null)
            {
                throw new Exception("post request cannot be null");
            }

            if (!string.IsNullOrEmpty(request.Id))
                request.Id = Guid.NewGuid().ToString();

            var post = new Post { Id = request.Id };

            _postService.AddPost(post);

            return CreatedAtAction("Get", new { id = post.Id }, new PostResponse { Id = post.Id });
        }
    }
}