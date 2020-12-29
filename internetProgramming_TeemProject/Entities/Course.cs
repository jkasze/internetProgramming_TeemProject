using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
namespace internetProgramming_TeemProject.Entities
{
    //使用枚举类型定义课程的上课时间
    public enum CourseTime
    {
        FirstSemester, SecondSemester,TheFirstHalfFirstSemester, TheSecondHalfFirstSemester, TheFirstHalfSecondSemester, TheSecondHalfSecondSemester
    }
    public class Course
    {
        public Guid Id { get; set; }
       
        //基本信息
        public string CourseName { get; set; }
        public DateTime StartTime { get; set; }
        public CourseTime CourseTime { get; set; }
        public int TheoryPeriod { get; set; }
        public int LabPeriod { get; set; }
        public string Information { get; set; }
        //拓展信息
        //课件
        public string PPTName { get; set; }

        //实验
        public string LabName { get;set;}
        public string LabStep { get; set; }

        public string RefDocment { get; set; }
        public DateTime LastSubmit { get; set; }
        //作业
        public int ExTimes { get; set; }
        public string ExName { get; set; }
        public string ExInfor { get; set; }
        public DateTime ExStart { get; set; }
        public DateTime ExSubmit { get; set; }

        public Teacher teacher { get; set; }
        public Student student { get; set; }

    }
}
