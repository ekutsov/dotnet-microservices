using System;
using System.Collections.Generic;
using System.Text;
using FifthApi.Models;
using FifthApi.Services.Interfaces;

using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace FifthApi.Services.Implementation
{
    public class FifthApiService : IFifthApiService
    {
        ConnectionFactory _factory;
        IConnection _connection;
        IModel _channel;
        private readonly Dictionary<string, string> _messages = new Dictionary<string, string>();
        public FifthApiService()
        {
            _factory = new ConnectionFactory() { HostName = Environment.GetEnvironmentVariable("HOSTNAMERABBIT") };
            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        public FifthApiModel GetResult()
        {
            SendRabbitMqMessage(queue: "Fifth Api Queue", message: "Hello from Fifth Api Queue!");
            ReceivedRabbitMqMessage(queue: "First Api Queue");
            return new FifthApiModel
            {
                Title = "Fifth Api",
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