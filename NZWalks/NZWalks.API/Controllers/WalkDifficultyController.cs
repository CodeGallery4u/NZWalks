using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalkDifficultyController : ControllerBase
    {
        private readonly IWalkDifficultyRepository _walkDifficultyRepository;
        private readonly IMapper _mapper;
        public WalkDifficultyController(IWalkDifficultyRepository repo, IMapper mapper)
        {
            _walkDifficultyRepository = repo;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _walkDifficultyRepository.GetAll();
            if (result == null) return Ok();
            return Ok(_mapper.Map<List<DTO.WalkDifficulty>>(result));
        }
    }
}
