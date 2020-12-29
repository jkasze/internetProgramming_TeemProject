using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace internetProgramming_TeemProject.Migrations
{
    public partial class course : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CourseId",
                table: "Teachers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CourseId",
                table: "Students",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CourseName = table.Column<string>(type: "TEXT", nullable: true),
                    StartTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CourseTime = table.Column<int>(type: "INTEGER", nullable: false),
                    TheoryPeriod = table.Column<int>(type: "INTEGER", nullable: false),
                    LabPeriod = table.Column<int>(type: "INTEGER", nullable: false),
                    Information = table.Column<string>(type: "TEXT", nullable: true),
                    PPTName = table.Column<string>(type: "TEXT", nullable: true),
                    LabName = table.Column<string>(type: "TEXT", nullable: true),
                    LabStep = table.Column<string>(type: "TEXT", nullable: true),
                    RefDocment = table.Column<string>(type: "TEXT", nullable: true),
                    LastSubmit = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ExTimes = table.Column<int>(type: "INTEGER", nullable: false),
                    ExName = table.Column<string>(type: "TEXT", nullable: true),
                    ExInfor = table.Column<string>(type: "TEXT", nullable: true),
                    ExStart = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ExSubmit = table.Column<DateTime>(type: "TEXT", nullable: false),
                    InstituteId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Institutes_InstituteId",
                        column: x => x.InstituteId,
                        principalTable: "Institutes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseName", "CourseTime", "ExInfor", "ExName", "ExStart", "ExSubmit", "ExTimes", "Information", "InstituteId", "LabName", "LabPeriod", "LabStep", "LastSubmit", "PPTName", "RefDocment", "StartTime", "TheoryPeriod" },
                values: new object[] { new Guid("ef59ce64-c4e7-458d-9b88-fec5a07b14a8"), "互联网程序设计", 0, "", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "HTML+CSS+JavaScript+ASP.NET", null, "", 180, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 48 });

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_CourseId",
                table: "Teachers",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_CourseId",
                table: "Students",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_InstituteId",
                table: "Courses",
                column: "InstituteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Courses_CourseId",
                table: "Students",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Courses_CourseId",
                table: "Teachers",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Courses_CourseId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Courses_CourseId",
                table: "Teachers");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_CourseId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Students_CourseId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Students");
        }
    }
}
