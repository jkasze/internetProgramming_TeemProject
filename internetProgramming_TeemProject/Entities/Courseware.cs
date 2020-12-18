using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace internetProgramming_TeemProject.Entities
{
    //课件
    public class Courseware
    {
        public Guid CoursewareId { get; set; }
        public string CoursewareName { get; set; }
        //外键
        public Guid  CourseId{ get; set; }
    }
}
