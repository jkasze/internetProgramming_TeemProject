using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using internetProgramming_TeemProject.Entities;
using internetProgramming_TeemProject.Services;

namespace internetProgramming_TeemProject.Data
{
    public class ProjectDbContext : DbContext
    {
        //调用并获取父类的options
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options)
        {

        }
        public DbSet<Institute> Institutes { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses{ get; set; }
        public DbSet<TeacherCourse> TeacherCourses { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Institute>().Property(x => x.Name).HasMaxLength(4);
            modelBuilder.Entity<Institute>().Property(x => x.Num).HasMaxLength(3);
            modelBuilder.Entity<Institute>().Property(x => x.Introduction).HasMaxLength(500);
            modelBuilder.Entity<Teacher>().Property(x => x.TeacherName).HasMaxLength(4); 
            modelBuilder.Entity<Teacher>()
                .HasOne(x => x.Institute)
                .WithMany(x => x.Teachers)
                .HasForeignKey(x => x.InstituteId)
                .OnDelete(DeleteBehavior.Cascade);
            /*modelBuilder.Entity<Course>()
                .HasOne(x => x.teacher)
                .WithMany(x => x.Courses)
                .HasForeignKey(x => x.Id)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Course>()
                .HasOne(x => x.student)
                .WithMany(x => x.Courses)
                .HasForeignKey(x => x.Id)
                .OnDelete(DeleteBehavior.SetNull);*/
            modelBuilder.Entity<StudentCourse>()
                .HasOne(x => x.Student)
                .WithMany(x => x.StudentCourses)
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<StudentCourse>()
                .HasOne(x => x.Course)
                .WithMany(x => x.StudentCourses)
                .HasForeignKey(x => x.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TeacherCourse>()
                .HasOne(x => x.Course)
                .WithMany(x => x.TeacherCourses)
                .HasForeignKey(x => x.CourseId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<TeacherCourse>()
                .HasOne(x => x.Teacher)
                .WithMany(x => x.TeacherCourses)
                .HasForeignKey(x => x.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Student>().Property(x => x.StudentName).HasMaxLength(4);
            modelBuilder.Entity<Student>().Property(x => x.StudentNum).HasMaxLength(8);
            //modelBuilder.Entity<Account>().HasKey(x=>x.Id);
            modelBuilder.Entity<Student>()
                 .HasOne(x => x.Institute)
                 .WithMany(x => x.Students)
                 .HasForeignKey(x => x.InstituteId)
                 .OnDelete(DeleteBehavior.Cascade);
            //modelBuilder.Entity<Course>().Property(x => x.CourseName).HasMaxLength(12);
            modelBuilder.Entity<Institute>().HasData(
                new Institute
                {
                    Id = Guid.Parse("bbdee09c-089b-4d30-bece-44df5923716c"),
                    Num = "01",
                    Name = "信息学院",
                    Introduction = "西北大学信息科学与技术学院成立于2005年5月，是由前计算机科学系和电子科学系为主体整合而成。"
                },
                new Institute
                {
                    Id = Guid.Parse("6fb600c1-9011-4fd7-9234-881379716440"),
                    Num = "02",
                    Name = "法学院",
                    Introduction = "西北大学法学教育始于1907年的陕西法政学堂，是中国现代法学教育中历史最为悠久的学校之一。"
                },
                new Institute
                {
                    Id = Guid.Parse("5efc910b-2f45-43df-afee-620d40542853"),
                    Num = "03",
                    Name = "历史学院",
                    Introduction = "西北大学历史学院其前身西北大学文博学院（1988年设立）源自于1937年设立的西北联合大学历史系，许寿裳任系主任。"
                });
            modelBuilder.Entity<Teacher>().HasData(
                new Teacher
                {
                    Id = Guid.Parse("ca268a19-0f39-4d8b-b8d6-5bace54f8027"),
                    InstituteId = Guid.Parse("bbdee09c-089b-4d30-bece-44df5923716c"),
                    TeacherNum = "201401",
                    TeacherIntroduction = "",
                    TeacherName = "何路",
                },
                new Teacher
                {
                    Id = Guid.Parse("7346d7ba-d17c-9014-05ae-fb0169ed0a13"),
                    InstituteId = Guid.Parse("bbdee09c-089b-4d30-bece-44df5923716c"),
                    TeacherNum = "201402",
                    TeacherIntroduction = "",
                    TeacherName = "耿国华",
                },
                new Teacher
                {
                    Id = Guid.Parse("494710f6-6202-fbe9-d827-1dafde50daa2"),
                    InstituteId = Guid.Parse("bbdee09c-089b-4d30-bece-44df5923716c"),
                    TeacherNum = "201403",
                    TeacherName = "徐彩霞",
                },
                new Teacher
                {
                    Id = Guid.Parse("47b70abc-98b8-4fdc-b9fa-5dd6716f6e6b"),
                    InstituteId = Guid.Parse("5efc910b-2f45-43df-afee-620d40542853"),
                    TeacherNum = "201501",
                    TeacherIntroduction = "",
                    TeacherName = "王豪",
                },
                new Teacher
                {
                    Id = Guid.Parse("5d27fb1c-f235-e1ce-fe63-ae6e664a27fa"),
                    InstituteId = Guid.Parse("5efc910b-2f45-43df-afee-620d40542853"),
                    TeacherNum = "201502",
                    TeacherIntroduction = "",
                    TeacherName = "郭孟源",
                },
                new Teacher
                {
                    Id = Guid.Parse("2ea277d6-50cc-025e-0935-8646f06ba2bd"),
                    InstituteId = Guid.Parse("6fb600c1-9011-4fd7-9234-881379716440"),
                    TeacherNum = "200001",
                    TeacherIntroduction = "",
                    TeacherName = "任瀚宇",
                }
            );
            modelBuilder.Entity<StudentCourse>().HasData(
     new StudentCourse
     {
         Id = Guid.Parse("a57d2b4e-6fd9-4b9a-912d-ab9902043612"),
         CourseId = Guid.Parse("ef59ce64-c4e7-458d-9b88-fec5a07b14a8"),
         StudentId = Guid.Parse("ffa9e244-2743-43b4-8d62-b162700b78d7"),
         MainPoints = "100",
         LabPoints = "100",
         ExPoints ="100"
     },
    new StudentCourse
    {
        Id = Guid.Parse("76e77dc8-dfb0-4cbb-9830-dc0ac3d5b98b"),
        CourseId = Guid.Parse("ef59ce64-c4e7-458d-9b88-fec5a07b14a8"),
        StudentId = Guid.Parse("9011e45a-a408-bb72-50eb-d5ee66875dd3"),
        MainPoints = "100",
        LabPoints = "100",
        ExPoints = "100"
    }
    );
            modelBuilder.Entity<TeacherCourse>().HasData(
                new TeacherCourse
                {
                    Id = Guid.Parse("8ad8bf28-7751-442f-906f-4eb9a0a15569"),
                    CourseId = Guid.Parse("ef59ce64-c4e7-458d-9b88-fec5a07b14a8"),
                    TeacherId = Guid.Parse("47b70abc-98b8-4fdc-b9fa-5dd6716f6e6b"),
                },
                new TeacherCourse
                {
                    Id = Guid.Parse("d7de8b17-39bd-4ab6-b98a-76591ba62ca5"),
                    CourseId = Guid.Parse("ef59ce64-c4e7-458d-9b88-fec5a07b14a8"),
                    TeacherId = Guid.Parse("ca268a19-0f39-4d8b-b8d6-5bace54f8027"),
                }
                );
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = Guid.Parse("ffa9e244-2743-43b4-8d62-b162700b78d7"),
                    InstituteId = Guid.Parse("5efc910b-2f45-43df-afee-620d40542853"),
                    //StudentCourseId = Guid.Parse("a57d2b4e-6fd9-4b9a-912d-ab9902043612"),
                    StudentNum = "20180101",
                    StudentName = "封不觉",
                },
                new Student
                {
                    Id = Guid.Parse("e48f8f2f-22d6-cb6e-cdc2-4c92a09fdfcd"),
                    InstituteId = Guid.Parse("5efc910b-2f45-43df-afee-620d40542853"),
                    
                    StudentNum = "20180102",
                    StudentName = "封不",
                },
                new Student
                {
                    Id = Guid.Parse("9011e45a-a408-bb72-50eb-d5ee66875dd3"),
                    InstituteId = Guid.Parse("5efc910b-2f45-43df-afee-620d40542853"),
                    //StudentCourseId = Guid.Parse("76e77dc8-dfb0-4cbb-9830-dc0ac3d5b98b"),
                    StudentNum = "20180103",
                    StudentName = "封觉",
                }
            );

            modelBuilder.Entity<Account>().HasData(
            new Account
            {
                Id = Guid.Parse("4741a63f-aad1-4a38-8ac9-32e11689c32b"),
                UserName = "20180101",
                Password = "20181010",
                Type = AccountType.student,
            });

            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    Id = Guid.Parse("ef59ce64-c4e7-458d-9b88-fec5a07b14a8"),
                    //StudentCourseId = Guid.Parse("a57d2b4e-6fd9-4b9a-912d-ab9902043612"),
                    CourseName = "互联网程序设计",
                    CourseTime = CourseTime.FirstSemester,
                    StartTime = new DateTime(2020, 09, 01, 00, 00, 00),
                    TheoryPeriod = 48,
                    LabPeriod = 180,
                    Information = "HTML+CSS+JavaScript+ASP.NET",
                    PPTName = "",
                    LabName = "",
                    LabStep = "",
                    RefDocment = "",
                    LastSubmit = new DateTime(),
                    ExTimes = 1,
                    ExName = "",
                    ExInfor = "",
                    ExStart = new DateTime(),
                    ExSubmit = new DateTime(),
                
               
                });


                

            /**/

        }
    
    }
}
