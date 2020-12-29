using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using internetProgramming_TeemProject.Models;
using internetProgramming_TeemProject.Entities;

namespace internetProgramming_TeemProject.Profiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseDto>();
            CreateMap<CourseAddDto, Course>();
            CreateMap<Course, CourseUpdateDto>();
            CreateMap<CourseUpdateDto, Course>();

            CreateMap<Course, CourseLabDto>();
            CreateMap<Course, CourseLabUpdateDto>();
            CreateMap<CourseLabUpdateDto, Course>();

            CreateMap<Course, CourseExDto>();
            CreateMap<Course, CourseExUpdateDto>();
            CreateMap<CourseExUpdateDto, Course>();

            CreateMap<Course, CoursePPTDto>();
            CreateMap<Course, CoursePPTUpdateDto>();
            CreateMap<CoursePPTUpdateDto, Course>();

        }
    }
}
