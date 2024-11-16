using System.ComponentModel.DataAnnotations;

namespace DbLayer.Models;

public class Currency
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required, MaxLength(10)]
    public string Code { get; set; }

    [Required, MaxLength(50)]
    public string Name { get; set; }
}