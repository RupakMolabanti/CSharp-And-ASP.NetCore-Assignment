using Microsoft.AspNetCore.Mvc;

namespace _11.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GreetController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetGreeting([FromQuery] string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest(new { message = "Name parameter is required" });
            }

            var message = $"Hello {name}, Welcome to GBP!";
            return Ok(new { message });
        }
    }
}