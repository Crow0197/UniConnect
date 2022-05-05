using AutoMapper;
using DuelsTest.Request;
using Microsoft.AspNetCore.Identity;
using Repo.Ef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuelsTest
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<AccountRequest, ApplicationUser>();
            CreateMap<ApplicationUser, AccountRequest>();
            CreateMap<ApplicationUser, IdentityUser>();
            CreateMap<IdentityUser, ApplicationUser>();
        }
    }
}
