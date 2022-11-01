using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.DTO;
using NZWalks.API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;

        public RegionController(IRegionRepository repo, IMapper mapper)
        {
            _regionRepository = repo;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _regionRepository.GetAll();
            var regionsDTO = _mapper.Map<List<DTO.Region>>(result);
            return Ok(regionsDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetRegionAsync")]
        public async Task<IActionResult> GetRegionAsync(Guid id)
        {
            var region = await _regionRepository.GetRegionAsync(id);
            if(region == null)
            {
                return NotFound();
            }

            var regionDTO = _mapper.Map<DTO.Region>(region);

            return Ok(regionDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddRegion(AddRegion addRegion)
        {
            //Request DTO to domain model
            var regionDomainModel = _mapper.Map<Models.Region>(addRegion);
            //Pass domain model to repository
            await _regionRepository.AddRegionAsync(regionDomainModel);
            //Convert back to DT
            var result = _mapper.Map<DTO.Region>(regionDomainModel);
            return CreatedAtAction(nameof(GetRegionAsync), new { id = result.Id }, result);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteRegionAsync(Guid id)
        {
            //Get Region from DB
            var region = await _regionRepository.GetRegionAsync(id);

            //If null then return
            if (region == null) return NotFound();

            //Remove or delete Region
            var regionDomainModel = await _regionRepository.DeleteRegionAsync(id);

            var regionDTO = _mapper.Map<DTO.Region>(regionDomainModel);

            return Ok(regionDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpddateRegionAsync([FromRoute]Guid id, [FromBody]DTO.UpdateRegion updateRegion)
        {
            //Convert DTO to domain
            var region = _mapper.Map<Models.Region>(updateRegion);

            //Null check
            if (region == null) return NotFound();
            //Update region
            var updatedRegion = await _regionRepository.UpdateAsync(id, region);
            //
            var regionDTO = _mapper.Map<DTO.Region>(updatedRegion);

            return Ok(regionDTO);
        }
    }
}
