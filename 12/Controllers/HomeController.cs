using Microsoft.AspNetCore.Mvc;

namespace _12.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MathController : ControllerBase
    {
        [HttpGet("/sum")]
        public IActionResult GetSum([FromQuery] int a, [FromQuery] int b)
        {
            int result = a + b;
            return Ok(new { sum = result });
        }
    }
}