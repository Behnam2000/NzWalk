using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalk.API.Data;
using NZWalk.API.Models.Domain;
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
            var regions = dbContext.Regions.ToList();

            return Ok(regions);
        }

        // GET SINGLE REGION BY ID
        // GET: https://localhost/portnumber/api/regions/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            // Find() method is only takes the primary key as the parameter. So, we can use FirstOrDefault() method to find the region by its Id.
            var region = dbContext.Regions.FirstOrDefault(r => r.Id == id);

            if (region == null)
            {
                return NotFound(); 
            }

            return Ok(region);
        }
    }
}
