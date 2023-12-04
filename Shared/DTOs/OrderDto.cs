using System.ComponentModel.DataAnnotations;

namespace Shared.DTOs;

public class OrderDto
{
    public Guid Id { get; init; }

    [Required]
    public Guid CustomerId { get; set; }

    [Required]
    public List<Guid> ProductIds { get; set; }

    [Required]
    public DateTime ShippingDate { get; set; }

    public OrderDto(Guid customerId, List<Guid> productIds, DateTime date)
    {
        CustomerId = customerId;
        ProductIds = productIds;
        ShippingDate = date;
    }
}