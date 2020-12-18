using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace internetProgramming_TeemProject.Entities
{
    public enum CourseTime
    {
        FirstSemester, SecondSemester,TheFirstHalfFirstSemester, TheSecondHalfFirstSemester, TheFirstHalfSecondSemester, TheSecondHalfSecondSemester
    }
    public class Course
    {
        public Guid CourseId { get; set; }
        public string CourseName { get; set; }
        public string StartTime { get; set; }
        public CourseTime CourseTime { get; set; }
        public string Information { get; set; }
        public bool HasExperiment { get; set; }
        public ICollection<Courseware> Coursewares { get; set; }
        public ICollection<HomeWork> HomeWorks { get; set; }
        public ICollection<Experiment> Experiments { get; set; }
        public ICollection<Enrollment> Enrollments{ get; set; }
        public ICollection <Teach> Teaches { get; set; }
    }
}
