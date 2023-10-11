using Demo_WebAPI_01.API.Dtos;
using Demo_WebAPI_01.API.Dtos.Mappers;
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PersonListDto>))]
        public IActionResult Get([FromQuery] PaginationQueryDto pagination)
        {
            IEnumerable<PersonListDto> people = _PersonService
                .GetAll(pagination.Offset, pagination.Limit)
                .Select(p => p.ToListDto());

            //IEnumerable<PersonListDto> people2 = _PersonService
            //     .GetAll(pagination.Offset, pagination.Limit)
            //     .Select(PersonMapper.ToListDto);

            return Ok(people);
        }

        [HttpGet]
        [Route("{id:int}")] // Alternative → [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type= typeof(PersonDetailDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById([FromRoute] int id)
        {
            PersonDetailDto? person = _PersonService.GetById(id)?.ToDetailDto();

            if(person is null)
            {
                return NotFound();
            }

            return Ok(person);
        }
    }
}
