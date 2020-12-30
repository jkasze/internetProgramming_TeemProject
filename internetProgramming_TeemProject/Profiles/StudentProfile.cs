using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using internetProgramming_TeemProject.Models;
using internetProgramming_TeemProject.Entities;
namespace internetProgramming_TeemProject.Profiles
{
    public class StudentProfile: Profile
    { 
        public StudentProfile()
        {
            CreateMap<Student, StudentDto>();
            CreateMap<StudentAddDto, Student>();
            CreateMap<Student, StudentUpdateDto>();
            CreateMap<StudentUpdateDto, Student>();
            CreateMap<StudentCourse, StudentCourseDto>();
        }
    }
}
