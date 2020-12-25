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
        public Guid Id{get;set;}
        public Guid InstituteId { get; set; }

        //教师账号，通过登录账号反向获取主键
        public long TeacherNum { get; set; }
        public string TeacherNo { get; set; }
        public string TeacherName { get; set; }
        public string Introduction { get; set; }
        public Gender Gender { get; set; }
        public Institute Institute { get; set; }
    }
}
