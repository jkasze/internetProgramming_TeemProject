using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace internetProgramming_TeemProject.Entities
{
    //学院数据表模型
    public class Institute
    {
        public Guid Id { get; set; }
        public string Num { get; set; }
        public string Name { get; set; }
        public string Introduction { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
    }
}
