using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace internetProgramming_TeemProject.Entities
{
    //教师
    public class Teacher
    {
        public Guid Id{ get; set; }
        public Guid InstituteId { get; set; }
        public string TeacherNum { get; set; }
        public string TeacherName { get; set; }
        public string TeacherIntroduction { get; set; }
        public Institute Institute { get; set; }
        //public ICollection<Course> Courses { get; set; }
        //public Course Course { get; set; }
        public ICollection<TeacherCourse> TeacherCourses { get; set; }

    }
}
