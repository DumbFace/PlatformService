using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PlatformService.DTOS;
using PlatformService.Models;

namespace PlatformService.Profiles
{
    public class PlatformsProfile : Profile
    {
        public PlatformsProfile()
        {

            //Source --> desination
            CreateMap<Platform, PlatformsReadDTOs>();
            CreateMap<PlatformsCreateDTOs, Platform>();
        }
    }
}