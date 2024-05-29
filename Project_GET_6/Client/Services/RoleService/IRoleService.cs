namespace Project_GET_6.Client.Services.RoleService
{
    public interface IRoleService
    {
        List<Role> Roles { get; set; }

        Task GetRoles();

        Task<Role> GetRoleWithName(string name);

        Task CreateRole(Role role);

		Task UpdateRole(Role role);

		Task DeleteRole(int id);
	}
}
