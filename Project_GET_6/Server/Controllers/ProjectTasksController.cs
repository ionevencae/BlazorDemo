using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project_GET_6.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectTasksController : ControllerBase
    {
        private readonly DataContext _context;
        public ProjectTasksController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProjectTask>>> getProjectTasks()
        {
            //Console.Write("Usao backend projects");
            var projecttasks = await _context.ProjectTasks.ToListAsync();
            return Ok(projecttasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectTask>> GetProjectWithId(int id)
        {
            var task = await _context.ProjectTasks.FirstOrDefaultAsync(h => h.ProjectTaskId == id);
            if (task == null)
            {
                return NotFound("Sorry, no project tasks with that code.");
            }
            return Ok(task);
        }

        [HttpGet("/proj/{projcode}")]
        public async Task<ActionResult<List<ProjectTask>>> GetProjectsWithProjectCode(string projcode)
        {
            var task = await _context.ProjectTasks.Where(h => h.ParentProjectProjectCode == projcode).ToListAsync();
            if (task == null)
            {
                return BadRequest("Sorry, project task id must be unique.");
            }
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<List<ProjectTask>>> CreateProjectTask(ProjectTask task)
        {
            //Console.WriteLine("Usao backend create task");
            var found = await _context.ProjectTasks.FirstOrDefaultAsync(h => h.ProjectTaskId == task.ProjectTaskId);
            var found2 = await _context.Projects.FirstOrDefaultAsync(h => h.ProjectCode == task.ParentProjectProjectCode);
            var found3 = await _context.Users.FirstOrDefaultAsync(h => h.Username == task.AssigneeUsername);
            //Console.WriteLine("Backend create task " + found);
            if (found != null
                || found2 == null
                || found3 == null
                )
            {
                return BadRequest("Sorry, project task id must be unique.");
            }

            await _context.ProjectTasks.AddAsync(task);
            await _context.SaveChangesAsync();

            return Ok(await GetDbProjectTasks());

        }


        private async Task<List<ProjectTask>> GetDbProjectTasks()
        {
            return await _context.ProjectTasks.ToListAsync();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<ProjectTask>>> UpdateProjectTask(ProjectTask task, int id)
        {
            Console.WriteLine("Usao u backend update task");
            if (task.ProjectTaskId != id)
            {
                var found = await _context.ProjectTasks.FirstOrDefaultAsync(h => task.ProjectTaskId == task.ProjectTaskId);

                if (found != null)
                {
                    Console.WriteLine("Usao u backend not found");
                    //Console.WriteLine("found != null");
                    return BadRequest("Sorry, project task id must be unique.");
                }

            }

            var dbProjectTask = await _context.ProjectTasks.FirstOrDefaultAsync(sh => sh.ProjectTaskId == id);
            if (dbProjectTask == null)
            {
                //Console.WriteLine("dbUser == null");
                return NotFound("Sorry, no project task with this id.");
            }
            dbProjectTask.ParentProjectProjectCode = task.ParentProjectProjectCode;
            dbProjectTask.Status = task.Status;
            dbProjectTask.Progress = task.Progress;
            dbProjectTask.Deadline = task.Deadline;
            dbProjectTask.Description = task.Description;
            dbProjectTask.AssigneeUsername = task.AssigneeUsername;

            await _context.SaveChangesAsync();

            return Ok(await GetDbProjectTasks());


        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ProjectTask>>> DeleteProject(int id)
        {
            var dbProjectTask = await _context.ProjectTasks.FirstOrDefaultAsync(sh => sh.ProjectTaskId == id);
            if (dbProjectTask == null)
            {
                return NotFound("Sorry, no project task with this id.");
            }

            _context.ProjectTasks.Remove(dbProjectTask);

            await _context.SaveChangesAsync();

            return Ok(await GetDbProjectTasks());

        }


    }
}
