using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace internetProgramming_TeemProject.Models
{
    public class StudentDto
    {
        public Guid Id { get; set; }
        public Guid InstituteId { get; set; }
        public int StudentNum { get; set; }
        public string StudentName { get; set; }
    }
}
