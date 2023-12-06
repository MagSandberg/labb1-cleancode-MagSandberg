using System.ComponentModel.DataAnnotations;

namespace Shared.DTOs;

public class ProductDto
{
    public Guid Id { get; init; }

    [Required]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Name is too long or short.")]
    public string Name { get; set; }

    [Required]
    public double Price { get; set; }

    public string Description { get; set; }


    public ProductDto( string name, double price, string description)
    {
        Id = Guid.NewGuid();
        Name = name;
        Price = price;
        Description = description;
    }
}