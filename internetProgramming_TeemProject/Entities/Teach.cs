using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace internetProgramming_TeemProject.Entities
{
    //教师任课表，一门课可有多位教师，一位教师也可教授多门课
    public class Teach
    {
        public Guid Id { get; set; }
        public Guid TeacherId { get; set; }
        public Guid CourseId { get; set; }

        public Teacher Teacher { get; set; }
        public Course Course { get; set; }
    }
}
