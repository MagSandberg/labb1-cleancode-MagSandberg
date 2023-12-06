namespace Shared.DTOs;

public class CustomerOrderDto
{
    public Guid Id { get; set; }
    public Guid ProductId { get; init; }
    public int Quantity { get; set; }

    public CustomerOrderDto(Guid productId, int quantity)
    {
        Id = Guid.NewGuid();
        ProductId = productId;
        Quantity = quantity;
    }
}