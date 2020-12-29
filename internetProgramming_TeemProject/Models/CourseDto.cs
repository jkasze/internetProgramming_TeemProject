using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace internetProgramming_TeemProject.Models
{
    public enum CourseTime
    {
        FirstSemester, SecondSemester, TheFirstHalfFirstSemester, TheSecondHalfFirstSemester, TheFirstHalfSecondSemester, TheSecondHalfSecondSemester
    }
    public class CourseDto
    {
        public Guid Id { get; set; }
        //基本信息
        public string CourseName { get; set; }
        public string Teachers { get; set; }
        public DateTime StartTime { get; set; }
        public CourseTime CourseTime { get; set; }
        public int TheoryPeriod { get; set; }
        public int LabPeriod { get; set; }
        public string Information { get; set; }
    }
}
