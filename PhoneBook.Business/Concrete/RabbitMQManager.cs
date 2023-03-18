﻿using Newtonsoft.Json;
using PhoneBook.Business.Abstract;
using PhoneBook.Entities.Concrete;
using RabbitMQ.Client;
using System.Text;

namespace PhoneBook.Business.Concrete
{
    public class RabbitMQManager : IRabbitMQService
    {
        private readonly IReportService _reportService;
        IConnection connection;
        IModel channel;
        public RabbitMQManager(IReportService reportService)
        {
            _reportService = reportService;

            var factory = new ConnectionFactory();
            factory.Uri = new Uri("amqps://tokcpplt:3z3LVZe6dV3FnOCpDxOcIQgmLNzdqHnA@shrimp.rmq.cloudamqp.com/tokcpplt");
            connection = factory.CreateConnection();
            channel = connection.CreateModel();
            channel.QueueDeclare("Reports", true, false, false);
        }
        public void RequestReport()
        {
            var report = CreateReport();

            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject("data"));

            IBasicProperties messageProperties = channel.CreateBasicProperties();
            messageProperties.MessageId = report.UUID.ToString();
            channel.BasicPublish(String.Empty, "Reports", messageProperties, body);
        }

        private Report CreateReport()
        {
            var report = new Report
            {
                ReportCreatedDate = DateTime.UtcNow,
                ReportPath = "",
                ReportStatus = "Hazırlanıyor"
            };
            return _reportService.Add(report);
        }
    }
}
