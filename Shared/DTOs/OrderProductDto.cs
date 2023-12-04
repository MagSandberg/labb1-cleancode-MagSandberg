
namespace Shared.DTOs;

public class OrderProductDto
{
    public Guid OrderProductId { get; set; }
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }


    public OrderProductDto(Guid orderProductId, Guid orderId, Guid productId)
    {
        OrderProductId = orderProductId;
        OrderId = orderId;
        ProductId = productId;
    }
}