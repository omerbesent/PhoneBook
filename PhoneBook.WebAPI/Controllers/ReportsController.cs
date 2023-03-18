using Microsoft.AspNetCore.Mvc;
using PhoneBook.Business.Abstract;

namespace PhoneBook.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IRabbitMQService _rabbitMqService;

        public ReportsController(IRabbitMQService rabbitMqService)
        {
            _rabbitMqService = rabbitMqService;
        }

        [HttpGet("RequestReport")]
        public IActionResult RequestReport()
        {
            _rabbitMqService.RequestReport();

            return Ok();
        }
    }
}