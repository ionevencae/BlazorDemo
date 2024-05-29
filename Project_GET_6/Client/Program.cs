global using Project_GET_6.Client.Services.RoleService;
global using Project_GET_6.Shared;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Project_GET_6.Client;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IPaginationService, PaginationService>();
builder.Services.AddScoped<IProjectTaskService, ProjectTaskService>();
builder.Services.AddSingleton<ILocalStorage, LocalStorage>();
builder.Services.AddScoped<AuthService>();

await builder.Build().RunAsync();
