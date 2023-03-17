using Microsoft.AspNetCore.Mvc;

namespace PhoneBook.WebApp.Controllers
{
    public class PersonsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
