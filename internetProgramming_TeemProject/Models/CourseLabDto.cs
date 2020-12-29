using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace internetProgramming_TeemProject.Models
{
    public class CourseLabDto
    {
        public Guid Id { get; set; }
        public string LabName { get; set; }
        public string LabStep { get; set; }

        public string RefDocment { get; set; }
        public DateTime LastSubmit { get; set; }
    }
}
