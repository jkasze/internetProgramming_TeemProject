using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace internetProgramming_TeemProject.Migrations
{
    public partial class add3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourse_Courses_courseId",
                table: "StudentCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourse_Students_studentId",
                table: "StudentCourse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentCourse",
                table: "StudentCourse");

            migrationBuilder.DropIndex(
                name: "IX_StudentCourse_courseId",
                table: "StudentCourse");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "StudentCourse");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "StudentCourse");

            migrationBuilder.RenameColumn(
                name: "studentId",
                table: "StudentCourse",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "courseId",
                table: "StudentCourse",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentCourse_studentId",
                table: "StudentCourse",
                newName: "IX_StudentCourse_StudentId");

            migrationBuilder.AlterColumn<Guid>(
                name: "StudentId",
                table: "StudentCourse",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CourseId",
                table: "StudentCourse",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentCourse",
                table: "StudentCourse",
                columns: new[] { "CourseId", "StudentId" });

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourse_Courses_CourseId",
                table: "StudentCourse",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourse_Students_StudentId",
                table: "StudentCourse",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourse_Courses_CourseId",
                table: "StudentCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourse_Students_StudentId",
                table: "StudentCourse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentCourse",
                table: "StudentCourse");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "StudentCourse",
                newName: "studentId");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "StudentCourse",
                newName: "courseId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentCourse_StudentId",
                table: "StudentCourse",
                newName: "IX_StudentCourse_studentId");

            migrationBuilder.AlterColumn<Guid>(
                name: "studentId",
                table: "StudentCourse",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<Guid>(
                name: "courseId",
                table: "StudentCourse",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "StudentCourse",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "StudentCourse",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentCourse",
                table: "StudentCourse",
                columns: new[] { "CourseId", "StudentId" });

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourse_courseId",
                table: "StudentCourse",
                column: "courseId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourse_Courses_courseId",
                table: "StudentCourse",
                column: "courseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourse_Students_studentId",
                table: "StudentCourse",
                column: "studentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
