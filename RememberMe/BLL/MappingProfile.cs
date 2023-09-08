﻿using AutoMapper;
using UniConnect.Data.Request;
using UniConnect.Request;
using Microsoft.AspNetCore.Identity;
using Repo.Ef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repo.Ef.Models;
using Models;
using Models.Response;

namespace UniConnect
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<AccountRequest, ApplicationUser>();
            CreateMap<ApplicationUser, AccountRequest>();
            CreateMap<Commento, CommentoRequest>();
            CreateMap< CommentoRequest, Commento>();


            CreateMap<Post, PostRequest>();
            CreateMap<PostRequest, Post>();


            CreateMap<Gruppo, GruppoRequest>();
            CreateMap<GruppoRequest, Gruppo>();


            CreateMap<Gruppo, GruppoResponse>();
            CreateMap<GruppoResponse, Gruppo>();

            
            CreateMap<AccountRequest, ApplicationUser>();

            CreateMap<ApplicationUser, IdentityUser>();
            CreateMap<IdentityUser, ApplicationUser>();          
            CreateMap<IdentityUser, ApplicationUser>();
        }
    }
}
