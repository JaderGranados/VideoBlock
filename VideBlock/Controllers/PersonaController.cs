using Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoBlock.Common.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VideoBlock.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IEntityManager<PersonaViewModel, int> _personaManager;
        public PersonaController(IEntityManager<PersonaViewModel, int> personaManager)
        {
            _personaManager = personaManager;
        }

        // GET: api/<PersonaController>
        [HttpGet]
        public async Task<IEnumerable<PersonaViewModel>> Get()
        {
            return await _personaManager.GetAll();
        }

        // GET api/<PersonaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PersonaController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PersonaViewModel persona)
        {
            JsonResult result;
            try
            {
                await _personaManager.Save(persona);
                result = new JsonResult(new { success = true });
            }
            catch (Exception e)
            {
                result = new JsonResult(new { success = false });
            }
            return result;
        }

        // PUT api/<PersonaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PersonaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
