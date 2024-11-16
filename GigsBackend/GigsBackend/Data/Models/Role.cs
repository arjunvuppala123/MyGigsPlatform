using System.ComponentModel.DataAnnotations;

namespace DbLayer.Models;

public class Role
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required, MaxLength(4)]
    public string RoleCode { get; set; }

    [Required, MaxLength(50)]
    public string RoleDescription { get; set; }
}