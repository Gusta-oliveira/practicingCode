using Microsoft.AspNetCore.Mvc;
using RestWithASPNet.Models;
using RestWithASPNet.Services;
using System.Reflection.Metadata.Ecma335;

namespace RestWithASPNet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_personService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var person = _personService.FindById(id);
            if (person == null) return NotFound("Usuário não encontrado");

            return Ok(person);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _personService.Delete(id);
            return Ok(true);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] Person person)
        {
            if (person == null) return BadRequest("Informações não registrada");
            var personUpdating = _personService.Update(person);

            return Ok(personUpdating);
        }

        [HttpPost("{id}")]
        public IActionResult Create([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            var createdPerson = _personService.Create(person);

            return Ok(createdPerson);
        }
    }
}
