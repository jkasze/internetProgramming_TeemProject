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

            //教师账号，通过登录账号反向获取主键
            public long TeacherNum { get; set; }
            public string TeacherNo { get; set; }
            public string TeacherName { get; set; }
            public Gender Gender { get; set; }

            public ICollection<Teach> Teaches { get; set; }
        
    }
}
