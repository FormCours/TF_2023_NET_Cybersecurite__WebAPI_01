using Demo_WebAPI_01.BLL.Interfaces;
using Demo_WebAPI_01.BLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo_WebAPI_01.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _PersonService;

        public PersonController(IPersonService personService)
        {
            _PersonService = personService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Person> people = _PersonService.GetAll();

            return Ok(people);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            Person? person = _PersonService.GetById(id);

            if(person is null)
            {
                return NotFound();
            }

            return Ok(person);
        }
    }
}
