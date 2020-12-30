using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace internetProgramming_TeemProject.Migrations
{
    public partial class account8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Password", "Type", "UserName" },
                values: new object[] { new Guid("4741a63f-aad1-4a38-8ac9-32e11689c32b"), "20180101", 0, "20181010" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("4741a63f-aad1-4a38-8ac9-32e11689c32b"));
        }
    }
}
