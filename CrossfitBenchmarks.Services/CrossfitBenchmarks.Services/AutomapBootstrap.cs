using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Entities = CrossfitBenchmarks.Data;
using Dto = CrossfitBenchmarks.Data.DataTransfer;

namespace CrossfitBenchmarks.Services
{
    public static class AutomapBootstrap
    {
        public static void Initialize()
        {
            AutoMapper.Mapper.CreateMap<Entities.WorkoutType, Dto.WorkoutTypeDto>();

            AutoMapper.Mapper.CreateMap<Entities.User, Dto.UserInfoDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.IpEmail))
                .ForMember(dest => dest.IdentityProvider, opt => opt.MapFrom(src => src.IdentityProvider))
                .ForMember(dest => dest.NameIdentifier, opt => opt.MapFrom(src => src.IpNameIdentifier));
        }
    }
}

