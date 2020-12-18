using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace internetProgramming_TeemProject.Entities
{
    public class Student
    {
        public long StudentId { get; set; }
        //学号，但不作为主键
        public long StudentNum { get; set; }
        public string StudentName { get; set; }
        public long StudentClass { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }

}
