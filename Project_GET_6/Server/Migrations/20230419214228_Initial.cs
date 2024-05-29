using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project_GET_6.Server.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Username);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId");
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectManagerUsername = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectCode);
                    table.ForeignKey(
                        name: "FK_Projects_Users_ProjectManagerUsername",
                        column: x => x.ProjectManagerUsername,
                        principalTable: "Users",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTasks",
                columns: table => new
                {
                    ProjectTaskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Progress = table.Column<double>(type: "float", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentProjectProjectCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AssigneeUsername = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTasks", x => x.ProjectTaskId);
                    table.ForeignKey(
                        name: "FK_ProjectTasks_Projects_ParentProjectProjectCode",
                        column: x => x.ParentProjectProjectCode,
                        principalTable: "Projects",
                        principalColumn: "ProjectCode");
                    table.ForeignKey(
                        name: "FK_ProjectTasks_Users_AssigneeUsername",
                        column: x => x.AssigneeUsername,
                        principalTable: "Users",
                        principalColumn: "Username");
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { 0, "None" },
                    { 1, "Developer" },
                    { 2, "Project Manager" },
                    { 3, "Administrator" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Username", "Email", "Name", "Password", "RoleId", "Surname" },
                values: new object[,]
                {
                    { "aca123", "aca123@mail.com", "Aleksandar", "aca123", 1, "Aleksandrovic" },
                    { "mika123", "mika123@mail.com", "Milan", "mika123", 2, "Milanovic" },
                    { "nidza123", "nidza123@mail.com", "Nikola", "nidza123", 1, "Nikolic" },
                    { "pera123", "pera123@mail.com", "Petar", "pera123", 3, "Petrovic" },
                    { "zika123", "zika123@mail.com", "Zivanko", "zika123", 1, "Zivankovic" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectCode", "ProjectManagerUsername", "ProjectName" },
                values: new object[,]
                {
                    { "P1A", "mika123", "Test1" },
                    { "P2A", "mika123", "Test2" },
                    { "P3B", "mika123", "Test3" }
                });

            migrationBuilder.InsertData(
                table: "ProjectTasks",
                columns: new[] { "ProjectTaskId", "AssigneeUsername", "Deadline", "Description", "ParentProjectProjectCode", "Progress", "Status" },
                values: new object[,]
                {
                    { 1, "zika123", new DateTime(2023, 4, 19, 0, 0, 0, 0, DateTimeKind.Local), "Project Test1 Task 1", "P1A", 0.0, 0 },
                    { 2, "zika123", new DateTime(2023, 4, 19, 0, 0, 0, 0, DateTimeKind.Local), "Project Test1 Task 2", "P2A", 0.0, 0 },
                    { 3, "zika123", new DateTime(2023, 4, 19, 0, 0, 0, 0, DateTimeKind.Local), "Project Test1 Task 3", "P3B", 0.0, 0 },
                    { 4, "aca123", new DateTime(2023, 4, 19, 0, 0, 0, 0, DateTimeKind.Local), "Project Test2 Task 1", "P1A", 0.0, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectManagerUsername",
                table: "Projects",
                column: "ProjectManagerUsername");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTasks_AssigneeUsername",
                table: "ProjectTasks",
                column: "AssigneeUsername");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTasks_ParentProjectProjectCode",
                table: "ProjectTasks",
                column: "ParentProjectProjectCode");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectTasks");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
