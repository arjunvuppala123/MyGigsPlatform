using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbLayer.Models;

public class Payment
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public Guid BookingId { get; set; }

    [Required, MaxLength(50)]
    public string PaymentGateway { get; set; }

    [Required, MaxLength(100)]
    public string PaymentReference { get; set; }

    [Required]
    public decimal Amount { get; set; }

    [Required]
    public Guid CurrencyId { get; set; }

    [Required, MaxLength(20)]
    public string Status { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    
    // Navigation properties
    public Booking Booking { get; set; }
    public Currency Currency { get; set; }
}