using Microsoft.AspNetCore.Mvc;
using PhoneBook.WebApp.Services.Abstact;

namespace PhoneBook.WebApp.Controllers
{
    public class ReportsController : Controller
    {
        private readonly IReportService _reportService;
        public ReportsController(IReportService reportService)
        {
            _reportService = reportService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List()
        {
            var result = _reportService.GetAll();
            return View(result.Data);
        }
    }
}
