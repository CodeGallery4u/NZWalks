using AutoMapper;

namespace NZWalks.API.Profiles
{
    public class WalkProfile : Profile
    {
        public WalkProfile()
        {
            CreateMap<Models.Walk, DTO.Walk>().ReverseMap();
            CreateMap<Models.Walk, DTO.AddWalk>().ReverseMap();
            CreateMap<Models.Walk, DTO.UpdateWalk>().ReverseMap();
        }
    }
}
