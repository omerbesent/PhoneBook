using Newtonsoft.Json;
using PhoneBook.Business.Abstract;
using RabbitMQ.Client;
using System.Text;

namespace PhoneBook.Business.Concrete
{
    public class RabbitMQManager : IRabbitMQService
    {
        IConnection connection;
        IModel channel;
        public RabbitMQManager()
        {
            var factory = new ConnectionFactory();
            factory.Uri = new Uri("amqps://tokcpplt:3z3LVZe6dV3FnOCpDxOcIQgmLNzdqHnA@shrimp.rmq.cloudamqp.com/tokcpplt");
            connection = factory.CreateConnection();
            channel = connection.CreateModel();
            channel.QueueDeclare("Reports", true, false, false);
        }
        public void RequestReport()
        {

            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject("data"));

            IBasicProperties messageProperties = channel.CreateBasicProperties();
            channel.BasicPublish(String.Empty, "Reports", messageProperties, body);
        }


    }
}
