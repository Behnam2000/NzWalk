using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalk.API.Data;
using NZWalk.API.Models.Domain;
using NZWalk.API.Models.DTO;
using NZWalk.API.Repositories;
using System.Globalization;

namespace NZWalk.API.Controllers
{
    // https://localhost:portnumber/api/regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(NZWalksDbContext dbContext, IRegionRepository regionRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        // GET ALL REGIONS
        // GET: https://localhost:portnumber/api/regions
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Get data from Database - Domain models
            var regionsDomain = await regionRepository.GetAllAsync();

            // Map Domain Models to DTOs
            // Return DTOs
            return Ok(mapper.Map<List<RegionDto>>(regionsDomain));
        }

        // GET SINGLE REGION BY ID
        // GET: https://localhost/portnumber/api/regions/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            // Find() method is only takes the primary key as the parameter. So, we can use FirstOrDefault() method to find the region by its Id.
            // Get Region Domain Model From Database
            var regionDomain = await regionRepository.GetByIdAsync(id);

            if (regionDomain == null)
            {
                return NotFound(); 
            }

            // Map/Convert Region Domain Model to Region DTO
            // Return DTO back to Client
            return Ok(mapper.Map<RegionDto>(regionDomain));
        }

        // POST To Create New Region
        // POST: http://localhost:portnumber/api/regions
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            // Map/Convert DTO to Domain Model
            var regionDomainModel = mapper.Map<Region>(addRegionRequestDto);

            // Use Domain Model to create Region
            regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);

            // Map Domain model to DTO
            var regionDto = mapper.Map<RegionDto>(regionDomainModel);

            return CreatedAtAction(
                nameof(GetById),           // 1. Action name: "GetById"
                new { id = regionDto.Id }, // 2. Route values to fill in the URL
                regionDto                  // 3. Response body (JSON)
            );

        }

        // Update Region
        // PUT: https://localhost:portnumber/api/regions/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            // Map DTO to Domain Model
            var regionDomainModel = mapper.Map<Region>(updateRegionRequestDto);

            regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);
            
            if (regionDomainModel == null)
            {
                return NotFound();
            }

            // Convert Domain Model to DTO & return back to client
            return Ok(mapper.Map<RegionDto>(regionDomainModel));

        }

        // Delete Region
        // DELETE: https://localhost:portnumber/api/regions/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomainModel = await regionRepository.DeleteAsync(id);

            // Check if the region is existed or not
            if (regionDomainModel == null)
            {
                return NotFound();
            }

            // return deleted region back
            // map Domain Model to DTO
            return Ok(mapper.Map<RegionDto>(regionDomainModel));

        }

    }
}
