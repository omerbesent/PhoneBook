using ClosedXML.Excel;
using Newtonsoft.Json;
using PhoneBook.Business.Abstract;
using PhoneBook.Entities.Concrete.Dto;
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
                var body = JsonConvert.DeserializeObject<IList<LocationReportDto>>(strJson);


                CreateExcelReportFile(body, Convert.ToInt32(e.BasicProperties.MessageId));
                _logger.LogInformation(strJson);
            };

        }

        void CreateExcelReportFile(IList<LocationReportDto> report, int messageId)
        {

            using (var workbook = new XLWorkbook())
            {
                var ws = workbook.Worksheets.Add("Konum_Raporu");
                ws.Range("A1").Value = "Konum";
                ws.Range("B1").Value = "Kayıtlı Kişi Sayısı";
                ws.Range("C1").Value = "Rehbere Kayıtlı Telefon Sayıı";

                for (int i = 0; i < report.Count; i++)
                {
                    ws.Range($"A{i + 2}").Value = report[i].Location.ToString();
                    ws.Range($"B{i + 2}").Value = report[i].PersonCount.ToString();
                    ws.Range($"C{i + 2}").Value = report[i].PhoneCount.ToString();
                }


                var fileName = $"Konum_Raporu_{DateTime.Now.Ticks}.xlsx";
                var filePath = $"Upload/Reports/{fileName}";

                workbook.SaveAs(filePath);

                var fromReport = _reportService.GetById(messageId);
                fromReport.Data.ReportStatus = "Tamamlandı";
                fromReport.Data.ReportPath = filePath;
                fromReport.Data.ReportCreatedDate = DateTime.UtcNow;
                var result = _reportService.Update(fromReport.Data);
            }

        }

    }
}
