using Newtonsoft.Json;
using PhoneBook.Business.Abstract;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace PhoneBook.WebAPI
{
    public class RabbitMQHostedService : BackgroundService
    {
        private readonly ILogger<RabbitMQHostedService> _logger;
        private readonly IReportService _reportService;
        IConnection connection;
        IModel channel;
        public RabbitMQHostedService(ILogger<RabbitMQHostedService> logger, IReportService reportService)
        {
            _logger = logger;
            _reportService = reportService;

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

                var fromReport = _reportService.GetById(Convert.ToInt32(e.BasicProperties.MessageId));
                fromReport.Data.ReportStatus = "Tamamlandı";
                fromReport.Data.ReportCreatedDate = DateTime.UtcNow;
                var result = _reportService.Update(fromReport.Data);

                _logger.LogInformation(strJson);
            };
        }
    }
}
