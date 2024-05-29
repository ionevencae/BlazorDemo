using Project_GET_6.Client.Pages;

namespace Project_GET_6.Client.Services.RoleService
{
    public class PaginationService : IPaginationService
    {
        public List<Project> GetProjectsPage(List<Project> list, int pagesize, int pagenum)
        {
            //List<Project> newList = new List<Project>(list);
            list = new List<Project>();
            return list.Skip((pagenum - 1) * pagesize).Take(pagesize).ToList();
            
        }

        public List<ProjectTask> GetProjectTasksPage(List<ProjectTask> list, int pagesize, int pagenum)
        {
            List<ProjectTask> newList = new List<ProjectTask>(list);
            return newList.Skip((pagenum - 1) * pagesize).Take(pagesize).ToList();
        }

        public List<Role> GetRolesPage(List<Role> list, int pagesize, int pagenum)
        {
            List<Role> newList = new List<Role>(list);
            return newList.Skip((pagenum - 1) * pagesize).Take(pagesize).ToList();
        }

        public List<User> GetUsersPage(List<User> list, int pagesize, int pagenum)
        {
            List<User> newList = new List<User>(list);
            return newList.Skip((pagenum - 1) * pagesize).Take(pagesize).ToList();
        }
    }
}
