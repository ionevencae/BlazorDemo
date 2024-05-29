using Bunit;
using Project_GET_6.Client.Pages;
using Project_GET_6.Shared;
using Project_GET_6.Client.Services.RoleService;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Components;
using Bunit.TestDoubles;


namespace TestProject1
{
    public class UnitTest1 : TestContext
    {
        [Fact]
        public async Task Test1CreateProjectNoManagerAsync()
        {
            Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7141") });
            Services.AddSingleton<IUserService, UserService>();
            Services.AddSingleton<IRoleService, RoleService>();
            Services.AddSingleton<AuthService, AuthService>();
            Services.AddSingleton<IProjectService, ProjectService>();
            Services.AddSingleton<ILocalStorage, LocalStorage>();
            var projectsPage = RenderComponent<CreateProject>();
            Assert.False(await projectsPage.Instance.testCreateProject(new Project { ProjectCode = "qwerty12345", ProjectName = "qwerty12345", ProjectManagerUsername = "username12345" }));

        }

        [Fact]
        public async Task Test2CreateUserWrongDataAsync()
        {
            Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7141") });
            Services.AddSingleton<IUserService, UserService>();
            Services.AddSingleton<IRoleService, RoleService>();
            Services.AddSingleton<AuthService, AuthService>();
            Services.AddSingleton<IProjectService, ProjectService>();
            Services.AddSingleton<ILocalStorage, LocalStorage>();
            var projectsPage = RenderComponent<CreateUser>();
            Assert.False(await projectsPage.Instance.testCreateUser(new User { Username = "", Name = "", Surname = "surname12345", Password = "password12345", Email = "email12345", RoleId = 2 }));
            
        }
        
        [Fact]
        public async Task Test3CreateUserGoodDataAsync()
        {
            Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7141") });
            Services.AddSingleton<IUserService, UserService>();
            Services.AddSingleton<IRoleService, RoleService>();
            Services.AddSingleton<AuthService, AuthService>();
            Services.AddSingleton<IProjectService, ProjectService>();
            Services.AddSingleton<ILocalStorage, LocalStorage>();
            var projectsPage = RenderComponent<CreateUser>();
            Assert.True(await projectsPage.Instance.testCreateUser(new User { Username = "username12345", Name = "name12345", Surname = "surname12345", Password = "password12345", Email = "email12345", RoleId = 2 }));
            
        }

        [Fact]
        public async Task Test4CreateProjectWrongDataAsync()
        {
            Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7141") });
            Services.AddSingleton<IUserService, UserService>();
            Services.AddSingleton<IRoleService, RoleService>();
            Services.AddSingleton<AuthService, AuthService>();
            Services.AddSingleton<IProjectService, ProjectService>();
            Services.AddSingleton<ILocalStorage, LocalStorage>();
            var projectsPage = RenderComponent<CreateProject>();
            Assert.False(await projectsPage.Instance.testCreateProject(new Project { ProjectCode = "qwerty12345", ProjectName = "", ProjectManagerUsername = "username12345" }));
            
        }

        [Fact]
        public async Task Test5CreateProjectGoodDataAsync()
        {
            Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7141") });
            Services.AddSingleton<IUserService, UserService>();
            Services.AddSingleton<IRoleService, RoleService>();
            Services.AddSingleton<AuthService, AuthService>();
            Services.AddSingleton<IProjectService, ProjectService>();
            Services.AddSingleton<ILocalStorage, LocalStorage>();
            var projectsPage = RenderComponent<CreateProject>();
            Assert.True(await projectsPage.Instance.testCreateProject(new Project { ProjectCode = "qwerty12345", ProjectName = "qwerty12345", ProjectManagerUsername = "username12345" }));
            
        }

        [Fact]
        public async Task Test6CreateProjectSameProjectCodeAsync()
        {
            Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7141") });
            Services.AddSingleton<IUserService, UserService>();
            Services.AddSingleton<IRoleService, RoleService>();
            Services.AddSingleton<AuthService, AuthService>();
            Services.AddSingleton<IProjectService, ProjectService>();
            Services.AddSingleton<ILocalStorage, LocalStorage>();
            var projectsPage = RenderComponent<CreateProject>();
            Assert.False(await projectsPage.Instance.testCreateProject(new Project { ProjectCode = "qwerty12345", ProjectName = "qwerty12345", ProjectManagerUsername = "username12345" }));
            
        }

