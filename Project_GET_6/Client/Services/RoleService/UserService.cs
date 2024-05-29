using Microsoft.AspNetCore.Components;
using Project_GET_6.Client.Pages;
using Project_GET_6.Shared;
using System.Data;
using System.Net.Http.Json;

namespace Project_GET_6.Client.Services.RoleService
{
    public class UserService : IUserService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public UserService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public List<User> Users { get; set; } = new List<User>();

        public async Task<HttpResponseMessage> CreateUser(User user)
        {
            var result = await _http.PostAsJsonAsync("api/users", user);
            if(result.IsSuccessStatusCode)
            {
                await SetUsers(result);
            }
            return result;
        }

        private async Task SetUsers(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<User>>();
            Users = response;
            _navigationManager.NavigateTo("users");
        }

        public async Task DeleteUser(string username)
        {
            if (Users.SingleOrDefault(u => u.Username == username, null) == null) return;
            var result = await _http.DeleteAsync($"api/users/{username}");
            await SetUsers(result);
            
        }

        public async Task GetUsers()
        {
            var result = await _http.GetFromJsonAsync<List<User>>("api/users");
            if (result != null)
            {
                Users = result;
            }
        }

        public async Task<User> GetUserWithUsername(string username)
        {
            var result = await _http.GetFromJsonAsync<User>($"api/users/{username}");
            //Console.WriteLine("izasao1");
            if (result != null)
            {
                return result;
            }

            return null;
        }

        public async Task<HttpResponseMessage> UpdateUser(User user, string username)
        {
            //Console.WriteLine(user.Username);
            //Console.WriteLine(username);
            //Console.WriteLine("Usao frontend");
            var result = await _http.PutAsJsonAsync($"api/users/{user.Username}", user);
            if (result.IsSuccessStatusCode)
            {
                await SetUsers(result);
            }
            return result;
        }

        public async Task<User?> LoginUser(User user)
        {
			//Console.WriteLine(user.Username);
			//Console.WriteLine(user.Password);
			var result = await _http.PostAsJsonAsync("api/users/login", user);
			if (!result.IsSuccessStatusCode)
            {
				return null;
            }

            var ret = await result.Content.ReadFromJsonAsync<User>();
			//Console.WriteLine(ret.Username);
			return ret;
        }
    }
}
