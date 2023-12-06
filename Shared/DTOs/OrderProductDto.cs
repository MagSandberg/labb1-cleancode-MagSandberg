using System.ComponentModel.DataAnnotations;

namespace Shared.DTOs;

public class OrderProductDto
{
    public Guid OrderProductId { get; init; }

    [Required]
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }

    public OrderProductDto(Guid productId, int quantity)
    {
        OrderProductId = Guid.NewGuid();
        ProductId = productId;
        Quantity = quantity;
    }
}
