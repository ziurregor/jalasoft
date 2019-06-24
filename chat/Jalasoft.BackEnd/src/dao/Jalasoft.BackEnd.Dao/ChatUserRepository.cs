using System;
using System.Collections.Generic;
using System.Linq;
using Jalasoft.BackEnd.Dao.SqlLite;
using Jalasoft.BackEnd.Model;
using Microsoft.EntityFrameworkCore;


namespace Jalasoft.BackEnd.Dao
{
    public class ChatUserRepository<chatUser> : DbContext//, IChatUserRepository<T>
    {
        public DbSet<chatUser> User { get; set; }
        public DbSet<ChatMessage> Message { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=C:\Jalasoft\Git\jalasoft\BackEnd-Orlando\Jalasoft.BackEnd\Jalasoft.BackEnd.Console\bin\Debug\netcoreapp2.2\Chat.db");
        }

        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(T entity)
        {
            throw new NotImplementedException();
        }

        public List<chatUser> GetAll()
        {
            using (var db = new EntityFrameworkSQLite())
            {
                var a =  db.User.ToList() as List<chatUser>;
                return a;
            }

            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}