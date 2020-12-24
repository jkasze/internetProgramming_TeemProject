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
                    b.Property<long>("AccountId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("AccountId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("internetProgramming_TeemProject.Entities.Course", b =>
                {
                    b.Property<Guid>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("CourseName")
                        .HasColumnType("TEXT");

                    b.Property<int>("CourseTime")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("HasExperiment")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Information")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("TEXT");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("internetProgramming_TeemProject.Entities.Courseware", b =>
                {
                    b.Property<Guid>("CoursewareId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("TEXT");

                    b.Property<string>("CoursewareName")
                        .HasColumnType("TEXT");

                    b.HasKey("CoursewareId");

                    b.HasIndex("CourseId");

                    b.ToTable("Coursewares");
                });

            modelBuilder.Entity("internetProgramming_TeemProject.Entities.Enrollment", b =>
                {
                    b.Property<Guid>("EnrollmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Grade")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StudentId")
                        .HasColumnType("TEXT");

                    b.Property<long?>("StudentId1")
                        .HasColumnType("INTEGER");

                    b.HasKey("EnrollmentId");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId1");

                    b.ToTable("Enrollments");
                });

            modelBuilder.Entity("internetProgramming_TeemProject.Entities.Experiment", b =>
                {
                    b.Property<Guid>("ExperimentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Purpose")
                        .HasColumnType("TEXT");

                    b.Property<string>("Resource")
                        .HasColumnType("TEXT");

                    b.Property<string>("Steps")
                        .HasColumnType("TEXT");

                    b.HasKey("ExperimentId");

                    b.HasIndex("CourseId");

                    b.ToTable("Experiments");
                });

            modelBuilder.Entity("internetProgramming_TeemProject.Entities.HomeWork", b =>
                {
                    b.Property<Guid>("HomeWorkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Content")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("HomeWorkName")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("TEXT");

                    b.HasKey("HomeWorkId");

                    b.HasIndex("CourseId");

                    b.ToTable("HomeWorks");
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
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Institutes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("bbdee09c-089b-4d30-bece-44df5923716c"),
                            Introduction = "西北大学信息科学与技术学院成立于2005年5月，是由前计算机科学系和电子科学系为主体整合而成。",
                            Name = "信息学院"
                        },
                        new
                        {
                            Id = new Guid("6fb600c1-9011-4fd7-9234-881379716440"),
                            Introduction = "西北大学法学教育始于1907年的陕西法政学堂，是中国现代法学教育中历史最为悠久的学校之一。",
                            Name = "法学院"
                        },
                        new
                        {
                            Id = new Guid("5efc910b-2f45-43df-afee-620d40542853"),
                            Introduction = "西北大学历史学院其前身西北大学文博学院（1988年设立）源自于1937年设立的西北联合大学历史系，许寿裳任系主任。",
                            Name = "历史学院"
                        });
                });

            modelBuilder.Entity("internetProgramming_TeemProject.Entities.Student", b =>
                {
                    b.Property<long>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("StudentClass")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StudentName")
                        .HasColumnType("TEXT");

                    b.Property<long>("StudentNum")
                        .HasColumnType("INTEGER");

                    b.HasKey("StudentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("internetProgramming_TeemProject.Entities.Teach", b =>
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

                    b.ToTable("Teaches");
                });

            modelBuilder.Entity("internetProgramming_TeemProject.Entities.Teacher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Gender")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("InstituteId")
                        .HasColumnType("TEXT");

                    b.Property<string>("TeacherName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("TeacherNo")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.Property<long>("TeacherNum")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("InstituteId");

                    b.ToTable("Teachers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ca268a19-0f39-4d8b-b8d6-5bace54f8027"),
                            Gender = 1,
                            InstituteId = new Guid("bbdee09c-089b-4d30-bece-44df5923716c"),
                            TeacherName = "何路",
                            TeacherNo = "1",
                            TeacherNum = 201401L
                        },
                        new
                        {
                            Id = new Guid("7346d7ba-d17c-9014-05ae-fb0169ed0a13"),
                            Gender = 2,
                            InstituteId = new Guid("bbdee09c-089b-4d30-bece-44df5923716c"),
                            TeacherName = "耿国华",
                            TeacherNo = "2",
                            TeacherNum = 201402L
                        },
                        new
                        {
                            Id = new Guid("494710f6-6202-fbe9-d827-1dafde50daa2"),
                            Gender = 2,
                            InstituteId = new Guid("bbdee09c-089b-4d30-bece-44df5923716c"),
                            TeacherName = "徐彩霞",
                            TeacherNo = "3",
                            TeacherNum = 201403L
                        },
                        new
                        {
                            Id = new Guid("47b70abc-98b8-4fdc-b9fa-5dd6716f6e6b"),
                            Gender = 1,
                            InstituteId = new Guid("5efc910b-2f45-43df-afee-620d40542853"),
                            TeacherName = "王豪",
                            TeacherNo = "1",
                            TeacherNum = 201501L
                        },
                        new
                        {
                            Id = new Guid("5d27fb1c-f235-e1ce-fe63-ae6e664a27fa"),
                            Gender = 1,
                            InstituteId = new Guid("5efc910b-2f45-43df-afee-620d40542853"),
                            TeacherName = "郭孟源",
                            TeacherNo = "2",
                            TeacherNum = 201502L
                        },
                        new
                        {
                            Id = new Guid("2ea277d6-50cc-025e-0935-8646f06ba2bd"),
                            Gender = 1,
                            InstituteId = new Guid("6fb600c1-9011-4fd7-9234-881379716440"),
                            TeacherName = "任瀚宇",
                            TeacherNo = "1",
                            TeacherNum = 200001L
                        });
                });

            modelBuilder.Entity("internetProgramming_TeemProject.Entities.Courseware", b =>
                {
                    b.HasOne("internetProgramming_TeemProject.Entities.Course", null)
                        .WithMany("Coursewares")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("internetProgramming_TeemProject.Entities.Enrollment", b =>
                {
                    b.HasOne("internetProgramming_TeemProject.Entities.Course", "Course")
                        .WithMany("Enrollments")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("internetProgramming_TeemProject.Entities.Student", "Student")
                        .WithMany("Enrollments")
                        .HasForeignKey("StudentId1");

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("internetProgramming_TeemProject.Entities.Experiment", b =>
                {
                    b.HasOne("internetProgramming_TeemProject.Entities.Course", null)
                        .WithMany("Experiments")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("internetProgramming_TeemProject.Entities.HomeWork", b =>
                {
                    b.HasOne("internetProgramming_TeemProject.Entities.Course", null)
                        .WithMany("HomeWorks")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("internetProgramming_TeemProject.Entities.Teach", b =>
                {
                    b.HasOne("internetProgramming_TeemProject.Entities.Course", "Course")
                        .WithMany("Teaches")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("internetProgramming_TeemProject.Entities.Teacher", "Teacher")
                        .WithMany("Teaches")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("internetProgramming_TeemProject.Entities.Teacher", b =>
                {
                    b.HasOne("internetProgramming_TeemProject.Entities.Institute", "Institute")
                        .WithMany("Teachers")
                        .HasForeignKey("InstituteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Institute");
                });

            modelBuilder.Entity("internetProgramming_TeemProject.Entities.Course", b =>
                {
                    b.Navigation("Coursewares");

                    b.Navigation("Enrollments");

                    b.Navigation("Experiments");

                    b.Navigation("HomeWorks");

                    b.Navigation("Teaches");
                });

            modelBuilder.Entity("internetProgramming_TeemProject.Entities.Institute", b =>
                {
                    b.Navigation("Teachers");
                });

            modelBuilder.Entity("internetProgramming_TeemProject.Entities.Student", b =>
                {
                    b.Navigation("Enrollments");
                });

            modelBuilder.Entity("internetProgramming_TeemProject.Entities.Teacher", b =>
                {
                    b.Navigation("Teaches");
                });
#pragma warning restore 612, 618
        }
    }
}