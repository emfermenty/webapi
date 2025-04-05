/*using api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        ApplicationContext db;
        public UsersController(ApplicationContext context)
        {
            db = context;
            if (!db.Users.Any())
            {
                db.Users.Add(new User { name = "Tom", age = 26 });
                db.Users.Add(new User { name = "Alice", age = 31 });
                db.SaveChanges();
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return await db.Users.ToListAsync();
        }
        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int Id)
        {
            User user = await db.Users.FirstOrDefaultAsync(a => a.id == Id);
            if(user == null)
            {
                return NotFound();
            }
            return new ObjectResult(user);
        }
        // POST api/users
        [HttpPost]
        public async Task<ActionResult<User>> Post(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();
            return Ok();
        }
        // PUT api/users
        [HttpPut]
        public async Task<ActionResult<User>> Put (User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            if(!db.Users.Any(x => x.id == user.id))
            {
                return NotFound();
            }
            db.Update(user);
            await db.SaveChangesAsync();
            return Ok(user);
        }
        [HttpDelete]
        public async Task<ActionResult<User>> Delete(int Id)
        {
            User user = await db.Users.FirstOrDefaultAsync(x => x.id == Id);
            if(user == null)
            {
                return BadRequest();
            }
            db.Users.Remove(user);
            await db.SaveChangesAsync();
            return Ok(user);
        }
    }
}
*/