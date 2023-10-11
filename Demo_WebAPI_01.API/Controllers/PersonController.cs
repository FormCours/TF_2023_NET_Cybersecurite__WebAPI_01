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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PersonDetailDto))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public IActionResult AddPerson(PersonDataDto personData)
        {
            if(personData.BirthDate >= DateTime.Today)
            {
                ModelState.AddModelError(nameof(personData.BirthDate), "The value is in futur :o");
            }

            if(_PersonService.PseudoIsAlreadyUsed(personData.Pseudo))
            {
                ModelState.AddModelError(nameof(personData.Pseudo), "Pseudo is Already used !");
            }

            if(!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            PersonDetailDto personAdded = _PersonService.Add(personData.ToModel()).ToDetailDto();

            // https://developer.mozilla.org/fr/docs/Web/HTTP/Status/201
            return CreatedAtAction(nameof(GetById), new { id = personAdded.PersonId }, personAdded);

            // Detail de la méthode "CreatedAtAction"
            //  - Les 2 premiers parametres permettre de générer l'url qui sera dans le "header" (location)
            //  - Le 3 parametre permet d'envoyer la copie de l'objet créer
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete([FromRoute] int id)
        {
            bool isDeleted = _PersonService.Delete(id);

            if(isDeleted)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpPut("{id:int}")]
        public IActionResult Update([FromRoute] int id, [FromBody] PersonDataDto personData)
        {
            return StatusCode(StatusCodes.Status501NotImplemented);
        }
    }
}
