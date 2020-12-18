using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace internetProgramming_TeemProject.Entities
{
    public class HomeWork
    {
        public Guid HomeWorkId { get; set; }
        public Guid CourseId { get; set; }
        public string HomeWorkName { get; set; }
        public string Content { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

    }
}
