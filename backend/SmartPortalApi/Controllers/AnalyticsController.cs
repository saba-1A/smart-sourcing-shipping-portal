using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SmartPortalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin")] // 👑 Admin only
    public class AnalyticsController : ControllerBase
    {
        [HttpGet("summary")]
        public IActionResult GetSummary()
        {
            // 🧪 Fake analytics data
            var data = new
            {
                totalUsers = 12,
                totalRequests = 28,
                shipped = 10,
                delivered = 7,
                pending = 11
            };

            return Ok(data);
        }
    }
}
