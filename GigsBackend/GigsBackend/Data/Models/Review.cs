using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbLayer.Models;

public class Review
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public Guid GigId { get; set; }

    [Required]
    public Guid ClientId { get; set; }

    public int Rating { get; set; }

    public string? ReviewText { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    
    // Navigation properties
    public Gig Gig { get; set; }
    public Client Client { get; set; }
}