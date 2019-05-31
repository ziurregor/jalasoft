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


            channel.ExchangeDeclare(exchange: "E1",
                                    type: "topic");
            channel.ExchangeDeclare(exchange: "E2",
                                    type: "topic");


            channel.QueueDeclare(queue: "Q1", 
                                 durable: true, 
                                 exclusive: false, 
                                 autoDelete: false
                                );
            channel.QueueDeclare(queue: "Q2",
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false
                                );
            channel.QueueDeclare(queue: "Q3",
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false
                                );
            channel.QueueBind(queue: "Q1", 
                              exchange: "E1", 
                              routingKey: "*.Beni.*.Electrodomestics");
            channel.QueueBind(queue: "Q2",
                              exchange: "E2",
                              routingKey: "Oriente.Beni.New.#");
            channel.QueueBind(queue: "Q3",
                              exchange: "E1",
                              routingKey: "Oriente.*.*.Electrodomestics");

            var routingKey = (args.Length > 0) ? args[0] : "Oriente.Beni.New";

            //var message = (args.Length > 1)
                          //? string.Join(" ", args.Skip(1).ToArray())
                          //: "Hello World!";

            var message = new Product();
            message.ProductName = "TV 14'";
            message.Group = "Electronic";
            message.Price = 100;

            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
            channel.BasicPublish(exchange: "E1",
                                 routingKey: routingKey,
                                 basicProperties: null,
                                 body: body);
            channel.BasicPublish(exchange: "E2",
                                 routingKey: routingKey,
                                 basicProperties: null,
                                 body: body);
            Console.WriteLine(" [x] Sent '{0}':'{1}'", routingKey, message);
        }
    }
}