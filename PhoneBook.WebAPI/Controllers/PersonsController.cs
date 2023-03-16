using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Business.Abstract;

namespace PhoneBook.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _personService.GetList();

            return Ok(result);
        }
    }
}
