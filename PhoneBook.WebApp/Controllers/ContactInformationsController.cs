using Microsoft.AspNetCore.Mvc;
using PhoneBook.WebApp.Services.Abstact;

namespace PhoneBook.WebApp.Controllers
{
    public class ContactInformationsController : Controller
    {
        private readonly IContactInformationService _contactInformationService;

        public ContactInformationsController(IContactInformationService contactInformationService)
        {
            _contactInformationService = contactInformationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List(int id)
        {
            var result =_contactInformationService.GetAllByPersonId(id);
            return View(result.Data);
        }
    }
}
