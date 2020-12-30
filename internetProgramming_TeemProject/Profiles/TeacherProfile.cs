using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using internetProgramming_TeemProject.Models;
using internetProgramming_TeemProject.Entities;

namespace internetProgramming_TeemProject.Profiles
{
    public class TeacherProfile: Profile
    {
        public TeacherProfile()
        {
            CreateMap<Teacher, TeacherDto>();
            CreateMap<TeacherAddDto, Teacher>();
            CreateMap<Teacher, TeacherUpdateDto>();
            CreateMap<TeacherUpdateDto, Teacher>();
            CreateMap<TeacherCourse, TeacherCourseDto>();
        }
    }
}
