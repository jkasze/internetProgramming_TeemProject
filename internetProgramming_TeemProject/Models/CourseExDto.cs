using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace internetProgramming_TeemProject.Models
{
    public class CourseExDto
    {
        public Guid Id { get; set; }
        public int ExTimes { get; set; }
        public string ExName { get; set; }
        public string ExInfor { get; set; }
        public DateTime ExStart { get; set; }
        public DateTime ExSubmit { get; set; }
    }
}
