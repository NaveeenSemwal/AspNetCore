using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweetBook.Domain;

namespace TweetBook.Services.Abstract
{
    public interface IPostService
    {
        IList<Post> GetAllPost();

        Post GetPostById(string postId);

        void AddPost(Post post);
    }
}
