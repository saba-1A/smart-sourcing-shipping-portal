using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SmartPortalApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnalyticsController : ControllerBase
    {
        [HttpGet("summary")]
        [Authorize]

        public IActionResult GetSummary()
        {
            // Dummy data – replace with real database logic
            var result = new
            {
                totalUsers = 150,
                totalRequests = 320,
                pending = 70,
                shipped = 180,
                delivered = 70
            };

            return Ok(result);
        }
    }
}
