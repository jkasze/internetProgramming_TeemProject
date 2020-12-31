using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace internetProgramming_TeemProject.Models
{
    public class StudentCourseDto
    {
        public Guid StudentId { get; set; }
        public Guid CourseId { get; set; }
        public string MainPoints { get; set; }
        public string LabPoints { get; set; }
        public string ExPoints { get; set; }
    }
}
