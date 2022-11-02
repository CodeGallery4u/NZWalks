using AutoMapper;

namespace NZWalks.API.Profiles
{
    public class WalkDifficultyProfile: Profile
    {
        public WalkDifficultyProfile()
        {
            CreateMap<Models.WalkDifficulty, DTO.WalkDifficulty>().ReverseMap();
        }
    }
}
