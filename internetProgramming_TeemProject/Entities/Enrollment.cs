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

    //选课表，一门课可被多个人选择，一个人也可以选多门课
    public class Enrollment
    {
        
        public Guid EnrollmentId { get; set; }
        
        //外键
        public string StudentId { get; set; }
        public Guid CourseId { get; set; }

        //可为null
        public Grade?  Grade { get; set; }

        //分别关联的外部表
        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
