namespace SmartPortalApi.Models
{
    public class Shipment
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = "";
        public string TrackingNumber { get; set; } = "";
        public string Status { get; set; } = "Requested"; // default
        public string UserEmail { get; set; } = "";
    }
}
