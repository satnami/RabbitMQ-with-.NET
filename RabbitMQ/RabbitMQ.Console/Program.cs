using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RabbitMQ.Console
{
    class Program
    {
        private const string UserName = "guest";
        private const string Password = "guest";
        private const string HostName = "localhost";

        static void Main(string[] args)
        {
            var connectionFactory = new RabbitMQ.Client.ConnectionFactory()
            {
                Password = Password,
                UserName = UserName ,
                HostName = HostName
            };

            var connection = connectionFactory.CreateConnection();

            var model = connection.CreateModel();

            model.
        }
    }
}
