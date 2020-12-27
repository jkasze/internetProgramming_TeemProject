using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace internetProgramming_TeemProject.Migrations
{
    public partial class addStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Students_StudentId1",
                table: "Enrollments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StudentClass",
                table: "Students");

            migrationBuilder.AlterColumn<string>(
                name: "StudentName",
                table: "Students",
                type: "TEXT",
                maxLength: 4,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Students",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "InstituteId",
                table: "Students",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "StudentId1",
                table: "Enrollments",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "InstituteId", "StudentName", "StudentNum" },
                values: new object[] { new Guid("ffa9e244-2743-43b4-8d62-b162700b78d7"), new Guid("5efc910b-2f45-43df-afee-620d40542853"), "封不觉", 20180101L });

            migrationBuilder.CreateIndex(
                name: "IX_Students_InstituteId",
                table: "Students",
                column: "InstituteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Students_StudentId1",
                table: "Enrollments",
                column: "StudentId1",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Institutes_InstituteId",
                table: "Students",
                column: "InstituteId",
                principalTable: "Institutes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Students_StudentId1",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Institutes_InstituteId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_InstituteId",
                table: "Students");

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyColumnType: "TEXT",
                keyValue: new Guid("ffa9e244-2743-43b4-8d62-b162700b78d7"));

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "InstituteId",
                table: "Students");

            migrationBuilder.AlterColumn<string>(
                name: "StudentName",
                table: "Students",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 4);

            migrationBuilder.AddColumn<long>(
                name: "StudentId",
                table: "Students",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<long>(
                name: "StudentClass",
                table: "Students",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<long>(
                name: "StudentId1",
                table: "Enrollments",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Students_StudentId1",
                table: "Enrollments",
                column: "StudentId1",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
