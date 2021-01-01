using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace internetProgramming_TeemProject.Migrations
{
    public partial class account : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("4741a63f-aad1-4a38-8ac9-32e11689c32b"),
                column: "Password",
                value: "20180101");

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Password", "Type", "UserName" },
                values: new object[] { new Guid("751b70ba-e874-48aa-a112-318be91dcf20"), "admin", 2, "admin" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Password", "Type", "UserName" },
                values: new object[] { new Guid("01dc7bc9-0654-42df-8a15-bef54aa117d6"), "201401", 1, "201401" });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("494710f6-6202-fbe9-d827-1dafde50daa2"),
                column: "TeacherIntroduction",
                value: "");

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("7346d7ba-d17c-9014-05ae-fb0169ed0a13"),
                column: "TeacherIntroduction",
                value: "西北大学信息科学与技术学院副院长，陕西省计算机学会副理事长，陕西省计算机教育学会副理事长，全国高等院校计算机基础教育研究会副会长");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("01dc7bc9-0654-42df-8a15-bef54aa117d6"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("751b70ba-e874-48aa-a112-318be91dcf20"));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("4741a63f-aad1-4a38-8ac9-32e11689c32b"),
                column: "Password",
                value: "20181010");

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("494710f6-6202-fbe9-d827-1dafde50daa2"),
                column: "TeacherIntroduction",
                value: null);

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("7346d7ba-d17c-9014-05ae-fb0169ed0a13"),
                column: "TeacherIntroduction",
                value: "");
        }
    }
}
