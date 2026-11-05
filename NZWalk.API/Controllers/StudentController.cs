using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NZWalk.API.Controllers
{
    // https://localhost:portnumber/api/student
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        // GET: https://localhost:portnumber/api/student
        [HttpGet]
        public IActionResult GetAllStudents() 
        {
            string[] studentNames = new string[] { "John", "Jane", "Bob",  "Alice" };

            return Ok(studentNames);
        }
    }
}
