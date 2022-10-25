using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client;

namespace MailServerProject
{
    public class RMQLogicEngine
    {
        private IConnection _connection;
        private IModel _channel;

        public RMQLogicEngine()
        {
            kanalOlustur();
        }

        ~RMQLogicEngine()
        {
            _channel.Dispose();
            _connection.Dispose();
        }

        public static RMQLogicEngine CreateNewObject() => new RMQLogicEngine();
        public void StartQueueMessageProcessor()
        {
            MessageProcessor mesajIsleyen = new MessageProcessor(_channel);
            _channel.BasicConsume("demoqueue", false, mesajIsleyen);
        }
        private void kanalOlustur()
        {
            _connection = GetConnectionInfo().CreateConnection();
            _channel = _connection.CreateModel();
            _channel.BasicQos(0, 1, false);
        }
        private ConnectionFactory GetConnectionInfo()
        {
            ConnectionFactory connectionFactory = new ConnectionFactory
            {

                HostName = "localhost",
                UserName = "rabbitmq",
                Password = "rabbitmq"
            };

            return connectionFactory;
        }
    }
}
