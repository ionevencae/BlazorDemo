namespace Project_GET_6.Client.Services.RoleService
{
    public interface IProjectService
    {
        List<Project> Projects { get; set; }

        Task GetProjects();

        Task<Project> GetProjectWithCode(string code);

        Task<HttpResponseMessage> CreateProject(Project proj);

        Task<HttpResponseMessage> UpdateProject(Project proj, string projcode);

        Task DeleteProject(string projcode);

    }
}
