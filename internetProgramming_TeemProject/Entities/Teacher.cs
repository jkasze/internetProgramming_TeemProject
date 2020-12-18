using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace internetProgramming_TeemProject.Entities
{
    public class Teacher
    {
        public Guid Id{get;set;}
        public Guid InstituteId { get; set; }
        public string TeacherNo { get; set; }
        public string TeacherName { get; set; }
        public Gender Gender { get; set; }
        public Institute Institute { get; set; }
    }
}