        [Fact]
        public async Task Test7EditUserGoodDataAsync()
        {
            Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7141") });
            Services.AddSingleton<IUserService, UserService>();
            Services.AddSingleton<IRoleService, RoleService>();
            Services.AddSingleton<AuthService, AuthService>();
            Services.AddSingleton<IProjectService, ProjectService>();
            Services.AddSingleton<IProjectTaskService, ProjectTaskService>();
            Services.AddSingleton<ILocalStorage, LocalStorage>();
            var projectsPage = RenderComponent<EditUser>();
            Assert.True(await projectsPage.Instance.testEditUser(new User { Username = "username12345", Name = "name12346", Surname = "surname12346", Password = "password12345", Email = "email12345", RoleId = 2 }));

        }

        [Fact]
        public async Task Test8EditUserWrongDataAsync()
        {
            Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7141") });
            Services.AddSingleton<IUserService, UserService>();
            Services.AddSingleton<IRoleService, RoleService>();
            Services.AddSingleton<AuthService, AuthService>();
            Services.AddSingleton<IProjectService, ProjectService>();
            Services.AddSingleton<IProjectTaskService, ProjectTaskService>();
            Services.AddSingleton<ILocalStorage, LocalStorage>();
            var projectsPage = RenderComponent<EditUser>();
            Assert.False(await projectsPage.Instance.testEditUser(new User { Username = "username123456789", Name = "name12346", Surname = "surname12346", Password = "password12345", Email = "email12345", RoleId = 2 }));

        }

        [Fact]
        public async Task Test9CreateTaskWrongProjectAsync()
        {
            Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7141") });
            Services.AddSingleton<IUserService, UserService>();
            Services.AddSingleton<IRoleService, RoleService>();
            Services.AddSingleton<AuthService, AuthService>();
            Services.AddSingleton<ILocalStorage, LocalStorage>();
            Services.AddSingleton<IProjectService, ProjectService>();
            Services.AddSingleton<IProjectTaskService, ProjectTaskService>();
            Services.AddSingleton<IPaginationService, PaginationService>();
            var projectsPage = RenderComponent<AdminstratorTasks>();
            Assert.False(await projectsPage.Instance.testCreateTask(new ProjectTask { ParentProjectProjectCode = "qwerty12345", AssigneeUsername = "blabla123", Deadline = DateTime.Today, Progress = 0,  Status = 0, Description = "description"}));

        }

        [Fact]
        public async Task Test10CreateTaskWrongUserAsync()
        {
            Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7141") });
            Services.AddSingleton<IUserService, UserService>();
            Services.AddSingleton<IRoleService, RoleService>();
            Services.AddSingleton<AuthService, AuthService>();
            Services.AddSingleton<IProjectService, ProjectService>();
            Services.AddSingleton<ILocalStorage, LocalStorage>();
            Services.AddSingleton<IProjectTaskService, ProjectTaskService>();
            Services.AddSingleton<IPaginationService, PaginationService>();
            var projectsPage = RenderComponent<AdminstratorTasks>();
            Assert.False(await projectsPage.Instance.testCreateTask(new ProjectTask { ParentProjectProjectCode = "qwerty12345679", AssigneeUsername = "blabla123", Deadline = DateTime.Today, Progress = 0,  Status = 0, Description = "description"}));

        }

        [Fact]
        public async Task Test11CreateTaskGoodDataAsync()
        {
            Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7141") });
            Services.AddSingleton<IUserService, UserService>();
            Services.AddSingleton<IRoleService, RoleService>();
            Services.AddSingleton<AuthService, AuthService>();
            Services.AddSingleton<IProjectService, ProjectService>();
            Services.AddSingleton<ILocalStorage, LocalStorage>();
            Services.AddSingleton<IProjectTaskService, ProjectTaskService>();
            Services.AddSingleton<IPaginationService, PaginationService>();
            var projectsPage = RenderComponent<AdminstratorTasks>();
            Assert.True(await projectsPage.Instance.testCreateTask(new ProjectTask { ParentProjectProjectCode = "qwerty12345", AssigneeUsername = "username12345", Deadline = DateTime.Today, Progress = 0,  Status = 0, Description = "description"}));

        }


