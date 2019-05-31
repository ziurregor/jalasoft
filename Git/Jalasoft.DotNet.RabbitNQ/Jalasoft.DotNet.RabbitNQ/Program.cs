using System;
using System.Linq;
using RabbitMQ.Client;
using System.Text;

class EmitLogTopic
{
    public static void Main(string[] args)
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            channel.ExchangeDeclare(exchange: "topic_logs",
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
                              exchange: "topic_logs", 
                              routingKey: "anonymous.#");
            channel.QueueBind(queue: "Q2",
                              exchange: "topic_logs",
                              routingKey: "anonymous.*");
            channel.QueueBind(queue: "Q3",
                              exchange: "topic_logs",
                              routingKey: "*.topic");

            var routingKey = (args.Length > 0) ? args[0] : "anonymous.info";
            var message = (args.Length > 1)
                          ? string.Join(" ", args.Skip(1).ToArray())
                          : "Hello World!";
            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(exchange: "topic_logs",
                                 routingKey: routingKey,
                                 basicProperties: null,
                                 body: body);
            Console.WriteLine(" [x] Sent '{0}':'{1}'", routingKey, message);
        }
    }
}