using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace Project_GET_6.Client.Services.RoleService
{
    public class ProjectService : IProjectService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public ProjectService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public List<Project> Projects { get; set; } = new List<Project>();

        public async Task<HttpResponseMessage> CreateProject(Project proj)
        {
            var result = await _http.PostAsJsonAsync("api/projects", proj);
            if (result.IsSuccessStatusCode)
            {
                await SetProjects(result);
            }
            return result;
        }

        private async Task SetProjects(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Project>>();
            Projects = response;
            _navigationManager.NavigateTo("projects");
        }

        public async Task DeleteProject(string projcode)
        {
            if (Projects.SingleOrDefault(p => p.ProjectCode == projcode, null) == null) return;
            var result = await _http.DeleteAsync($"api/projects/{projcode}");
            await SetProjects(result);
        }

        public async Task GetProjects()
        {
            //Console.Write("Usao frontend projects");
            var result = await _http.GetFromJsonAsync<List<Project>>("api/projects");
            if (result != null)
            {
                Projects = result;
            }
        }

        public async Task<Project> GetProjectWithCode(string projcode)
        {
            var result = await _http.GetFromJsonAsync<Project>($"api/projects/{projcode}");
            if (result != null)
            {
                return result;
            }

            return null;
        }

        public async Task<HttpResponseMessage> UpdateProject(Project proj, string projcode)
        {
            var result = await _http.PutAsJsonAsync($"api/projects/{proj.ProjectCode}", proj);
            if (result.IsSuccessStatusCode)
            {
                await SetProjects(result);
            }
            return result;
        }

    }
}
