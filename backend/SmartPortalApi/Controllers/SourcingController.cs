using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartPortalApi.Models;
using System.Security.Claims;

namespace smart_portal_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SourcingController : ControllerBase
    {
        private static List<SourcingRequest> _requests = new();
        private static int _nextId = 1;

        [HttpPost]
        [Authorize]
        public IActionResult SubmitRequest([FromBody] SourcingRequest request)
        {
            // ✅ Get email from JWT token
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            if (email == null)
                return Unauthorized(new { message = "Invalid token. Please login again." });

            // ✅ Set ID and Email (don't expect it from frontend)
            request.Id = _nextId++;
            request.UserEmail = email;

            _requests.Add(request);

            return Ok(new { message = "Sourcing request submitted!" });
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetMyRequests()
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            if (email == null)
                return Unauthorized(new { message = "Invalid token. Please login again." });

            var myRequests = _requests.Where(r => r.UserEmail == email).ToList();
            return Ok(myRequests);
        }
    }
}
