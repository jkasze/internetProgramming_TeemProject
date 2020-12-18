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
                    Introduction = "这"
                },
                new Institute
                {
                    Id = Guid.Parse("6fb600c1-9011-4fd7-9234-881379716440"),
                    Name = "信的学院",
                    Introduction = "这"
                },
                new Institute
                {
                    Id = Guid.Parse("5efc910b-2f45-43df-afee-620d40542853"),
                    Name = "信息的学院",
                    Introduction = "这"
                });
        }
    
    }
}
