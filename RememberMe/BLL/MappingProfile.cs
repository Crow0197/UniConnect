using AutoMapper;
using UniConnect.Data.Request;
using UniConnect.Request;
using Microsoft.AspNetCore.Identity;
using Repo.Ef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniConnect
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
            CreateMap<Pg, PgRequest>();
            CreateMap<PgRequest,Pg>();           
            CreateMap<IdentityUser, ApplicationUser>();
        }
    }
}
