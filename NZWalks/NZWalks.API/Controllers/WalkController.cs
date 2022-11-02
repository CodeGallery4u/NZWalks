using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalkController : ControllerBase
    {
        private readonly IWalkRepository _walkRepository;
        private readonly IMapper _mapper;

        public WalkController(IWalkRepository repo, IMapper mapper)
        {
            _walkRepository = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var waltDomainList = await _walkRepository.GetAll();
            if (waltDomainList == null) return Ok();

            var result = _mapper.Map<List<DTO.Walk>>(waltDomainList);
            return Ok(result);

        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var walkDominModel= await _walkRepository.GetByIdAsync(id);
            if (walkDominModel == null) return Ok();

            var result = _mapper.Map<DTO.Walk>(walkDominModel);
            return Ok(result);

        }

        [HttpPost]
        public async Task<IActionResult> Add(DTO.AddWalk addWalkObj)
        {
            //Convert DTO to Domain
            var walkDomainModel = _mapper.Map<Models.Walk>(addWalkObj);
            //Pass domain to repo
            var savedWalk = await _walkRepository.AddAsync(walkDomainModel);
            //Covert savedWalk to DTO again
            var savedWalkDTO = _mapper.Map<DTO.Walk>(savedWalk);

            return CreatedAtAction(nameof(GetById),new { id = savedWalkDTO.Id}, savedWalkDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute]Guid id, [FromBody]DTO.UpdateWalk updateWalkObj)
        {
            //Convert DTO to domain
            var walkDomainModel = _mapper.Map<Models.Walk>(updateWalkObj);

            var savedObj = await _walkRepository.UpdateAsync(id, walkDomainModel);

            var savedDTO = _mapper.Map<DTO.Walk>(savedObj);

            return Ok(savedDTO);
        }


        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletedDomainModel = await _walkRepository.DeleteAsync(id);
            var deletedObj = _mapper.Map<DTO.Walk>(deletedDomainModel);

            return Ok(deletedObj);
        }
    }
}
