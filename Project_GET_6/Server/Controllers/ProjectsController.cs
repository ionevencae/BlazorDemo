using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project_GET_6.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly DataContext _context;
        public ProjectsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Project>>> getProjects()
        {
            Console.Write("Usao backend projects");
            var projects = await _context.Projects.ToListAsync();
            return Ok(projects);
        }

        [HttpGet("{projcode}")]
        public async Task<ActionResult<Project>> GetProjectWithCode(string projcode)
        {
            var proj = await _context.Projects.FirstOrDefaultAsync(h => h.ProjectCode == projcode);
            if (proj == null)
            {
                return NotFound("Sorry, no projects with that code.");
            }
            return Ok(proj);
        }

        [HttpPost]
        public async Task<ActionResult<List<Project>>> CreateProject(Project proj)
        {
            var found = await _context.Projects.FirstOrDefaultAsync(h => h.ProjectCode == proj.ProjectCode);
            var found2 = await _context.Users.FirstOrDefaultAsync(h => h.Username == proj.ProjectManagerUsername && h.RoleId == 2);

            if (found != null 
                || found2 == null
                )
            {
                return BadRequest("Sorry, project code must be unique.");
            }

            await _context.Projects.AddAsync(proj);
            await _context.SaveChangesAsync();

            return Ok(await GetDbProjects());

        }


        private async Task<List<Project>> GetDbProjects()
        {
            return await _context.Projects.ToListAsync();
        }

        [HttpPut("{projcode}")]
        public async Task<ActionResult<List<Project>>> UpdateProject(Project proj, string projcode)
        {
            //Console.WriteLine("Usao u backend update user" + username + " " + user.Username);
            if (proj.ProjectCode != projcode)
            {
                var found = await _context.Projects.FirstOrDefaultAsync(h => proj.ProjectCode == proj.ProjectCode);

                if (found != null)
                {
                    //Console.WriteLine("found != null");
                    return BadRequest("Sorry, project code must be unique.");
                }

            }

            var dbProject = await _context.Projects.FirstOrDefaultAsync(sh => sh.ProjectCode == projcode);
            if (dbProject == null)
            {
                //Console.WriteLine("dbUser == null");
                return NotFound("Sorry, no project with this project code.");
            }
            dbProject.ProjectName = proj.ProjectName;
            dbProject.ProjectManagerUsername = proj.ProjectManagerUsername;

            await _context.SaveChangesAsync();

            return Ok(await GetDbProjects());


        }

        [HttpDelete("{projcode}")]
        public async Task<ActionResult<List<Project>>> DeleteProject(string projcode)
        {
            var dbProject = await _context.Projects.FirstOrDefaultAsync(sh => sh.ProjectCode == projcode);
            if (dbProject == null)
            {
                return NotFound("Sorry, no project with this code.");
            }

            foreach(var t in _context.ProjectTasks.Where(p => p.ParentProjectProjectCode == projcode))
            {
                _context.Remove(t);
            }

            //List<string> list = new List<string>();
            //IEnumerable<string> list2 = new List<string>();
            //var c1 = list.Count;
            //var c2 = list2.Count();

            _context.Projects.Remove(dbProject);

            await _context.SaveChangesAsync();

            return Ok(await GetDbProjects());

        }
    }
}
