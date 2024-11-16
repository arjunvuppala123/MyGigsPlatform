using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbLayer.Models;

public class User
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public Guid RoleId { get; set; }
    
    [Required]
    public Guid GenderId { get; set; }
    
    [Required, MaxLength(100)]
    public string Name { get; set; }

    [Required, MaxLength(100)]
    [EmailAddress]
    public string Email { get; set; }

    [Required, MaxLength(255)]
    public string PasswordHash { get; set; }

    public string? ProfilePicture { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // Navigation properties
    public Role Role { get; set; }
    public Gender Gender { get; set; }
}