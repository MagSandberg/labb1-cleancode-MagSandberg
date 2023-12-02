using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models;

public class ProductModel
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid ProductId { get; set; }

    [MaxLength(50), Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public double Price { get; set; } = 0.0;

    public string Description { get; set; } = string.Empty;

    public ProductModel(Guid productId, string name, double price, string description)
    {
        ProductId = productId;
        Name = name;
        Price = price;
        Description = description;
    }
}