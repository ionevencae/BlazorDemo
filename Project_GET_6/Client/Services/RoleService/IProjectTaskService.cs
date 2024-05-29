namespace Project_GET_6.Client.Services.RoleService
{
    public interface IProjectTaskService
    {
        List<ProjectTask> ProjectTasks { get; set; }

        Task GetProjectTasks();

        Task<ProjectTask> GetProjectTaskWithId(int id);
        Task<List<ProjectTask>> GetProjectsTaskWithProjectCode(string projcode);

        Task<HttpResponseMessage> CreateProjectTask(ProjectTask task);

        Task<HttpResponseMessage> UpdateProjectTask(ProjectTask task, int id);

        Task DeleteProjectTask(int id);
    }
}
