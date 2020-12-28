using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace internetProgramming_TeemProject.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<long>(type: "INTEGER", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    Type = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "Institutes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Num = table.Column<string>(type: "TEXT", maxLength: 3, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 4, nullable: false),
                    Introduction = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institutes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    InstituteId = table.Column<Guid>(type: "TEXT", nullable: false),
                    StudentNum = table.Column<int>(type: "INTEGER", maxLength: 8, nullable: false),
                    StudentName = table.Column<string>(type: "TEXT", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Institutes_InstituteId",
                        column: x => x.InstituteId,
                        principalTable: "Institutes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    InstituteId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TeacherNum = table.Column<long>(type: "INTEGER", nullable: false),
                    TeacherName = table.Column<string>(type: "TEXT", maxLength: 4, nullable: false),
                    TeacherIntroduction = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_Institutes_InstituteId",
                        column: x => x.InstituteId,
                        principalTable: "Institutes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Institutes",
                columns: new[] { "Id", "Introduction", "Name", "Num" },
                values: new object[] { new Guid("bbdee09c-089b-4d30-bece-44df5923716c"), "西北大学信息科学与技术学院成立于2005年5月，是由前计算机科学系和电子科学系为主体整合而成。", "信息学院", "01" });

            migrationBuilder.InsertData(
                table: "Institutes",
                columns: new[] { "Id", "Introduction", "Name", "Num" },
                values: new object[] { new Guid("6fb600c1-9011-4fd7-9234-881379716440"), "西北大学法学教育始于1907年的陕西法政学堂，是中国现代法学教育中历史最为悠久的学校之一。", "法学院", "02" });

            migrationBuilder.InsertData(
                table: "Institutes",
                columns: new[] { "Id", "Introduction", "Name", "Num" },
                values: new object[] { new Guid("5efc910b-2f45-43df-afee-620d40542853"), "西北大学历史学院其前身西北大学文博学院（1988年设立）源自于1937年设立的西北联合大学历史系，许寿裳任系主任。", "历史学院", "03" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "InstituteId", "StudentName", "StudentNum" },
                values: new object[] { new Guid("ffa9e244-2743-43b4-8d62-b162700b78d7"), new Guid("5efc910b-2f45-43df-afee-620d40542853"), "封不觉", 20180101 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "InstituteId", "StudentName", "StudentNum" },
                values: new object[] { new Guid("e48f8f2f-22d6-cb6e-cdc2-4c92a09fdfcd"), new Guid("5efc910b-2f45-43df-afee-620d40542853"), "封不", 20180102 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "InstituteId", "StudentName", "StudentNum" },
                values: new object[] { new Guid("9011e45a-a408-bb72-50eb-d5ee66875dd3"), new Guid("5efc910b-2f45-43df-afee-620d40542853"), "封觉", 20180103 });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "InstituteId", "TeacherIntroduction", "TeacherName", "TeacherNum" },
                values: new object[] { new Guid("ca268a19-0f39-4d8b-b8d6-5bace54f8027"), new Guid("bbdee09c-089b-4d30-bece-44df5923716c"), "", "何路", 201401L });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "InstituteId", "TeacherIntroduction", "TeacherName", "TeacherNum" },
                values: new object[] { new Guid("7346d7ba-d17c-9014-05ae-fb0169ed0a13"), new Guid("bbdee09c-089b-4d30-bece-44df5923716c"), "", "耿国华", 201402L });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "InstituteId", "TeacherIntroduction", "TeacherName", "TeacherNum" },
                values: new object[] { new Guid("494710f6-6202-fbe9-d827-1dafde50daa2"), new Guid("bbdee09c-089b-4d30-bece-44df5923716c"), null, "徐彩霞", 201403L });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "InstituteId", "TeacherIntroduction", "TeacherName", "TeacherNum" },
                values: new object[] { new Guid("2ea277d6-50cc-025e-0935-8646f06ba2bd"), new Guid("6fb600c1-9011-4fd7-9234-881379716440"), "", "任瀚宇", 200001L });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "InstituteId", "TeacherIntroduction", "TeacherName", "TeacherNum" },
                values: new object[] { new Guid("47b70abc-98b8-4fdc-b9fa-5dd6716f6e6b"), new Guid("5efc910b-2f45-43df-afee-620d40542853"), "", "王豪", 201501L });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "InstituteId", "TeacherIntroduction", "TeacherName", "TeacherNum" },
                values: new object[] { new Guid("5d27fb1c-f235-e1ce-fe63-ae6e664a27fa"), new Guid("5efc910b-2f45-43df-afee-620d40542853"), "", "郭孟源", 201502L });

            migrationBuilder.CreateIndex(
                name: "IX_Students_InstituteId",
                table: "Students",
                column: "InstituteId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_InstituteId",
                table: "Teachers",
                column: "InstituteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Institutes");
        }
    }
}
