using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbLayer.Models;

public class Calendar
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public Guid UserId { get; set; }

    [Required, MaxLength(50)]
    public string ExternalService { get; set; }

    [Required]
    public string CalendarLink { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime SyncedAt { get; set; } = DateTime.Now;

    public User User { get; set; }
}