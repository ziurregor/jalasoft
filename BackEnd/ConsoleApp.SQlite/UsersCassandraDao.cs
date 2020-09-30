using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cassandra;
using Cassandra.Mapping;
using Newtonsoft.Json.Linq;

namespace ConsoleApp.SQlite
{
    class UsersCassandraDao
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello Cassandra!");
            //BlogPostExample example = new

            //var cluster = Cluster.Builder()
            //                     .AddContactPoints("localhost")
            //                     .WithPort(9042)
            //                     .WithLoadBalancingPolicy(new DCAwareRoundRobinPolicy("AWS_VPC_AP_SOUTHEAST_2"))
            //                     .WithAuthProvider(new PlainTextAuthProvider(< Username >, < Password >))
            //                     .Build();

            //// Connect to the nodes using a keyspace
            //var session = cluster.Connect("system_distributed");
            //IMapper mapper = new Mapper(session);
            Builder cassandraBuilder = Cluster.Builder();
            cassandraBuilder.AddContactPoint("127.0.0.1");

            var cluster = cassandraBuilder.Build();

            ISession session = cluster.Connect("eva");

            //RowSet rowSet = session.Execute("select * from employees");

            //foreach (var row in rowSet)
            //{
            //    Console.WriteLine(row[0]);
            //}


            IMapper mapper = new Mapper(session);


            session.UserDefinedTypes.Define(
               UdtMap.For<names>()
                  //.Automap()
                  //.Map(a => a.firstName , "firstName")
                  //.Map(a => a.lastName, "lastName")
            );

            MappingConfiguration.Global.Define(
            new Map<User>()
            .TableName("users")
            .PartitionKey(u => u.UserId)
            .Column(u => u.UserId, cm => cm.WithName("UserId")));


            //MappingConfiguration.Global.Define<MyMappings>();

            IEnumerable<User> users = mapper.Fetch<User>("SELECT userid, name FROM users");

            //IEnumerable<User> users = mapper.Fetch<User>();
            Console.WriteLine("datos");
            foreach (var user in users)
            {
                //Console.WriteLine(  user.Name);

                foreach (var names in user.Name)
                {
                    Console.WriteLine(names.firstName+" "+names.lastName);
                }
            }

            var newUser = new User();
            Console.WriteLine("Itroducir datos de usuaio ");
            newUser.UserId = Guid.NewGuid();
            var newName = new names();
            newName.firstName = "Darcy";
            newName.lastName = "Ruiz";

            List<names> Names = new List<names>();

            Names.Add(newName);

            if (Names != null)
            {
                newUser.Name = Names;
              
            }

            //newUser.Name.f= Console.ReadLine();
            mapper.Insert(newUser);


        }
        public class MyMappings : Mappings
        {
            public MyMappings()
            {
                // Define mappings in the constructor of your class
                // that inherits from Mappings
                For<User>()
                   .TableName("users")
                   .PartitionKey(u => u.UserId)
                   .Column(u => u.UserId, cm => cm.WithName("id"));
                //For<Comment>()
                   //.TableName("comments");
            }
        }

        public class User
        {
        
            public Guid UserId { get; set; }
            public IEnumerable<names> Name { get; set; }
        }
        public class names
        { 
            public string firstName { get; set; }
            public string lastName { get; set; }
        }

    }
}
