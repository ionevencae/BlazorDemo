using Project_GET_6.Client.Pages;

namespace Project_GET_6.Client.Services.RoleService
{
    public interface IPaginationService
    {
        List<Project> GetProjectsPage(List<Project> list, int pagesize, int pagenum);
        List<ProjectTask> GetProjectTasksPage(List<ProjectTask> list, int pagesize, int pagenum);
        List<User> GetUsersPage(List<User> list, int pagesize, int pagenum);
        List<Role> GetRolesPage(List<Role> list, int pagesize, int pagenum);
    }
}
