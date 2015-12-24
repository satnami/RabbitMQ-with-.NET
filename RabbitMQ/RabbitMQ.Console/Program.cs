using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using RabbitMQ.Client;

using RabbitMQConnection = RabbitMQ.Connection.Connection;
namespace RabbitMQ.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var exhangeName = "";  //default  Exhange
            var queueName = "Queue.ex";

            RabbitMQConnection connection = new RabbitMQConnection(exhangeName, queueName);
            var properties = connection.Model.CreateBasicProperties();
            //property to add persistent to the messages.
            properties.Persistent = true;

            //serialize the message
            byte[] msgBuffer = Encoding.Default.GetBytes("Hello world");

            connection.Model.BasicPublish(exhangeName, queueName, properties, msgBuffer);

            System.Console.Write("Message Sent!");

            while (System.Console.ReadLine() != "q") { }
            connection.__destructor();

            System.Environment.Exit(-1);
        }
    }
}
