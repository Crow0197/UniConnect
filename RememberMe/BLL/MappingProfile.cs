using AutoMapper;
using RememberMe.Data.Request;
using RememberMe.Request;
using Microsoft.AspNetCore.Identity;
using Repo.Ef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RememberMe
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
            CreateMap< PgRequest,Pg>();
            CreateMap<Statistic, StatisticBase>();
            CreateMap<StatisticBase, Statistic>();
            CreateMap<Move, MoveSet>();
            CreateMap<MoveSet, Move>();
            CreateMap<IdentityUser, ApplicationUser>();
        }
    }
}
