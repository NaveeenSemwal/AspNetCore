using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TweetBook.Contracts.V1
{
    public static partial class ApiRoutes
    {
        public const string ControllerRoute = "api/v1";

        public static class Posts
        {
            public const string GetAll = "posts";
        }
    }
}
