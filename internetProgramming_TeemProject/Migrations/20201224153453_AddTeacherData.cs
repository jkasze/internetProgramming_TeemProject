using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace internetProgramming_TeemProject.Migrations
{
    public partial class AddTeacherData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("47b70abc-98b8-4fdc-b9fa-5dd6716f6e6b"),
                column: "TeacherName",
                value: "王豪");

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Gender", "InstituteId", "TeacherName", "TeacherNo", "TeacherNum" },
                values: new object[] { new Guid("7346d7ba-d17c-9014-05ae-fb0169ed0a13"), 2, new Guid("bbdee09c-089b-4d30-bece-44df5923716c"), "耿国华", "2", 201402L });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Gender", "InstituteId", "TeacherName", "TeacherNo", "TeacherNum" },
                values: new object[] { new Guid("494710f6-6202-fbe9-d827-1dafde50daa2"), 2, new Guid("bbdee09c-089b-4d30-bece-44df5923716c"), "徐彩霞", "3", 201403L });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Gender", "InstituteId", "TeacherName", "TeacherNo", "TeacherNum" },
                values: new object[] { new Guid("5d27fb1c-f235-e1ce-fe63-ae6e664a27fa"), 1, new Guid("5efc910b-2f45-43df-afee-620d40542853"), "郭孟源", "2", 201502L });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Gender", "InstituteId", "TeacherName", "TeacherNo", "TeacherNum" },
                values: new object[] { new Guid("2ea277d6-50cc-025e-0935-8646f06ba2bd"), 1, new Guid("6fb600c1-9011-4fd7-9234-881379716440"), "任瀚宇", "1", 200001L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("2ea277d6-50cc-025e-0935-8646f06ba2bd"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("494710f6-6202-fbe9-d827-1dafde50daa2"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("5d27fb1c-f235-e1ce-fe63-ae6e664a27fa"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("7346d7ba-d17c-9014-05ae-fb0169ed0a13"));

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("47b70abc-98b8-4fdc-b9fa-5dd6716f6e6b"),
                column: "TeacherName",
                value: "何路");
        }
    }
}
