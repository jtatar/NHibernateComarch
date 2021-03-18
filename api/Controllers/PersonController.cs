using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ZadanieRekrutacyjne.Domain;
using ZadanieRekrutacyjne;
using System;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private IPersonRepository _personRepo;

        public PersonController(ILogger<PersonController> logger)
        {
            _personRepo = NhibernateMain.GetInstance().GetPersonRepo();
            _logger = logger;
        }

        [HttpGet("{id:Guid}")]
        public IActionResult Get(Guid id)
        {
            Person result = this._personRepo.Get(id);
            if (result.Id != Guid.Empty)
            {
                return Ok(result);

            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            Guid id = this._personRepo.Save(person);
            if (id != Guid.Empty)
            {
                return Ok(id);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id:Guid}")]
        public IActionResult Delete(Guid id)
        {
            Boolean success = this._personRepo.Delete(id);
            if (success)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] Person person)
        {
            Person updatedPerson = this._personRepo.Update(person);
            if (updatedPerson.Id != Guid.Empty)
            {
                return Ok(updatedPerson);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("age/{age:int}")]
        public IActionResult GetByAge(int age)
        {
            Person[] people = this._personRepo.GetByAge(age);
            return Ok(people);
        }

        [HttpGet("oldest/{amount:int}")]
        public IActionResult GetOldest(int amount)
        {
            Person[] people = this._personRepo.GetOldest(amount);
            return Ok(people);
        }

        [HttpGet("allwithout/{amountToSkip:int}")]
        public IActionResult GetAllWithoutOldest(int amountToSkip)
        {
            Person[] people = this._personRepo.GetAllWithoutOldest(amountToSkip);
            return Ok(people);
        }
    }
}
