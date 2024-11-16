using System.ComponentModel.DataAnnotations;

namespace DbLayer.Models;

public class Gender
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required, MaxLength(20)]
    public string Name { get; set; } 
}