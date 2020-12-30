using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace internetProgramming_TeemProject.Entities
{
    public class Student
    {
        public Guid Id { get; set; }
        public Guid InstituteId { get; set; }

        //public Guid StudentCourseId { get; set; }
        public int StudentNum { get; set; }
        public string StudentName { get; set; }
        public Institute Institute { get; set; }
        //public ICollection<Course> Courses { get; set; }
        //public Course Course{ get; set; }
        //public StudentCourse StudentCourse { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }
    }

}
