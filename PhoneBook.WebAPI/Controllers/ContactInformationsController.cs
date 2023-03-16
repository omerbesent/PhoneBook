using Microsoft.AspNetCore.Mvc;
using PhoneBook.Business.Abstract;
using PhoneBook.Entities.Concrete;

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

        [HttpPost("Add")]
        public IActionResult Add(ContactInformation contactInformation)
        {
            var result = _contactInformationService.Add(contactInformation);

            return Ok(result);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int contactInformationId)
        {
            var result = _contactInformationService.Delete(contactInformationId);

            return Ok(result);
        }
    }
}
