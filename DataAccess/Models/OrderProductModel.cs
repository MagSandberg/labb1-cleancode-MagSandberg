using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models;

public class OrderProductModel
{
    public Guid OrderProductId { get; init; }

    [Required]
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }

    public OrderProductModel(Guid productId, int quantity)
    {
        OrderProductId = Guid.NewGuid();
        ProductId = productId;
        Quantity = quantity;
    }
}