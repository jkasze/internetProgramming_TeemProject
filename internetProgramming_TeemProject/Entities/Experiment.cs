using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace internetProgramming_TeemProject.Entities
{
    //实验
    public class Experiment
    {
        public Guid ExperimentId { get; set; }
        public Guid CourseId { get; set; }
        public string Name { get; set; }
        public string Purpose { get; set; }
        //最晚提交时间
        public DateTime LastTime { get; set; }
        public string Steps { get; set; }
        public string Resource { get; set; }
    }
}
