using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NZWalks.API.Profiles
{
    public class RegionProfile : Profile
    {
        public RegionProfile()
        {
            CreateMap<Models.Region, DTO.Region>().ReverseMap();
            CreateMap<Models.Region, DTO.AddRegion>().ReverseMap();
            CreateMap<Models.Region, DTO.UpdateRegion>().ReverseMap();
        }
    }
}
