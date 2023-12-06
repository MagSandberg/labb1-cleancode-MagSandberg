using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models;

public class ProductModel
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid ProductId { get; init; }

    [MaxLength(50), Required]
    public string Name { get; set; }

    [Required]
    public double Price { get; set; }

    public string Description { get; set; }


    public ProductModel(string name, double price, string description)
    {
        ProductId = Guid.NewGuid();
        Name = name;
        Price = price;
        Description = description;
    }
}