﻿using System;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
<<<<<<< HEAD
using Newtonsoft.Json;
using System.Threading.Tasks;

=======
using Newtonsoft.Json;

>>>>>>> 60c8fc4a856d468b344c8909e0cc2c9fd2e0f558
class ReceiveLogsTopic
{
    public static void Main(string[] args)
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            channel.ExchangeDeclare(exchange: "topic_logs", type: "topic");
            var queueName = (args.Length > 0) ? args[0] : "Q1";
            //var queueName = channel.QueueDeclare().QueueName;

            if (args.Length < 1)
            {
                Console.Error.WriteLine("Usage: {0} [binding_key...]",
                                        Environment.GetCommandLineArgs()[0]);
                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
                Environment.ExitCode = 1;
                return;
            }

            foreach (var bindingKey in args)
            {
                channel.QueueBind(queue: queueName,
                                  exchange: "topic_logs",
                                  routingKey: bindingKey);
            }

            Console.WriteLine(" [*] Waiting for messages. To exit press CTRL+C");

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                var message = JsonConvert.DeserializeObject(Encoding.UTF8.GetString(body));

                var routingKey = ea.RoutingKey;
                Console.WriteLine(" [x] Received '{0}':'{1}'",
                                  routingKey,
                                  message.ToString());
                Task.Delay(50);
                channel.BasicAck(ea.DeliveryTag,true);


            };

            channel.BasicConsume(queue: queueName,
                                 autoAck: false,
                                 consumer: consumer);
            //channel.BasicAck()
            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}

