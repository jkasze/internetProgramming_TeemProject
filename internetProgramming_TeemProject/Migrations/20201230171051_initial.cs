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
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    Type = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

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
                    ExSubmit = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Institutes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Num = table.Column<string>(type: "TEXT", maxLength: 3, nullable: true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 4, nullable: true),
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
                    StudentName = table.Column<string>(type: "TEXT", maxLength: 4, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Institutes_InstituteId",
                        column: x => x.InstituteId,
                        principalTable: "Institutes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    InstituteId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TeacherNum = table.Column<long>(type: "INTEGER", nullable: false),
                    TeacherName = table.Column<string>(type: "TEXT", maxLength: 4, nullable: true),
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourse",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    StudentId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentCourse_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Password", "Type", "UserName" },
                values: new object[] { new Guid("4741a63f-aad1-4a38-8ac9-32e11689c32b"), "20180101", 0, "20181010" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseName", "CourseTime", "ExInfor", "ExName", "ExStart", "ExSubmit", "ExTimes", "Information", "LabName", "LabPeriod", "LabStep", "LastSubmit", "PPTName", "RefDocment", "StartTime", "TheoryPeriod" },
                values: new object[] { new Guid("ef59ce64-c4e7-458d-9b88-fec5a07b14a8"), "互联网程序设计", 0, "", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "HTML+CSS+JavaScript+ASP.NET", "", 180, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 48 });

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

            migrationBuilder.InsertData(
                table: "StudentCourse",
                columns: new[] { "Id", "StudentId" },
                values: new object[] { new Guid("a57d2b4e-6fd9-4b9a-912d-ab9902043612"), new Guid("ffa9e244-2743-43b4-8d62-b162700b78d7") });

            migrationBuilder.InsertData(
                table: "StudentCourse",
                columns: new[] { "Id", "StudentId" },
                values: new object[] { new Guid("76e77dc8-dfb0-4cbb-9830-dc0ac3d5b98b"), new Guid("9011e45a-a408-bb72-50eb-d5ee66875dd3") });

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourse_StudentId",
                table: "StudentCourse",
                column: "StudentId");

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
                name: "Courses");

            migrationBuilder.DropTable(
                name: "StudentCourse");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Institutes");
        }
    }
}
