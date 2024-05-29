using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace Project_GET_6.Client.Services.RoleService
{
    public class ProjectTaskService : IProjectTaskService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public ProjectTaskService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public List<ProjectTask> ProjectTasks { get; set; } = new List<ProjectTask>();

        public async Task<HttpResponseMessage> CreateProjectTask(ProjectTask task)
        {
            Console.WriteLine("Usao frontend create task");
            var result = await _http.PostAsJsonAsync("api/projecttasks", task);
            Console.WriteLine("Frontend create task " + result.IsSuccessStatusCode);
            if (result.IsSuccessStatusCode)
            {
                await SetProjectTasks(result);
            }
            return result;
        }

        private async Task SetProjectTasks(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<ProjectTask>>();
            ProjectTasks = response;
            _navigationManager.NavigateTo("tasks");
        }

        public async Task DeleteProjectTask(int id)
        {
            if (ProjectTasks.SingleOrDefault(t => t.ProjectTaskId == id, null) == null) return;
            var result = await _http.DeleteAsync($"api/projecttasks/{id}");
            await SetProjectTasks(result);
        }

        public async Task GetProjectTasks()
        {
            //Console.Write("Usao frontend projects");
            var result = await _http.GetFromJsonAsync<List<ProjectTask>>("api/projecttasks");
            if (result != null)
            {
                ProjectTasks = result;
            }
        }

        public async Task<ProjectTask> GetProjectTaskWithId(int id)
        {
            var result = await _http.GetFromJsonAsync<ProjectTask>($"api/projecttasks/{id}");
            if (result != null)
            {
                return result;
            }

            return null;
        }

        public async Task<List<ProjectTask>> GetProjectsTaskWithProjectCode(string projcode)
        {
            var result = await _http.GetFromJsonAsync<List<ProjectTask>>($"api/projecttasks/proj/{projcode}");
            if (result != null)
            {
                return result;
            }

            return result;
        }

        public async Task<HttpResponseMessage> UpdateProjectTask(ProjectTask task, int id)
        {
            var result = await _http.PutAsJsonAsync($"api/projecttasks/{task.ProjectTaskId}", task);
            if (result.IsSuccessStatusCode)
            {
                await SetProjectTasks(result);
            }
            return result;
        }
    }
}
