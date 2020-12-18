using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace internetProgramming_TeemProject.Entities
{
    public enum Grade
        {
            A,B,C,D,E
        }
    public class Enrollment
    {
        
        public Guid EnrollmentId { get; set; }
        public string StudentId { get; set; }
        public Guid CourseId { get; set; }
        public Grade?  Grade { get; set; }


        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
