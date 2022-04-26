using IFoodyPagamento.Api.Options;
using IFoodyPagamento.Application.Interfaces;
using IFoodyPagamento.Application.Models;
using IFoodyPagamento.Domain.Dtos;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IFoodyPagamento.Api.Consumers
{
    public class CobrancaConsumer : BackgroundService
    {
        private readonly RabbitMqConfiguration _configuration;
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly IServiceProvider _serviceProvider;

        public CobrancaConsumer(IOptions<RabbitMqConfiguration> option, IServiceProvider serviceProvider)
        {
            _configuration = option.Value;
            _serviceProvider = serviceProvider;

            var factory = new ConnectionFactory
            {
                HostName = _configuration.Host
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(
                queue: _configuration.Queue,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += async (sender, eventArgs) =>
            {
                var contentArray = eventArgs.Body.ToArray();
                var contentString = Encoding.UTF8.GetString(contentArray);
                var message = JsonConvert.DeserializeObject<CobrancaInput>(contentString);
                await CobrarPedidosCliente(message);

                _channel.BasicAck(eventArgs.DeliveryTag, false);
            };
            _channel.BasicConsume(_configuration.Queue, false, consumer);

            return Task.CompletedTask;
        }


        private async Task CobrarPedidosCliente(CobrancaInput cobranca)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
               var cobrancaService = scope.ServiceProvider.GetRequiredService<ICobrancaApplication>();

                await cobrancaService.CobrarPedidosCliente(cobranca);
            }
        }
    }
}