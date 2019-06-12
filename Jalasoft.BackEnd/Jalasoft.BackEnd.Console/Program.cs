namespace Jalasoft.BackEnd.Console
{
    using Dapper;
    using Jalasoft.BackEnd.Dao.SqlLite;
    using Jalasoft.BackEnd.Model;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data.SQLite;
    using System.IO;
    using System.Linq;

    class Program
    {
        public static void Main()
        {
            //using (var db = new EntityFrameworkSQLite())
            //{
            //    ICollection<ChatMessage> messages = new Collection<ChatMessage>();
            //    var message = new ChatMessage();
            //    message.id = 1;
            //    message.idUser = 1;
            //    message.message = "HI";
            //    messages.Add(message);
            //    message.id = 2;
            //    message.idUser = 1;
            //    message.message = "How r u";

            //    messages.Add(message);
            //    db.User.Add(new ChatUser { id = 2, email = "rruiz_1@hotmail.com", messages = messages });

            //    var count = db.SaveChanges();

            //    Console.WriteLine("{0} records saved to database", count);

            //    Console.WriteLine();
            //    Console.WriteLine("All blogs in database:");
            //    foreach (var blog in db.User)
            //    {
            //        Console.WriteLine(" - {0}", blog.email);
            //    }
            //}
            try
            {
                using (var db = new SQLiteConnection(@"Data Source=C:\Jalasoft\Git\jalasoft\BackEnd-Orlando\Jalasoft.BackEnd\Jalasoft.BackEnd.Console\bin\Debug\netcoreapp2.2\Chat.db"))
                {
                    if (!File.Exists(@"Data Source=C:\Jalasoft\Git\jalasoft\BackEnd-Orlando\Jalasoft.BackEnd\Jalasoft.BackEnd.Console\bin\Debug\netcoreapp2.2\Chat.db"))
                    {
                        CreateDatabase();
                    }
                    db.Open();
                    ChatUser chatUser = new ChatUser();
                    chatUser.id = 7;
                    chatUser.email = "Roger Ruiz";

                    var a = db.Query<int>(
                            @"INSERT INTO User (email) VALUES (@email );
                ", chatUser);

                    Console.WriteLine("el dato insertado es" + a.ToString());

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        private static void CreateDatabase()
        {
            //using (var cnn = new SQLiteConnection(@"Data Source=C:\Jalasoft\Git\jalasoft\BackEnd-Orlando\Jalasoft.BackEnd\Jalasoft.BackEnd.Console\bin\Debug\netcoreapp2.2\Chat.db")
            //{
            //  //  cnn.Open();
            //  //  cnn.Execute(
            //  //      @"create table Customer
            //  //(
            //  //   ID                                  integer identity primary key AUTOINCREMENT,
            //  //   FirstName                           varchar(100) not null,
            //  //   LastName                            varchar(100) not null,
            //  //   DateOfBirth                         datetime not null
            //  //)");
            //}
        }


    }
}
