using Common.Interfaces;
using Common.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VideoBlock.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IEntityManager<MovieViewModel, int> _movieManager;

        public MovieController(IEntityManager<MovieViewModel, int> movieManager)
        {
            _movieManager = movieManager;
        }

        // GET: api/<MovieController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return new JsonResult( await _movieManager.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/<MovieController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MovieController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MovieViewModel entity)
        {
            JsonResult result;
            try
            {
                await _movieManager.Save(entity);
                result = new JsonResult(new { success = true });
            }
            catch (Exception e)
            {
                result = new JsonResult(new { success = false, errorMessage = e.Message });
            }
            return result;
        }

        // PUT api/<MovieController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MovieController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
