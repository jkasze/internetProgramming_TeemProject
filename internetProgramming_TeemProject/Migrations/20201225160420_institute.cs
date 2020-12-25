using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace internetProgramming_TeemProject.Migrations
{
    public partial class institute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Introduction",
                table: "Teachers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Num",
                table: "Institutes",
                type: "TEXT",
                maxLength: 3,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Institutes",
                keyColumn: "Id",
                keyValue: new Guid("5efc910b-2f45-43df-afee-620d40542853"),
                column: "Num",
                value: "03");

            migrationBuilder.UpdateData(
                table: "Institutes",
                keyColumn: "Id",
                keyValue: new Guid("6fb600c1-9011-4fd7-9234-881379716440"),
                column: "Num",
                value: "02");

            migrationBuilder.UpdateData(
                table: "Institutes",
                keyColumn: "Id",
                keyValue: new Guid("bbdee09c-089b-4d30-bece-44df5923716c"),
                column: "Num",
                value: "01");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Introduction",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Num",
                table: "Institutes");
        }
    }
}
