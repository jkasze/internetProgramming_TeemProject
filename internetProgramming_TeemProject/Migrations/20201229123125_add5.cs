using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace internetProgramming_TeemProject.Migrations
{
    public partial class add5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "StudentCourse",
                columns: new[] { "CourseId", "StudentId" },
                values: new object[] { new Guid("ef59ce64-c4e7-458d-9b88-fec5a07b14a8"), new Guid("9011e45a-a408-bb72-50eb-d5ee66875dd3") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StudentCourse",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { new Guid("ef59ce64-c4e7-458d-9b88-fec5a07b14a8"), new Guid("9011e45a-a408-bb72-50eb-d5ee66875dd3") });
        }
    }
}
