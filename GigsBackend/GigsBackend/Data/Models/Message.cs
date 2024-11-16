using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbLayer.Models;

public class Message
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public Guid GigId { get; set; }

    [Required]
    public Guid SenderId { get; set; }

    [Required]
    public Guid RecieverId { get; set; }
    
    [Required]
    public string MessageContent { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime SentAt { get; set; } = DateTime.Now;

    public User Sender { get; set; }
    public User Receiver { get; set; }
    public Gig Gig { get; set; }
}