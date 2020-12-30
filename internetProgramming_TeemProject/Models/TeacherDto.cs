using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using internetProgramming_TeemProject.Entities;

namespace internetProgramming_TeemProject.Models
{
    public class TeacherDto
    {

        public Guid Id { get; set; }
        public Guid InstituteId { get; set; }
        public string TeacherNum { get; set; }
        public string TeacherName { get; set; }
        public string TeacherIntroduction { get; set; }
    }
}
