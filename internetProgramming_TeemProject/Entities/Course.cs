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
    /*public class Course
    {
        public Guid CourseId { get; set; }
        //基本信息
        public string CourseName { get; set; }
        public DateTime StartTime { get; set; }
        public CourseTime CourseTime { get; set; }
        public int theoryPeriod { get; set; }
        public int labPeriod { get; set; }
        public string Information { get; set; }
        //拓展信息
        //课件
        public string pptNmae { get; set; }

        //实验
        public string labName { get;set;}
        public string labStep { get; set; }

        public string refDocment { get; set; }
        public DateTime lastSubmit { get; set; }
        //作业
        public int exTimes { get; set; }
        public string exName { get; set; }
        public string exInfor { get; set; }
        public DateTime exStrat { get; set; }
        public DateTime exSubmit { get; set; }

        public ICollection<Teacher> Teachers { get; set; }
        public ICollection<Student> Students { get; set; }
    }*/
}
