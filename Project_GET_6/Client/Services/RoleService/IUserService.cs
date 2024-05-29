namespace Project_GET_6.Client.Services.RoleService
{
    public interface IUserService
    {
        List<User> Users { get; set; }

        Task GetUsers();

        Task<User> GetUserWithUsername(string name);

        Task<HttpResponseMessage> CreateUser(User user);

        Task<HttpResponseMessage> UpdateUser(User user, string username);

        Task DeleteUser(string username);

		Task<User?> LoginUser(User user);
    }
}
