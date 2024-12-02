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

    public string? ProfilePicture { get; set; }

    public bool IsUserProfileComplete { get; set; } =  false;
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // Navigation properties
    public Role Role { get; set; }
    public Gender Gender { get; set; }
}