﻿using Microsoft.EntityFrameworkCore;
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
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Courseware> Coursewares { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Experiment> Experiments { get; set; }
        public DbSet<HomeWork> HomeWorks { get; set; }
        public DbSet<Teach> Teaches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Institute>().Property(x => x.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Institute>().Property(x => x.Introduction).HasMaxLength(500);
            modelBuilder.Entity<Teacher>().Property(x => x.TeacherNo).IsRequired().HasMaxLength(10);
            modelBuilder.Entity<Teacher>().Property(x => x.TeacherName).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Teacher>()
                .HasOne(x => x.Institute)
                .WithMany(x => x.Teachers)
                .HasForeignKey(x => x.InstituteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Institute>().HasData(
                new Institute
                {
                    Id = Guid.Parse("bbdee09c-089b-4d30-bece-44df5923716c"),
                    Name = "信息学院",
                    Introduction = "西北大学信息科学与技术学院成立于2005年5月，是由前计算机科学系和电子科学系为主体整合而成。"
                },
                new Institute
                {
                    Id = Guid.Parse("6fb600c1-9011-4fd7-9234-881379716440"),
                    Name = "法学院",
                    Introduction = "西北大学法学教育始于1907年的陕西法政学堂，是中国现代法学教育中历史最为悠久的学校之一。"
                },
                new Institute
                {
                    Id = Guid.Parse("5efc910b-2f45-43df-afee-620d40542853"),
                    Name = "历史学院",
                    Introduction = "西北大学历史学院其前身西北大学文博学院（1988年设立）源自于1937年设立的西北联合大学历史系，许寿裳任系主任。"
                });
            modelBuilder.Entity<Teacher>().HasData(
                new Teacher
                {
                    Id = Guid.Parse("ca268a19-0f39-4d8b-b8d6-5bace54f8027"),
                    InstituteId = Guid.Parse("bbdee09c-089b-4d30-bece-44df5923716c"),
                    TeacherNum = 201401,
                    TeacherNo = "1",
                    TeacherName = "何路",
                    Gender = (Gender)1,
                },
                new Teacher
                {
                    Id = Guid.Parse("7346d7ba-d17c-9014-05ae-fb0169ed0a13"),
                    InstituteId = Guid.Parse("bbdee09c-089b-4d30-bece-44df5923716c"),
                    TeacherNum = 201402,
                    TeacherNo = "2",
                    TeacherName = "耿国华",
                    Gender = (Gender)2,
                },
                new Teacher
                {
                    Id = Guid.Parse("494710f6-6202-fbe9-d827-1dafde50daa2"),
                    InstituteId = Guid.Parse("bbdee09c-089b-4d30-bece-44df5923716c"),
                    TeacherNum = 201403,
                    TeacherNo = "3",
                    TeacherName = "徐彩霞",
                    Gender = (Gender)2,
                },
                new Teacher
                {
                    Id = Guid.Parse("47b70abc-98b8-4fdc-b9fa-5dd6716f6e6b"),
                    InstituteId = Guid.Parse("5efc910b-2f45-43df-afee-620d40542853"),
                    TeacherNum = 201501,
                    TeacherNo = "1",
                    TeacherName = "王豪",
                    Gender = (Gender)1,
                },
                new Teacher
                {
                    Id = Guid.Parse("5d27fb1c-f235-e1ce-fe63-ae6e664a27fa"),
                    InstituteId = Guid.Parse("5efc910b-2f45-43df-afee-620d40542853"),
                    TeacherNum = 201502,
                    TeacherNo = "2",
                    TeacherName = "郭孟源",
                    Gender = (Gender)1,
                },
                new Teacher
                {
                    Id = Guid.Parse("2ea277d6-50cc-025e-0935-8646f06ba2bd"),
                    InstituteId = Guid.Parse("6fb600c1-9011-4fd7-9234-881379716440"),
                    TeacherNum = 200001,
                    TeacherNo = "1",
                    TeacherName = "任瀚宇",
                    Gender = (Gender)1,
                }
            );
        }
    
    }
}