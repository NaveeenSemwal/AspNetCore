using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweetBook.Domain;
using TweetBook.Services.Abstract;

namespace TweetBook.Services.Implementation
{
    public class PostService : IPostService
    {
        private readonly List<Post> _posts;
        public PostService()
        {
            _posts = new List<Post>();

            for (int i = 0; i < 5; i++)
            {
                _posts.Add(new Post { Id = Guid.NewGuid().ToString(), Name = $"Post name {i}" });
            }
        }

        public void AddPost(Post post)
        {
            _posts.Add(post);
        }

        public IList<Post> GetAllPost()
        {
            return _posts;
        }

        public Post GetPostById(string postId)
        {
            return _posts.SingleOrDefault(x => x.Id == postId);
        }
    }
}
