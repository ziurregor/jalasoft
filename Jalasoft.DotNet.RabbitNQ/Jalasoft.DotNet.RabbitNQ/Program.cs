using System;
using System.Linq;
using RabbitMQ.Client;
using System.Text;
using Jalasoft.DotNet.RabbitNQ.Model;
using Newtonsoft.Json;

class EmitLogTopic
{
    public static void Main(string[] args)
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            char option;
            string exch;
            string routingKey;
            string queue;
            var message = new Product();
            message.ProductName = "TV 14'";
            message.Group = "Electronic";
            message.Price = 100;
            do
            {

            
            Console.WriteLine("[E] Add Exchange:");
            Console.WriteLine("[R] Add routingKey to a Queue:");
            Console.WriteLine("[Q] Add Queue:");
            Console.WriteLine("[S] Send Message:");
            Console.WriteLine("[X] Exit:");
                option = Convert.ToChar( Console.ReadLine());

                switch (option)
                {
                    case 'E':
                        Console.WriteLine("Exchange?");
                        exch = Console.ReadLine();
                        channel.ExchangeDeclare(exchange: exch,
                                    type: "topic");
                        break;
                    case 'R':
                        Console.WriteLine("Queue?");
                        queue = Console.ReadLine();
                        Console.WriteLine("Exchange?");
                        exch = Console.ReadLine();
                        Console.WriteLine("RoutingKey?");
                        routingKey = Console.ReadLine();

                        channel.QueueBind(queue: queue,
                        exchange: exch,
                        routingKey: routingKey);
                        break;
                    case 'Q':
                        Console.WriteLine("Queue?");
                        queue = Console.ReadLine();
                        channel.QueueDeclare(queue: queue,
                                durable: true,
                                exclusive: false,
                                autoDelete: false
                               );
                        break;
                    case 'S':
                        var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
                        Console.WriteLine("Exchange?");
                        exch = Console.ReadLine();
                        Console.WriteLine("RoutingKey?");
                        routingKey = Console.ReadLine();

                        channel.BasicPublish(exchange: exch,
                                             routingKey: routingKey,
                                             basicProperties: null,
                                             body: body);
                        Console.WriteLine(" [x] Sent '{0}':'{1}'", routingKey, message);
                        break;
                    default:
                        Console.Clear();
                        break;
                }

            } while (option!='X');



            //var routingKey = (args.Length > 0) ? args[0] : "Oriente.Beni.New.Electrodomestics";

        

            
        }
    }
}