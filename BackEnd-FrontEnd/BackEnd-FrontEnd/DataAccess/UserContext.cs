using System;
using Microsoft.EntityFrameworkCore;
using Model;

namespace DataAccess
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        //public DbSet<User> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Chatuser.db");
        }
    }
}
