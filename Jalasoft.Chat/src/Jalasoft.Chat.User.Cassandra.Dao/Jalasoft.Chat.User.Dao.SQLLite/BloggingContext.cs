using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Jalasoft.Chat.User.Domain.Users;
using Jalasoft.Chat.User.Domain.Blogs;

namespace Jalasoft.Chat.User.Dao.SQLLite
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blobs> Blogs { get; set; }
        public DbSet<Posts> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=/Users/rogerruizescobar/Projects/BackEnd/ConsoleApp.SQlite/blogging.db");
        }
    }
}
