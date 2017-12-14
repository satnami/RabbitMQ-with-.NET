using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;

namespace RabbitMQ.ConfigurationRepo
{
    public static class Repo
    {
        public static string HostName = "localhost";
        public static string UserName = "guest";
        public static string Password = "guest";

        public static string QueueName = "Queue.sample";
        public static string ExchageName = ""; //default empty exchange

        public static bool Durable = true;

        public static string VirtualHost = "";
        public static int Port = 0;
    }
}
