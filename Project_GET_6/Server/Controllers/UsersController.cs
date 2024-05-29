using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project_GET_6.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> getUsers()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<Role>> getUserWithUsername(string username)
        {
            //Console.WriteLine("usao2");
            var user = await _context.Users.FirstOrDefaultAsync(h => h.Username == username);
            //Console.WriteLine("izasao2");
            //Console.WriteLine(user);
            if (user == null)
            {
                return NotFound("Sorry, no users with that name.");
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<List<User>>> CreateUser(User user)
        {
            var found = await _context.Users.FirstOrDefaultAsync(h => h.Username == user.Username);
            
            if (found != null)
            {
                return BadRequest("Sorry, username must be unique.");
            }

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return Ok(await GetDbUsers());

        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> UserLogin(User user)
        {
			var loggedInUser = await _context.Users.FirstOrDefaultAsync(
                h => h.Username == user.Username && h.Password == user.Password);
            //Console.WriteLine(user);
            if (loggedInUser == null)
            {
				return NotFound(null);
            }
            return Ok(loggedInUser);


        }

        private async Task<List<User>> GetDbUsers()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpPut("{username}")]
        public async Task<ActionResult<List<User>>> UpdateUser(User user, string username)
        {
            Console.WriteLine("Usao u backend update user" + username + " " + user.Username);
            if(user.Username != username)
            { 
                var found = await _context.Users.FirstOrDefaultAsync(h => h.Username == user.Username);

                if (found != null)
                {
                    Console.WriteLine("found != null");
                    return BadRequest("Sorry, username must be unique.");
                }

            }

            var dbUser = await _context.Users.FirstOrDefaultAsync(sh => sh.Username == username);
            if (dbUser == null)
            {
                Console.WriteLine("dbUser == null");
                return NotFound("Sorry, no user with this username.");
            }
            dbUser.Name = user.Name;
            dbUser.Surname = user.Surname;
            //dbUser.Username = user.Username;
            dbUser.Password = user.Password;
            dbUser.Email = user.Email;
            dbUser.RoleId = user.RoleId;

            await _context.SaveChangesAsync();

            return Ok(await GetDbUsers());


        }

        [HttpDelete("{username}")]
        public async Task<ActionResult<List<User>>> DeleteUser(string username)
        {
            var dbUser = await _context.Users.FirstOrDefaultAsync(sh => sh.Username == username);
            if (dbUser == null)
            {
                return NotFound("Sorry, no user with this username.");
            }

            _context.Users.Remove(dbUser);

            await _context.SaveChangesAsync();

            return Ok(await GetDbUsers());

        }
    }
}
