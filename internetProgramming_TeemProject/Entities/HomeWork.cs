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
        //作业内容
        public string Content { get; set; }

        //开始时间，达到开始事件后被学生可见
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

    }
}
