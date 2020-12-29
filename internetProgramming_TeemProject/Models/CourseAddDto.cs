using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace internetProgramming_TeemProject.Models
{
    public class CourseAddDto
    {
        public string CourseName { get; set; }
        public DateTime StartTime { get; set; }
        public CourseTime CourseTime { get; set; }
        public int TheoryPeriod { get; set; }
        public int LabPeriod { get; set; }
        public string Information { get; set; }
    }
}
