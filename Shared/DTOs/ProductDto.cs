using System.ComponentModel.DataAnnotations;

namespace Shared.DTOs;

public class ProductDto
{
    public Guid Id { get; init; }

    [Required]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Name is too long or short.")]
    public string Name { get; set; } = string.Empty;

    [Required]
    public double Price { get; set; } = 0.0;

    public string Description { get; set; } = string.Empty;

    public ProductDto(Guid id, string name, double price, string description)
    {
        Id = id;
        Name = name;
        Price = price;
        Description = description;
    }
}