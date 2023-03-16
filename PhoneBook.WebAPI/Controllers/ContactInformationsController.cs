using Microsoft.AspNetCore.Mvc;
using PhoneBook.Business.Abstract;

namespace PhoneBook.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactInformationsController : ControllerBase
    { 
        private readonly IContactInformationService _contactInformationService;

        public ContactInformationsController(IContactInformationService contactInformationService)
        {
            _contactInformationService = contactInformationService;
        }

        [HttpGet("GetByPersonId")]
        public IActionResult GetByPersonId(int personId)
        {
            var result = _contactInformationService.GetListByPersonId(personId);

            return Ok(result);
        }
    }
}
