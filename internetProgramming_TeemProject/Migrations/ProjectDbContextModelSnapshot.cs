﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using internetProgramming_TeemProject.Data;

namespace internetProgramming_TeemProject.Migrations
{
    [DbContext(typeof(ProjectDbContext))]
    partial class ProjectDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("internetProgramming_TeemProject.Entities.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4741a63f-aad1-4a38-8ac9-32e11689c32b"),
                            Password = "20181010",
                            Type = 0,
                            UserName = "20180101"
                        });
                });

            modelBuilder.Entity("internetProgramming_TeemProject.Entities.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("CourseName")
                        .HasColumnType("TEXT");

                    b.Property<int>("CourseTime")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ExInfor")
                        .HasColumnType("TEXT");

                    b.Property<string>("ExName")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ExStart")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ExSubmit")
                        .HasColumnType("TEXT");

                    b.Property<int>("ExTimes")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Information")
                        .HasColumnType("TEXT");

                    b.Property<string>("LabName")
                        .HasColumnType("TEXT");

                    b.Property<int>("LabPeriod")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LabStep")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastSubmit")
                        .HasColumnType("TEXT");

                    b.Property<string>("PPTName")
                        .HasColumnType("TEXT");

                    b.Property<string>("RefDocment")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("TheoryPeriod")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ef59ce64-c4e7-458d-9b88-fec5a07b14a8"),
                            CourseName = "互联网程序设计",
                            CourseTime = 0,
                            ExInfor = "",
                            ExName = "",
                            ExStart = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ExSubmit = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ExTimes = 1,
                            Information = "HTML+CSS+JavaScript+ASP.NET",
                            LabName = "",
                            LabPeriod = 180,
                            LabStep = "",
                            LastSubmit = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PPTName = "",
                            RefDocment = "",
                            StartTime = new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TheoryPeriod = 48
                        });
                });

            modelBuilder.Entity("internetProgramming_TeemProject.Entities.Institute", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Introduction")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(4)
                        .HasColumnType("TEXT");

                    b.Property<string>("Num")
                        .HasMaxLength(3)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Institutes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("bbdee09c-089b-4d30-bece-44df5923716c"),
                            Introduction = "西北大学信息科学与技术学院成立于2005年5月，是由前计算机科学系和电子科学系为主体整合而成。",
                            Name = "信息学院",
                            Num = "01"
                        },
                        new
                        {
                            Id = new Guid("6fb600c1-9011-4fd7-9234-881379716440"),
                            Introduction = "西北大学法学教育始于1907年的陕西法政学堂，是中国现代法学教育中历史最为悠久的学校之一。",
                            Name = "法学院",
                            Num = "02"
                        },
                        new
                        {
                            Id = new Guid("5efc910b-2f45-43df-afee-620d40542853"),
                            Introduction = "西北大学历史学院其前身西北大学文博学院（1988年设立）源自于1937年设立的西北联合大学历史系，许寿裳任系主任。",
                            Name = "历史学院",
                            Num = "03"
                        });
                });

            modelBuilder.Entity("internetProgramming_TeemProject.Entities.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("InstituteId")
                        .HasColumnType("TEXT");

                    b.Property<string>("StudentName")
                        .HasMaxLength(4)
                        .HasColumnType("TEXT");

                    b.Property<string>("StudentNum")
                        .HasMaxLength(8)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("InstituteId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ffa9e244-2743-43b4-8d62-b162700b78d7"),
                            InstituteId = new Guid("5efc910b-2f45-43df-afee-620d40542853"),
                            StudentName = "封不觉",
                            StudentNum = "20180101"
                        },
                        new
                        {
                            Id = new Guid("e48f8f2f-22d6-cb6e-cdc2-4c92a09fdfcd"),
                            InstituteId = new Guid("5efc910b-2f45-43df-afee-620d40542853"),
                            StudentName = "封不",
                            StudentNum = "20180102"
                        },
                        new
                        {
                            Id = new Guid("9011e45a-a408-bb72-50eb-d5ee66875dd3"),
                            InstituteId = new Guid("5efc910b-2f45-43df-afee-620d40542853"),
                            StudentName = "封觉",
                            StudentNum = "20180103"
                        });
                });

            modelBuilder.Entity("internetProgramming_TeemProject.Entities.StudentCourse", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ExPoints")
                        .HasColumnType("TEXT");

                    b.Property<string>("LabPoints")
                        .HasColumnType("TEXT");

                    b.Property<string>("MainPoints")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentCourses");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a57d2b4e-6fd9-4b9a-912d-ab9902043612"),
                            CourseId = new Guid("ef59ce64-c4e7-458d-9b88-fec5a07b14a8"),
                            ExPoints = "100",
                            LabPoints = "100",
                            MainPoints = "100",
                            StudentId = new Guid("ffa9e244-2743-43b4-8d62-b162700b78d7")
                        },
                        new
                        {
                            Id = new Guid("76e77dc8-dfb0-4cbb-9830-dc0ac3d5b98b"),
                            CourseId = new Guid("ef59ce64-c4e7-458d-9b88-fec5a07b14a8"),
                            ExPoints = "100",
                            LabPoints = "100",
                            MainPoints = "100",
                            StudentId = new Guid("9011e45a-a408-bb72-50eb-d5ee66875dd3")
                        });
                });

            modelBuilder.Entity("internetProgramming_TeemProject.Entities.Teacher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("InstituteId")
                        .HasColumnType("TEXT");

                    b.Property<string>("TeacherIntroduction")
                        .HasColumnType("TEXT");

                    b.Property<string>("TeacherName")
                        .HasMaxLength(4)
                        .HasColumnType("TEXT");

                    b.Property<string>("TeacherNum")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("InstituteId");

                    b.ToTable("Teachers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ca268a19-0f39-4d8b-b8d6-5bace54f8027"),
                            InstituteId = new Guid("bbdee09c-089b-4d30-bece-44df5923716c"),
                            TeacherIntroduction = "",
                            TeacherName = "何路",
                            TeacherNum = "201401"
                        },
                        new
                        {
                            Id = new Guid("7346d7ba-d17c-9014-05ae-fb0169ed0a13"),
                            InstituteId = new Guid("bbdee09c-089b-4d30-bece-44df5923716c"),
                            TeacherIntroduction = "",
                            TeacherName = "耿国华",
                            TeacherNum = "201402"
                        },
                        new
                        {
                            Id = new Guid("494710f6-6202-fbe9-d827-1dafde50daa2"),
                            InstituteId = new Guid("bbdee09c-089b-4d30-bece-44df5923716c"),
                            TeacherName = "徐彩霞",
                            TeacherNum = "201403"
                        },
                        new
                        {
                            Id = new Guid("47b70abc-98b8-4fdc-b9fa-5dd6716f6e6b"),
                            InstituteId = new Guid("5efc910b-2f45-43df-afee-620d40542853"),
                            TeacherIntroduction = "",
                            TeacherName = "王豪",
                            TeacherNum = "201501"
                        },
                        new
                        {
                            Id = new Guid("5d27fb1c-f235-e1ce-fe63-ae6e664a27fa"),
                            InstituteId = new Guid("5efc910b-2f45-43df-afee-620d40542853"),
                            TeacherIntroduction = "",
                            TeacherName = "郭孟源",
                            TeacherNum = "201502"
                        },
                        new
                        {
                            Id = new Guid("2ea277d6-50cc-025e-0935-8646f06ba2bd"),
                            InstituteId = new Guid("6fb600c1-9011-4fd7-9234-881379716440"),
                            TeacherIntroduction = "",
                            TeacherName = "任瀚宇",
                            TeacherNum = "200001"
                        });
                });

            modelBuilder.Entity("internetProgramming_TeemProject.Entities.TeacherCourse", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("TeacherId");

                    b.ToTable("TeacherCourses");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8ad8bf28-7751-442f-906f-4eb9a0a15569"),
                            CourseId = new Guid("ef59ce64-c4e7-458d-9b88-fec5a07b14a8"),
                            TeacherId = new Guid("47b70abc-98b8-4fdc-b9fa-5dd6716f6e6b")
                        },
                        new
                        {
                            Id = new Guid("d7de8b17-39bd-4ab6-b98a-76591ba62ca5"),
                            CourseId = new Guid("ef59ce64-c4e7-458d-9b88-fec5a07b14a8"),
                            TeacherId = new Guid("ca268a19-0f39-4d8b-b8d6-5bace54f8027")
                        });
                });

            modelBuilder.Entity("internetProgramming_TeemProject.Entities.Student", b =>
                {
                    b.HasOne("internetProgramming_TeemProject.Entities.Institute", "Institute")
                        .WithMany("Students")
                        .HasForeignKey("InstituteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Institute");
                });

            modelBuilder.Entity("internetProgramming_TeemProject.Entities.StudentCourse", b =>
                {
                    b.HasOne("internetProgramming_TeemProject.Entities.Course", "Course")
                        .WithMany("StudentCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("internetProgramming_TeemProject.Entities.Student", "Student")
                        .WithMany("StudentCourses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("internetProgramming_TeemProject.Entities.Teacher", b =>
                {
                    b.HasOne("internetProgramming_TeemProject.Entities.Institute", "Institute")
                        .WithMany("Teachers")
                        .HasForeignKey("InstituteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Institute");
                });

            modelBuilder.Entity("internetProgramming_TeemProject.Entities.TeacherCourse", b =>
                {
                    b.HasOne("internetProgramming_TeemProject.Entities.Course", "Course")
                        .WithMany("TeacherCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("internetProgramming_TeemProject.Entities.Teacher", "Teacher")
                        .WithMany("TeacherCourses")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("internetProgramming_TeemProject.Entities.Course", b =>
                {
                    b.Navigation("StudentCourses");

                    b.Navigation("TeacherCourses");
                });

            modelBuilder.Entity("internetProgramming_TeemProject.Entities.Institute", b =>
                {
                    b.Navigation("Students");

                    b.Navigation("Teachers");
                });

            modelBuilder.Entity("internetProgramming_TeemProject.Entities.Student", b =>
                {
                    b.Navigation("StudentCourses");
                });

            modelBuilder.Entity("internetProgramming_TeemProject.Entities.Teacher", b =>
                {
                    b.Navigation("TeacherCourses");
                });
#pragma warning restore 612, 618
        }
    }
}
