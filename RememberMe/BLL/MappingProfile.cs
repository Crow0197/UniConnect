using AutoMapper;
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
            CreateMap<CommentoRequest, Commento>();


            CreateMap<Post, PostRequest>();
            CreateMap<PostRequest, Post>();

            CreateMap<Post, PostRequestFile>();
            CreateMap<PostRequestFile, Post>();
            

            CreateMap<Gruppo, GruppoRequest>();
            CreateMap<GruppoRequest, Gruppo>();


            CreateMap<Gruppo, GruppoResponse>();
            CreateMap<GruppoResponse, Gruppo>();


            CreateMap<AccountRequest, ApplicationUser>();

            CreateMap<ApplicationUser, IdentityUser>();
            CreateMap<IdentityUser, ApplicationUser>();
            CreateMap<IdentityUser, ApplicationUser>();


            CreateMap<FileStorageResponse, FileStorage>();
            CreateMap<FileStorage, FileStorageResponse>();

            CreateMap<Post, PostResponse>()
                .ForPath(dest => dest.User.UserName, opt => opt.MapFrom(src => src.User.UserName))
                .ForPath(dest => dest.User.Id, opt => opt.MapFrom(src => src.User.Id))
                .ForPath(dest => dest.User.Avatar, opt => opt.MapFrom(src => src.User.Avatar))
                .ForPath(dest => dest.User.Email, opt => opt.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.NumeroCommenti, opt => opt.MapFrom(src => src.Commento.Count))
                .ForMember(dest => dest.Files, opt => opt.MapFrom(src => src.File));



            CreateMap<Commento, CommentiResponse>()
                .ForPath(dest => dest.User.UserName, opt => opt.MapFrom(src => src.User.UserName))
                .ForPath(dest => dest.User.Id, opt => opt.MapFrom(src => src.User.Id))
                .ForPath(dest => dest.User.Avatar, opt => opt.MapFrom(src => src.User.Avatar))
                .ForPath(dest => dest.User.Email, opt => opt.MapFrom(src => src.User.Email));
        }
    }
}
