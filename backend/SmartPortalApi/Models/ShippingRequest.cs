namespace SmartPortalApi.Models
{
    public class ShippingRequest
    {
        public double Weight { get; set; }
        public string Region { get; set; } = string.Empty;
        public string Method { get; set; } = string.Empty;
    }
}
