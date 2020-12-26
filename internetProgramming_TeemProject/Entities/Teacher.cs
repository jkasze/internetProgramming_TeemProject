using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace internetProgramming_TeemProject.Entities
{
    public enum Gender
    {
        男 = 1,
        女 = 2
    }
    //教师
    public class Teacher
    {
        public Guid Id{ get; set; }
        public Guid InstituteId { get; set; }
        public long TeacherNum { get; set; }
        public string TeacherName { get; set; }
        public string TeacherIntroduction { get; set; }
        public Institute Institute { get; set; }
    }
}
