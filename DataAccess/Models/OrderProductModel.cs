using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models;

public class OrderProductModel
{
    [Key]
    public Guid OrderProductId { get; set; }

    public Guid OrderId { get; set; }
    public OrderModel? Order { get; set; }

    public Guid ProductId { get; set; }
    public ProductModel? Product { get; set; }


    public OrderProductModel(Guid orderId, Guid productId)
    {
        OrderId = orderId;
        ProductId = productId;
    }
}