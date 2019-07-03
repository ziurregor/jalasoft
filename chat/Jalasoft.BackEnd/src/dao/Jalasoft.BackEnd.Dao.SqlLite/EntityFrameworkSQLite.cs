namespace Jalasoft.BackEnd.Dao.SqlLite
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using Jalasoft.BackEnd.Model;

    public class EntityFrameworkSQLite : DbContext
    {
        public DbSet<ChatUser> User { get; set; }
        public DbSet<ChatMessage> Message { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=C:\Jalasoft\Git\jalasoft\BackEnd-Orlando\Jalasoft.BackEnd\Jalasoft.BackEnd.Console\bin\Debug\netcoreapp2.2\Chat.db");
        }

    }
}
