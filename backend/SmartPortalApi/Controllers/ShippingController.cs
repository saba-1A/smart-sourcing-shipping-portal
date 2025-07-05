using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartPortalApi.Models;

namespace SmartPortalApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShippingController : ControllerBase
    {
        // Hardcoded rates
        private readonly Dictionary<string, double> RegionRates = new()
        {
            { "Asia", 1.2 },
            { "Europe", 1.5 },
            { "US", 1.8 }
        };

        private readonly Dictionary<string, double> MethodRates = new()
        {
            { "Air", 2.0 },
            { "Sea", 1.0 },
            { "Express", 3.5 }
        };

        [HttpPost("calculate")]
        [Authorize]
        public IActionResult Calculate([FromBody] ShippingRequest request)
        {
            if (request.Weight <= 0 || 
                !RegionRates.ContainsKey(request.Region) || 
                !MethodRates.ContainsKey(request.Method))
            {
                return BadRequest(new { message = "Invalid input data." });
            }

            double regionRate = RegionRates[request.Region];
            double methodRate = MethodRates[request.Method];
            double cost = request.Weight * regionRate * methodRate;

            return Ok(new { cost });
        }
    }
}
