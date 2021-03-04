using Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoBlock.Common.Interfaces;
using VideoBlock.Common.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VideoBlock.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManager _userManager;
        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }
        // GET: api/<UserController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return new JsonResult(await _userManager.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserViewModel value)
        {
            JsonResult result;
            try
            {
                await _userManager.Save(value);
                result = new JsonResult(new { success = true });
            }
            catch (Exception e)
            {
                result = new JsonResult(new { success = false, errorMessage = e.Message });
            }
            return result;
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpPost("[action]")]
        [Consumes("application/json")]
        public async Task<JsonResult> Login(LoginViewModel model)
        {
            JsonResult result;
            try
            {
                result = new JsonResult(new { success = true, data = await _userManager.Login(model) });
            }
            catch (Exception e)
            {
                result = new JsonResult(new { success = false, errorMessage = e.Message });
            }
            return result;
        }

        [HttpGet("userbyusername/{username}")]
        public async Task<IActionResult> GetUserByUsername(string username)
        {
            JsonResult result;
            try
            {
                result = new JsonResult(new { success = true, data = await _userManager.GetUserByUserName(username) });
            }
            catch (Exception e)
            {
                result = new JsonResult(new { success = false, errorMessage = e.Message });
            }
            return result;
        }

        [HttpGet("bookmovie/{idUser}/{idMovie}")]
        public async Task<IActionResult> BookAMovie(int idUser, int idMovie)
        {
            JsonResult result;
            try
            {
                var list = new List<int>();
                list.Add(idMovie);
                await _userManager.Booking(idUser, list);
                result = new JsonResult(new { success = true });
            }
            catch (Exception e)
            {
                result = new JsonResult(new { success = false, errorMessage = e.Message });
            }
            return result;
        }
    }
}
