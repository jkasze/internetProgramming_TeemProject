using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace internetProgramming_TeemProject.Entities
{
    //使用枚举类型定义课程的上课时间
    public enum CourseTime
    {
        FirstSemester, SecondSemester,TheFirstHalfFirstSemester, TheSecondHalfFirstSemester, TheFirstHalfSecondSemester, TheSecondHalfSecondSemester
    }
    public class Course
    {
        public Guid CourseId { get; set; }
        public string CourseName { get; set; }

        //具体的日期
        public DateTime StartTime { get; set; }
        public CourseTime CourseTime { get; set; }
        public string Information { get; set; }

        //该课程是否有实验课
        public bool HasExperiment { get; set; }

        //关联外部表
        public ICollection<Courseware> Coursewares { get; set; }
        public ICollection<HomeWork> HomeWorks { get; set; }
        public ICollection<Experiment>?  Experiments { get; set; }


        public ICollection<Enrollment> Enrollments{ get; set; }
        public ICollection <Teach> Teaches { get; set; }
    }
}
