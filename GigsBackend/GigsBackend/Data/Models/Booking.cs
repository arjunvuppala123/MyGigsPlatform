using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbLayer.Models;

public class Booking
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public Guid GigId { get; set; }

    [Required]
    public Guid ClientId { get; set; }

    [Required, MaxLength(20)]
    public string Status { get; set; }

    [Required]
    public DateTime ScheduledAt { get; set; }

    [Required, MaxLength(20)]
    public string PaymentStatus { get; set; }

    [Required]
    public decimal Amount { get; set; }

    [Required]
    public Guid CurrencyId { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public Gig Gig { get; set; }
    public User Client { get; set; }
    public Currency Currency { get; set; }
}