        [Fact]
        public async Task Test12DeleteUserHasTasksAsync()
        {
            Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7141") });
            Services.AddSingleton<IUserService, UserService>();
            Services.AddSingleton<IRoleService, RoleService>();
            Services.AddSingleton<AuthService, AuthService>();
            Services.AddSingleton<IProjectService, ProjectService>();
            Services.AddSingleton<IProjectTaskService, ProjectTaskService>();
            Services.AddSingleton<ILocalStorage, LocalStorage>();
            var projectsPage = RenderComponent<EditUser>();
            Assert.False(await projectsPage.Instance.testDeleteUser(new User { Username = "username12345", Name = "name12346", Surname = "surname12346", Password = "password12345", Email = "email12345", RoleId = 2 }));

        }


        [Fact]
        public async Task Test13DeleteProjectHasTasksAsync()
        {
            Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7141") });
            Services.AddSingleton<IUserService, UserService>();
            Services.AddSingleton<IRoleService, RoleService>();
            Services.AddSingleton<AuthService, AuthService>();
            Services.AddSingleton<IProjectService, ProjectService>();
            Services.AddSingleton<IProjectTaskService, ProjectTaskService>();
            Services.AddSingleton<ILocalStorage, LocalStorage>();
            var projectsPage = RenderComponent<EditProject>();
            Assert.False(await projectsPage.Instance.testDeleteProject(new Project { ProjectCode = "qwerty12345", ProjectName = "qwerty12345", ProjectManagerUsername = "username12345" }));

        }


        [Fact]
        public async Task Test14EditTaskGoodDataAsync()
        {
            Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7141") });
            Services.AddSingleton<IUserService, UserService>();
            Services.AddSingleton<IRoleService, RoleService>();
            Services.AddSingleton<AuthService, AuthService>();
            Services.AddSingleton<IProjectService, ProjectService>();
            Services.AddSingleton<ILocalStorage, LocalStorage>();
            Services.AddSingleton<IProjectTaskService, ProjectTaskService>();
            Services.AddSingleton<IPaginationService, PaginationService>();
            var projectsPage = RenderComponent<AdminstratorTasks>();
            Assert.True(await projectsPage.Instance.testEditTask(new ProjectTask { ParentProjectProjectCode = "qwerty12345", AssigneeUsername = "username12345", Deadline = DateTime.Today, Progress = 0, Status = 0, Description = "description" }));

        }

        [Fact]
        public async Task Test15DeleteTaskGoodDataAsync()
        {
            Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7141") });
            Services.AddSingleton<IUserService, UserService>();
            Services.AddSingleton<IRoleService, RoleService>();
            Services.AddSingleton<AuthService, AuthService>();
            Services.AddSingleton<IProjectService, ProjectService>();
            Services.AddSingleton<ILocalStorage, LocalStorage>();
            Services.AddSingleton<IProjectTaskService, ProjectTaskService>();
            Services.AddSingleton<IPaginationService, PaginationService>();
            var projectsPage = RenderComponent<AdminstratorTasks>();
            Assert.True(await projectsPage.Instance.testDeleteTask(new ProjectTask { ParentProjectProjectCode = "qwerty12345", AssigneeUsername = "username12345", Deadline = DateTime.Today, Progress = 0, Status = 0, Description = "description" }));

        }


        [Fact]
        public async Task Test16DeleteProjectGoodDataAsync()
        {
            Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7141") });
            Services.AddSingleton<IUserService, UserService>();
            Services.AddSingleton<IRoleService, RoleService>();
            Services.AddSingleton<AuthService, AuthService>();
            Services.AddSingleton<IProjectService, ProjectService>();
            Services.AddSingleton<IProjectTaskService, ProjectTaskService>();
            Services.AddSingleton<ILocalStorage, LocalStorage>();
            var projectsPage = RenderComponent<EditProject>();
            Assert.True(await projectsPage.Instance.testDeleteProject(new Project { ProjectCode = "qwerty12345", ProjectName = "qwerty12345", ProjectManagerUsername = "username12345" }));

        }


        [Fact]
        public async Task Test17DeleteUserGoodDataAsync()
        {
            Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7141") });
            Services.AddSingleton<IUserService, UserService>();
            Services.AddSingleton<IRoleService, RoleService>();
            Services.AddSingleton<AuthService, AuthService>();
            Services.AddSingleton<IProjectService, ProjectService>();
            Services.AddSingleton<IProjectTaskService, ProjectTaskService>();
            Services.AddSingleton<ILocalStorage, LocalStorage>();
            var projectsPage = RenderComponent<EditUser>();
            Assert.True(await projectsPage.Instance.testDeleteUser(new User { Username = "username12345", Name = "name12346", Surname = "surname12346", Password = "password12345", Email = "email12345", RoleId = 2 }));

        }

    }
}