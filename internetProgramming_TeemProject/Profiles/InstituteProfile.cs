using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using internetProgramming_TeemProject.Models;
using internetProgramming_TeemProject.Entities;
namespace internetProgramming_TeemProject.Profiles
{
    public class InstituteProfile: Profile
    {
        public InstituteProfile()
        {
            CreateMap<Institute, InstituteDto>();
            CreateMap<InstituteAddDto, Institute>();
            CreateMap<Institute, InstituteUpdateDto>();
            CreateMap<InstituteUpdateDto, Institute>();
        }
    }
}
