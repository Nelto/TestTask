using Microsoft.AspNetCore.Mvc;
using TestTask.Model.Abstract;
using TestTask.Model.Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IRepos<User> _userRepos;

        public UserController(IRepos<User> userRepos) { _userRepos = userRepos; }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await _userRepos.GetAll();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<User?> Get(Guid id)
        {
            return await _userRepos.Get(id);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User entity)
        {
            entity.Id = Guid.NewGuid();
            await _userRepos.Add(entity);
            return Ok();
        }

        // PUT api/<UserController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] User entity)
        {
            var user = await _userRepos.Get(entity.Id);
            if(user == null)
            {
                return BadRequest("Пользователь не найден");
            }
            user.Copy(entity);
            await _userRepos.Update(user);
            return Ok();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (await _userRepos.Get(id) == null)
            {
                return BadRequest("Пользователь не найден");
            }
            await _userRepos.Delete(id);

            return Ok();
        }
    }
}
