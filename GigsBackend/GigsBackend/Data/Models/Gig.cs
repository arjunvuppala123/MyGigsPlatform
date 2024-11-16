using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbLayer.Models;

public class Gig
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public Guid FreelancerId { get; set; }

    [Required]
    public Guid ClientId { get; set; }

    [Required, MaxLength(100)]
    public string Title { get; set; }

    public string? Description { get; set; }

    [Required]
    public Guid CategoryId { get; set; }

    [Required]
    public decimal Price { get; set; }

    [Required]
    public Guid CurrencyId { get; set; }

    public string? Availability { get; set; }

    public string? Gallery { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // Navigation properties
    public User Freelancer { get; set; }
    public User Client { get; set; }
    public Category Category { get; set; }
    public Currency Currency { get; set; }
}