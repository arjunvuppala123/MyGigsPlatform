using System.ComponentModel.DataAnnotations;

namespace DbLayer.Models;

public class Category
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required, MaxLength(50)]
    public string Name { get; set; }
}