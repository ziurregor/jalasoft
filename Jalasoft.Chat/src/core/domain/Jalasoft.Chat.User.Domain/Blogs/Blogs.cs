using System;
using System.Collections.Generic;

namespace Jalasoft.Chat.User.Domain.Blogs
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
