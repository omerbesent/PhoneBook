using Microsoft.AspNetCore.Mvc;
using PhoneBook.WebApp.Models;
using PhoneBook.WebApp.Services.Abstact;

namespace PhoneBook.WebApp.Controllers
{
    public class PersonsController : Controller
    {
        private readonly IPersonService _personService;

        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }

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
            var result2 = _personService.GetAll();
            if (ModelState.IsValid)
            {
                var result = _personService.Add(personViewModel);
            }
            return View();
        }
    }
}
