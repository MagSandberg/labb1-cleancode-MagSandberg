using System.ComponentModel.DataAnnotations;

namespace Shared.DTOs;

public class OrderDto
{
    public Guid Id { get; init; }

    [Required]
    public Guid CustomerId { get; set; }

    [Required]
    public DateTime ShippingDate { get; set; }

    [Required]
    public List<OrderProductDto> OrderProducts { get; set; }


    public OrderDto(Guid id, Guid customerId, DateTime date, List<OrderProductDto> orderProducts)
    {
        Id = id;
        CustomerId = customerId;
        ShippingDate = date;
        OrderProducts = orderProducts;
    }
}