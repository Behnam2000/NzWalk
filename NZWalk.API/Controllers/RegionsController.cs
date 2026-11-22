using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalk.API.Data;
using NZWalk.API.Models.Domain;
using NZWalk.API.Models.DTO;
using System.Globalization;

namespace NZWalk.API.Controllers
{
    // https://localhost:portnumber/api/regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;

        public RegionsController(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET ALL REGIONS
        // GET: https://localhost:portnumber/api/regions
        [HttpGet]
        public IActionResult GetAll()
        {   
            // Get data from Database - Domain models
            var regionsDomain = dbContext.Regions.ToList();

            // Map Domain Models to DTOs
            var regionsDto = new List<RegionDto>();
            foreach (var regionDomain in regionsDomain)
            {
                regionsDto.Add(new RegionDto()
                {
                    Id = regionDomain.Id,
                    Code = regionDomain.Code,
                    Name = regionDomain.Name,
                    RegionImageUrl = regionDomain.RegionImageUrl
                });
            }

            // Return DTOs
            return Ok(regionsDomain);
        }

        // GET SINGLE REGION BY ID
        // GET: https://localhost/portnumber/api/regions/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            // Find() method is only takes the primary key as the parameter. So, we can use FirstOrDefault() method to find the region by its Id.
            // Get Region Domain Model From Database
            var regionDomain = dbContext.Regions.FirstOrDefault(r => r.Id == id);

            if (regionDomain == null)
            {
                return NotFound(); 
            }

            // Map/Convert Region Domain Model to Region DTO
            var regionDto = new RegionDto
            {
                Id = regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImageUrl = regionDomain.RegionImageUrl
            };

            // Return DTO back to Client
            return Ok(regionDto);
        }

        // POST To Create New Region
        // POST: http://localhost:portnumber/api/regions
        [HttpPost]
        public IActionResult Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            // Map/Convert DTO to Domain Model
            var regionDomainModel = new Region
            {
                Code = addRegionRequestDto.Code,
                Name = addRegionRequestDto.Name,
                RegionImageUrl = addRegionRequestDto.RegionImageUrl
            };

            // Use Domain Model to create Region
            dbContext.Regions.Add(regionDomainModel);
            dbContext.SaveChanges();

            // Map Domain model to DTO
            var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };

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
        public IActionResult Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            // Check for the region
            var regionDomainModel = dbContext.Regions.FirstOrDefault(r => r.Id == id);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            // Map DTO to Domain Model
            regionDomainModel.Code = updateRegionRequestDto.Code;
            regionDomainModel.Name = updateRegionRequestDto.Name;
            regionDomainModel.RegionImageUrl = updateRegionRequestDto.RegionImageUrl;

            dbContext.SaveChanges();

            // Convert Domain Model to DTO
            var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };

            return Ok(regionDto);

        }
    }
}
