namespace Project_GET_6.Server.Data
{
    public class DataContext : DbContext
    {   
        public DataContext(DbContextOptions<DataContext> options) : base(options) {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = 0, RoleName = "None" },
                new Role { RoleId = 1, RoleName = "Developer" },
                new Role { RoleId = 2, RoleName = "Project Manager" },
                new Role { RoleId = 3, RoleName = "Administrator" }

            );

            modelBuilder.Entity<User>().HasData(
                new User { 
                    Username = "pera123",
                    Password = "pera123",
                    Name = "Petar",
                    Surname = "Petrovic",
                    Email = "pera123@mail.com",
                    RoleId = 3
                },
                new User
                {
                    Username = "mika123",
                    Password = "mika123",
                    Name = "Milan",
                    Surname = "Milanovic",
                    Email = "mika123@mail.com",
                    RoleId = 2
                },
                new User
                {
                    Username = "zika123",
                    Password = "zika123",
                    Name = "Zivanko",
                    Surname = "Zivankovic",
                    Email = "zika123@mail.com",
                    RoleId = 1
                },
                new User
                {
                    Username = "nidza123",
                    Password = "nidza123",
                    Name = "Nikola",
                    Surname = "Nikolic",
                    Email = "nidza123@mail.com",
                    RoleId = 1
                },
                new User
                {
                    Username = "aca123",
                    Password = "aca123",
                    Name = "Aleksandar",
                    Surname = "Aleksandrovic",
                    Email = "aca123@mail.com",
                    RoleId = 1
                }

            );

            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    ProjectCode = "P1A",
                    ProjectName = "Test1",
                    ProjectManagerUsername = "mika123"
                },
                new Project
                {
                    ProjectCode = "P2A",
                    ProjectName = "Test2",
                    ProjectManagerUsername = "mika123"
                },
                new Project
                {
                    ProjectCode = "P3B",
                    ProjectName = "Test3",
                    ProjectManagerUsername = "mika123"
                }

            );

            modelBuilder.Entity<ProjectTask>().HasData(
                new ProjectTask
                {
                    ProjectTaskId = 1,
                    ParentProjectProjectCode = "P1A",
                    Status = 0,
                    Progress = 0.0,
                    Deadline = DateTime.Today,
                    Description = "Project Test1 Task 1",
                    AssigneeUsername = "zika123"
                },
                new ProjectTask
                {
                    ProjectTaskId = 2,
                    ParentProjectProjectCode = "P2A",
                    Status = 0,
                    Progress = 0.0,
                    Deadline = DateTime.Today,
                    Description = "Project Test1 Task 2",
                    AssigneeUsername = "zika123"
                },
                new ProjectTask
                {
                    ProjectTaskId = 3,
                    ParentProjectProjectCode = "P3B",
                    Status = 0,
                    Progress = 0.0,
                    Deadline = DateTime.Today,
                    Description = "Project Test1 Task 3",
                    AssigneeUsername = "zika123"
                },
                new ProjectTask
                {
                    ProjectTaskId = 4,
                    ParentProjectProjectCode = "P1A",
                    Status = 0,
                    Progress = 0.0,
                    Deadline = DateTime.Today,
                    Description = "Project Test2 Task 1",
                    AssigneeUsername = "aca123"
                }

            );


        }

        public DbSet<Role> Roles { get; set;}
        public DbSet<User> Users { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<ProjectTask> ProjectTasks { get; set; }
    }
}
