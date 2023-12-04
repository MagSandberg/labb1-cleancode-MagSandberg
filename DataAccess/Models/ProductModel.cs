using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models;

public class ProductModel
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid ProductId { get; set; }

    [MaxLength(50), Required]
    public string Name { get; set; }

    [Required]
    public double Price { get; set; }

    public string Description { get; set; }

    public ICollection<OrderProductModel> OrderProducts { get; set; }


    public ProductModel()
    {
    }

    public ProductModel(Guid productId, string name, double price, string description, ICollection<OrderProductModel> orderProducts)
    {
        ProductId = productId;
        Name = name;
        Price = price;
        Description = description;
        OrderProducts = orderProducts;
    }
}