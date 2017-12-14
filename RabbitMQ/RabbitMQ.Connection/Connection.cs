using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using RabbitMQ.Client;

namespace RabbitMQ.Connection
{
    public class Connection
    {
        private readonly string _userName = "guest";
        private readonly string _password = "guest";
        private readonly string _hostName = "localhost";
        private readonly string _exhangeName = "";  //default  Exhange
        private readonly string _queueName;

        public readonly IModel Model;

        public Connection(string exchange,  string queue)
        {
            System.Console.WriteLine("Starting RabbitMQ Queue Creator");
            System.Console.WriteLine();

            var connectionFactory = new RabbitMQ.Client.ConnectionFactory()
            {
                Password = this._password,
                UserName = this._userName,
                HostName = this._hostName
            };

            this._exhangeName = exchange;
            this._queueName = queue;

            var connection = connectionFactory.CreateConnection();

            this.Model = connection.CreateModel();

            InitServer();
        }

        /*
         * Init the server with default queue
         */
        private void InitServer()
        {
            //durable parameter : avoid the deletion of the queue after restaring the  server.
            Model.QueueDeclare(this._queueName, true, false, false, null);
        }

        public void __destructor()
        {
            Model.QueueDelete(this._queueName);
            if (!string.IsNullOrEmpty(this._exhangeName)) Model.ExchangeDelete(this._exhangeName);
        }
    }
}
