using Microsoft.AspNetCore.Mvc;
using PhoneBook.WebApp.Models;

namespace PhoneBook.WebApp.Controllers
{
    public class PersonsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PersonViewModel personViewModel)
        {
            if (ModelState.IsValid)
            {

            }
            return View();
        }
    }
}
