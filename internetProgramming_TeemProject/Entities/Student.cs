using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace internetProgramming_TeemProject.Entities
{
    public class Student
    {
        /*public Student()
        {
            StudentCourse = new List<StudentCourse>();
        }*/
        public Guid Id { get; set; }
        public Guid InstituteId { get; set; }
        public int StudentNum { get; set; }
        public string StudentName { get; set; }
        public Institute Institute { get; set; }

        //public List<StudentCourse> StudentCourse { get; set; }
    }

}
