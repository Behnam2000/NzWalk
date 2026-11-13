using Microsoft.AspNetCore.Mvc;
using NZWalk.API.Models.Domain;
using System.Globalization;

namespace NZWalk.API.Controllers
{
    // https://localhost:portnumber/api/regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : Controller
    
    {
        // GET All Regions
        // GET: api/regions
        [HttpGet]
        public IActionResult GetAll()
        {
            var regions = new List<Region>
            {
                new Region
                {
                    Id = Guid.NewGuid(),
                    Name = "Wellington",
                    Code = "WLG",
                    RegionImageUrl = "https://aworldtolive.com/wp-content/uploads/2021/06/View-from-Mount-Victoria-in-Wellington-PS.jpg "
                },
                new Region
                {
                    Id = Guid.NewGuid(),
                    Name = "Akland",
                    Code = "AKL",
                    RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5e/Auckland_City_Council_Logo.svg/1200px-Auckland_City_Council_Logo.svg.png"
                },
            };

            return Ok(regions);
        }
    }
}
