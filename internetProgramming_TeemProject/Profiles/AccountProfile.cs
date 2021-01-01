using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using internetProgramming_TeemProject.Models;
using internetProgramming_TeemProject.Entities;
namespace internetProgramming_TeemProject.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, AccountUpdateDto>();
            CreateMap<AccountUpdateDto, Account>();
        }
    }
}
