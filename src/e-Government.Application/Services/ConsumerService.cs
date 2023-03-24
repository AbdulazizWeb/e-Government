using e_Government.Application.UseCases.AboutForeigner.Commands;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Government.Application.Services
{
    public class ConsumerService : BackgroundService
    {
        private readonly IModel _channel;
        private readonly IConfigurationSection _configuration;
        private readonly IServiceProvider _provider;
        public string queueName = String.Empty;
        public ConsumerService(IServiceProvider provider, IConfiguration configuration)
        {
            _provider = provider;
            _configuration = configuration.GetSection("MessageBrocker");
            
            var factory = new ConnectionFactory()
            {
                HostName = _configuration["Host"],
                Port = int.Parse(_configuration["Port"]),
                UserName = _configuration["UserName"],
                Password = _configuration["Password"],
            };
            var connection = factory.CreateConnection();

            _channel = connection.CreateModel();

            queueName = _channel.QueueDeclare().QueueName;

            _channel.QueueBind(queue: queueName, exchange: _configuration["Exchange"], routingKey: _configuration["RoutingKey"]);

            _channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += RecieveHandle;

            _channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);

            return Task.CompletedTask;
        }

        private async void RecieveHandle(object sender, BasicDeliverEventArgs model)
        {
            var json = Encoding.UTF8.GetString(model.Body.ToArray());

            var requestForeignerModel2 = JsonConvert.DeserializeObject<ForeignerRegistrCommand>(json);

            using var scope = _provider.CreateScope();

            var service = scope.ServiceProvider.GetRequiredService<IMediator>();

            var response =  await service.Send(requestForeignerModel2);

            Console.WriteLine(response);

            _channel.BasicAck(deliveryTag: model.DeliveryTag, multiple: false);
        }
    }
}
