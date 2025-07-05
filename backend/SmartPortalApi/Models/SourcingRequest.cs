using System.ComponentModel.DataAnnotations;

public class SourcingRequest
{
    public int Id { get; set; }

    [Required]
    public string ProductName { get; set; }

    [Required]
    public string ProductLink { get; set; }

    [Range(1, int.MaxValue)]
    public int Quantity { get; set; }

    public string? Notes { get; set; }

    public string UserEmail { get; set; }
}
