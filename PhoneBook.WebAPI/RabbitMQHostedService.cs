using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace PhoneBook.WebAPI
{
    public class RabbitMQHostedService : BackgroundService
    {
        private readonly ILogger<RabbitMQHostedService> _logger;
        IConnection connection;
        IModel channel;
        public RabbitMQHostedService(ILogger<RabbitMQHostedService> logger)
        {
            _logger = logger; 

            var factory = new ConnectionFactory();
            factory.Uri = new Uri("amqps://tokcpplt:3z3LVZe6dV3FnOCpDxOcIQgmLNzdqHnA@shrimp.rmq.cloudamqp.com/tokcpplt");
            connection = factory.CreateConnection();
            channel = connection.CreateModel();
            channel.QueueDeclare("Reports", true, false, false);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(channel);
            channel.BasicConsume("Reports", true, consumer);

            consumer.Received += (model, e) =>
            {
                var strJson = Encoding.UTF8.GetString(e.Body.ToArray());
                var body = JsonConvert.DeserializeObject<string>(strJson);

                 
                _logger.LogInformation(strJson);
            };
        }
    }
}
