using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ZadanieRekrutacyjne.Domain;
using ZadanieRekrutacyjne;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NHibernate.Tool.hbm2ddl;

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
            _personRepo = ZadanieRekrutacyjne.Program.GetInstance().GetPersonRepo();
            _logger = logger;
        }

        [HttpGet("{id:Guid}")]
        public IActionResult Get(Guid id)
        {
            Person result = this._personRepo.Get(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            this._personRepo.Save(person);
            return Ok();
        }

        [HttpDelete("{id:Guid}")]
        public IActionResult Delete(Guid id)
        {
            this._personRepo.Delete(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] Person person)
        {
            this._personRepo.Update(person);
            return Ok();
        }
    }
}
