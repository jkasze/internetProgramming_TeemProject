using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace internetProgramming_TeemProject.Migrations
{
    public partial class debug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_Courses_CourseId",
                table: "StudentCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_Students_StudentId",
                table: "StudentCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherCourses_Courses_CourseId",
                table: "TeacherCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherCourses_Teachers_TeacherId",
                table: "TeacherCourses");

            migrationBuilder.AlterColumn<string>(
                name: "TeacherNum",
                table: "Teachers",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "StudentNum",
                table: "Students",
                type: "TEXT",
                maxLength: 8,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldMaxLength: 8);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("9011e45a-a408-bb72-50eb-d5ee66875dd3"),
                column: "StudentNum",
                value: "20180103");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("e48f8f2f-22d6-cb6e-cdc2-4c92a09fdfcd"),
                column: "StudentNum",
                value: "20180102");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("ffa9e244-2743-43b4-8d62-b162700b78d7"),
                column: "StudentNum",
                value: "20180101");

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("2ea277d6-50cc-025e-0935-8646f06ba2bd"),
                column: "TeacherNum",
                value: "200001");

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("47b70abc-98b8-4fdc-b9fa-5dd6716f6e6b"),
                column: "TeacherNum",
                value: "201501");

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("494710f6-6202-fbe9-d827-1dafde50daa2"),
                column: "TeacherNum",
                value: "201403");

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("5d27fb1c-f235-e1ce-fe63-ae6e664a27fa"),
                column: "TeacherNum",
                value: "201502");

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("7346d7ba-d17c-9014-05ae-fb0169ed0a13"),
                column: "TeacherNum",
                value: "201402");

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("ca268a19-0f39-4d8b-b8d6-5bace54f8027"),
                column: "TeacherNum",
                value: "201401");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_Courses_CourseId",
                table: "StudentCourses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_Students_StudentId",
                table: "StudentCourses",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherCourses_Courses_CourseId",
                table: "TeacherCourses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherCourses_Teachers_TeacherId",
                table: "TeacherCourses",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_Courses_CourseId",
                table: "StudentCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_Students_StudentId",
                table: "StudentCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherCourses_Courses_CourseId",
                table: "TeacherCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherCourses_Teachers_TeacherId",
                table: "TeacherCourses");

            migrationBuilder.AlterColumn<long>(
                name: "TeacherNum",
                table: "Teachers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StudentNum",
                table: "Students",
                type: "INTEGER",
                maxLength: 8,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 8,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("9011e45a-a408-bb72-50eb-d5ee66875dd3"),
                column: "StudentNum",
                value: 20180103);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("e48f8f2f-22d6-cb6e-cdc2-4c92a09fdfcd"),
                column: "StudentNum",
                value: 20180102);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("ffa9e244-2743-43b4-8d62-b162700b78d7"),
                column: "StudentNum",
                value: 20180101);

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("2ea277d6-50cc-025e-0935-8646f06ba2bd"),
                column: "TeacherNum",
                value: 200001L);

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("47b70abc-98b8-4fdc-b9fa-5dd6716f6e6b"),
                column: "TeacherNum",
                value: 201501L);

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("494710f6-6202-fbe9-d827-1dafde50daa2"),
                column: "TeacherNum",
                value: 201403L);

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("5d27fb1c-f235-e1ce-fe63-ae6e664a27fa"),
                column: "TeacherNum",
                value: 201502L);

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("7346d7ba-d17c-9014-05ae-fb0169ed0a13"),
                column: "TeacherNum",
                value: 201402L);

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("ca268a19-0f39-4d8b-b8d6-5bace54f8027"),
                column: "TeacherNum",
                value: 201401L);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_Courses_CourseId",
                table: "StudentCourses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_Students_StudentId",
                table: "StudentCourses",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherCourses_Courses_CourseId",
                table: "TeacherCourses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherCourses_Teachers_TeacherId",
                table: "TeacherCourses",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
