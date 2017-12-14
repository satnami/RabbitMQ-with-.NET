using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RabbitMQ.Client
{
    class Sender :IDisposable
    {
        private ConnectionFactory _connectionFactory;
        private IConnection _connection;
        private IModel _model;

        public Sender()
        {
            BuildSettings();
            SetupRabbitMQ();
        }




        


        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
