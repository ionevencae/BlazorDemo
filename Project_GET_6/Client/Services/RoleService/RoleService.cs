using Microsoft.AspNetCore.Components;
using Project_GET_6.Shared;
using System.Net.Http.Json;

namespace Project_GET_6.Client.Services.RoleService
{
    public class RoleService : IRoleService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public RoleService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public List<Role> Roles { get; set; } = new List<Role>();

        public async Task CreateRole(Role role)
        {
            var result = await _http.PostAsJsonAsync("api/roles", role);
            await SetRoles(result);
        }

        private async Task SetRoles(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Role>>();
            Roles = response;
            _navigationManager.NavigateTo("roles");
        }
        public async Task<Role> GetRoleWithName(string name)
        {
            /*var result = await _http.GetFromJsonAsync<List<Role>>("api/roles/" + name);
            if (result != null)
            {
                return result;
            }*/
            //Console.WriteLine("usao1");
            var result = await _http.GetFromJsonAsync<Role>($"api/roles/{name}");
            //Console.WriteLine("izasao1");
            if (result != null)
            {
                return result;
            }

            return null;

            //throw new NotImplementedException();
        }

        public async Task GetRoles()
        {
            var result = await _http.GetFromJsonAsync<List<Role>>("api/roles");
            if(result != null)
            {
                Roles = result;
            }
        }

		public async Task DeleteRole(int id)
		{
			var result = await _http.DeleteAsync($"api/roles/{id}");
			await SetRoles(result);
		}

		public async Task UpdateRole(Role role)
		{
            var result = await _http.PutAsJsonAsync($"api/roles/{role.RoleId}", role);
			await SetRoles(result);
		}
	}
}
