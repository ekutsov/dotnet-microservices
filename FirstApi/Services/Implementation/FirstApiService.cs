using System;
using System.Collections.Generic;
using System.Text;
using FirstApi.Models;
using FirstApi.Services.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace FirstApi.Services.Implementation
{
    public class FirstApiService : IFirstApiService
    {
        ConnectionFactory _factory;
        IConnection _connection;
        IModel _channel;
        private readonly Dictionary<string, string> _messages = new Dictionary<string, string>();
        public FirstApiService()
        {
            _factory = new ConnectionFactory() { HostName = Environment.GetEnvironmentVariable("HOSTNAMERABBIT") };
            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        public FirstApiModel GetResult()
        {
            SendRabbitMqMessage(queue: "First Api Queue", message: "Hello from First Api Queue!");
            ReceivedRabbitMqMessage(queue: "Fifth Api Queue");
            return new FirstApiModel
            {
                Title = "First Api",
                Messages = _messages
            };
        }

        public void SendRabbitMqMessage(string queue, string message)
        {
            _channel.QueueDeclare(queue,
                                  durable: true,
                                  exclusive: false,
                                  autoDelete: false,
                                  arguments: null);

            byte[] body = Encoding.UTF8.GetBytes(message);

            _channel.BasicPublish(exchange: "",
                                 routingKey: queue,
                                 basicProperties: null,
                                 body: body);
        }

        public void ReceivedRabbitMqMessage(string queue)
        {
            _channel.QueueDeclare(queue: queue,
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

            EventingBasicConsumer consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                byte[] body = ea.Body.ToArray();
                string message = Encoding.UTF8.GetString(body);
                _messages.Add(queue, message);
            };
            _channel.BasicConsume(queue: queue,
                                  autoAck: true,
                                  consumer: consumer);
        }
    }
}