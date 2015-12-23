using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using RabbitMQ.Client;

namespace RabbitMQ.Console
{
    class Program
    {
        private const string UserName = "guest";
        private const string Password = "guest";
        private const string HostName = "localhost";

        static void Main(string[] args)
        {

            System.Console.WriteLine("Starting RabbitMQ Queue Creator");
            System.Console.WriteLine();

            var connectionFactory = new RabbitMQ.Client.ConnectionFactory()
            {
                Password = Password,
                UserName = UserName ,
                HostName = HostName
            };

            var connection = connectionFactory.CreateConnection();

            var model = connection.CreateModel();

            model.QueueDeclare("SQueue", true, false, false, null);
            System.Console.WriteLine("Queue Created");

            model.ExchangeDeclare("SExchange", ExchangeType.Fanout);
            System.Console.WriteLine("Exchange Created");

            model.QueueBind("SQueue", "SExchange", "sroute");


            while (System.Console.ReadLine() != "q") { }
            InitServer(model, "SQueue", "SExchange");


           }

        private static void InitServer(IModel model, string queue, string exchange)
        {
            model.QueueDelete(queue;
            model.ExchangeDelete(exchange);
        }
    }
}
