using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_GET_6.Shared;


namespace Project_GET_6.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly DataContext _context;
        public RolesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Role>>> getRoles()
        {
            var roles = await _context.Roles.ToListAsync();
            return Ok(roles);
        }

        [HttpGet("{rolename}")]
        public async Task<ActionResult<Role>> getRoleWithName(string rolename)
        {
            Console.WriteLine("usao2");
            var role = await _context.Roles.FirstOrDefaultAsync(h => h.RoleName == rolename);
            Console.WriteLine("izasao2");
            Console.WriteLine(role);
            if (role == null)
            {
                return NotFound("Sorry, no roles with that name.");
            }
            return Ok(role);
        }

        [HttpPost]
        public async Task<ActionResult<List<Role>>> CreateRole(Role role)
        {
            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();

            return Ok(await GetDbRoles());

        }

        private async Task<List<Role>> GetDbRoles()
        {
            return await _context.Roles.ToListAsync();
        }

		[HttpPut("{id}")]
		public async Task<ActionResult<List<Role>>> UpdateRole(Role role, int id)
		{
            var dbRole = await _context.Roles.FirstOrDefaultAsync(sh => sh.RoleId == id);
            if(dbRole == null)
            {
                return NotFound("Sorry, no role with this id.");
            }
            dbRole.RoleName = role.RoleName;

			await _context.SaveChangesAsync();

			return Ok(await GetDbRoles());

		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<List<Role>>> DeleteRole(int id)
		{
			var dbRole = await _context.Roles.FirstOrDefaultAsync(sh => sh.RoleId == id);
			if (dbRole == null)
			{
				return NotFound("Sorry, no role with this id.");
			}
			
            _context.Roles.Remove(dbRole);

			await _context.SaveChangesAsync();

			return Ok(await GetDbRoles());

		}
	}
}
