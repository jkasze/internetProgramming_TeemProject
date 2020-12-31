using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace internetProgramming_TeemProject.Entities
{
    public class StudentCourse
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public Guid CourseId { get; set; }

        public string MainPoints { get; set; }
        public string LabPoints { get; set; }
        public string ExPoints { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
