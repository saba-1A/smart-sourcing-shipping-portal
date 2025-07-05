using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartPortalApi.Models;
using SmartPortalApi.Services; // ✅ Access EmailService
using System.Threading.Tasks;

namespace SmartPortalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackingController : ControllerBase
    {
        private readonly EmailService _emailService;

        // ✅ Inject EmailService via constructor
        public TrackingController(EmailService emailService)
        {
            _emailService = emailService;
        }

        // 🔒 Sample in-memory shipment data
        private static List<Shipment> Shipments = new List<Shipment>
        {
            new Shipment { Id = 1, ProductName = "Shoes", TrackingNumber = "TRK123", Status = "Shipped", UserEmail = "aa@example.com" },
            new Shipment { Id = 2, ProductName = "Laptop", TrackingNumber = "TRK456", Status = "Delivered", UserEmail = "aa@example.com" }
        };

        // 👤 Get all shipments for the logged-in user
        [HttpGet]
        [Authorize]
        public IActionResult GetUserShipments()
        {
            var userEmail = User.Claims.FirstOrDefault(c => c.Type.Contains("emailaddress"))?.Value;
            var isAdmin = User.IsInRole("admin");

            if (isAdmin)
                return Ok(Shipments); // ✅ Admin sees all

            var userShipments = Shipments.Where(s => s.UserEmail == userEmail).ToList();
            return Ok(userShipments);
        }

        // 🔍 Lookup shipment by tracking number or ID
        [HttpGet("lookup/{input}")]
        [Authorize]
        public IActionResult LookupShipment(string input)
        {
            var userEmail = User.Claims.FirstOrDefault(c => c.Type.Contains("emailaddress"))?.Value;
            var isAdmin = User.IsInRole("admin");

            var shipment = Shipments.FirstOrDefault(s =>
                s.TrackingNumber.Equals(input, StringComparison.OrdinalIgnoreCase) ||
                s.Id.ToString() == input
            );

            if (shipment == null)
                return NotFound(new { message = "Shipment not found." });

            if (!isAdmin && shipment.UserEmail != userEmail)
                return Forbid();

            return Ok(shipment);
        }

        // ✏️ Admin updates status + sends email
        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] string newStatus)
        {
            var shipment = Shipments.FirstOrDefault(s => s.Id == id);
            if (shipment == null)
                return NotFound(new { message = "Shipment not found." });

            shipment.Status = newStatus;

            try
            {
                // ✅ Email notification
                string subject = $"📦 Shipment {shipment.TrackingNumber} Status Updated";
                string body = $"Hi,\n\nYour shipment '{shipment.ProductName}' is now marked as: {newStatus}.\n\nThanks,\nSmart Portal";
                await _emailService.SendEmailAsync(shipment.UserEmail, subject, body);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Email failed: " + ex.Message);
            }

            return Ok(new { message = "Status updated and email sent." });
        }
    }
}
