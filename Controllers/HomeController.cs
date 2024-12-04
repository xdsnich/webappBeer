using Microsoft.AspNetCore.Mvc;
namespace WebAppbotbeer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetData()
        {
            var data = new { message = "Hello from backend!" };
            return Ok(data);
        }
    }
}
