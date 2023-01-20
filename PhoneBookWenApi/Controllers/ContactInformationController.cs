using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PhoneBookWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactInformationController : ControllerBase
    {
        private readonly IContactInformationService _contactInformationService;
            public ContactInformationController(IContactInformationService contactInformationService)
        {
            _contactInformationService = contactInformationService;
        }

        [HttpPost("add")]
        public IActionResult Add(ContactInformation contactInformation)
        {
            if (contactInformation == null) return BadRequest();

            var result = _contactInformationService.Add(contactInformation);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(ContactInformation contactInformation)
        {
            var result = _contactInformationService.Delete(contactInformation);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
