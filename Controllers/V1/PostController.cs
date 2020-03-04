using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

       
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet(ApiRoutes.Posts.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var posts = await _postService.GetAllPost().ConfigureAwait(false);
            return Ok(posts);
        }


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet(ApiRoutes.Posts.Get)]
        public async Task<IActionResult> Get([FromRoute]string postId)
        {
            var post = await  _postService.GetPostById(postId).ConfigureAwait(false); ;

            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost(ApiRoutes.Posts.Create)]
        public IActionResult Create([FromBody] PostRequest request)
        {
            if (request == null)
            {
                throw new Exception("post request cannot be null");
            }

            if (!string.IsNullOrEmpty(request.Id))
                request.Id = Guid.NewGuid().ToString();

            var post = new Post { Id = request.Id,Name = request.Name };

            _postService.AddPost(post);

            return CreatedAtAction("Get", new { id = post.Id }, new PostResponse { Id = post.Id });
        }
    }
}