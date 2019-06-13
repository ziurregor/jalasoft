using System;
using DataAccess;
using Model;

namespace Jalasoft.Chat.Users.Busines
{
    public class Program
    {
        public static void Main()
        {
            using (var db = new UserContext())
            {
                db.Users.Add(new User { Name = "Roger.Ruiz@jalasoft.org", IsActive = true });
                var count = db.SaveChanges();
                Console.WriteLine("{0} records saved to database", count);

                Console.WriteLine();
                Console.WriteLine("All User in database:");
                foreach (var blog in db.Users)
                {
                    Console.WriteLine(" - {0}", blog.Name);
                }
            }
        }
    }
}
