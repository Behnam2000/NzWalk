using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalk.API.Models.Domain;
using NZWalk.API.Models.DTO;
using NZWalk.API.Repositories;

namespace NZWalk.API.Controllers
{
    // api/walks
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;

        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }

        // Create Walk 
        // POST: /api/walks
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            // Map DTO to Domain Model
            var walkDomainModel = mapper.Map<Walk>(addWalkRequestDto);

            await walkRepository.CreateAsync(walkDomainModel);

            // Map Domain Model back to DTO & return the response
            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }

        // GET Walks
        // GET: /api/walks
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var walks = await walkRepository.GetAllAsync();

            // Map Domain Models to DTOs & return 
            return Ok(mapper.Map<List<WalkDto>>(walks));
        }

        // GET Walk by Id
        // GET: /api/walks/{id}
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walkDomainModel = await walkRepository.GetByIdAsync(id);

            if (walkDomainModel == null)
            {
                return NotFound();
            }

            // Map Domain Model to DTO & return

            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }

        // Update Walk By Id
        // PUT: /api/walks/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWalksRequestDto updateWalksRequestDto)
        {
            // Map DTO to Domain Model
            var walkDomainModel = mapper.Map<Walk>(updateWalksRequestDto);

            // Update Walk using Repository
            walkDomainModel = await walkRepository.UpdateAsync(id, walkDomainModel);

            // If null, then Walk with the given Id does not exist
            if (walkDomainModel == null)
            {
                return NotFound();
            }

            // Map Domain Model back to DTO & return the response
            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }

        // Delete a Walk By Id
        // DELETE: /api/Walks/
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedWalkDomainModel = await walkRepository.DeleteAsync(id);

            if (deletedWalkDomainModel == null)
            {
                return NotFound();
            }

            // Map Domain Model back to DTO & return the response
            return Ok(mapper.Map<WalkDto>(deletedWalkDomainModel));
        }
    }
}
