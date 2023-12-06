using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.DTOs;

public class OrderDto
{
    public Guid Id { get; init; }

    [Required]
    public Guid CustomerId { get; }

    [Required]
    public DateTime CreationTime { get; set; }

    public DateTime ShippingDate { get; set; }

    public List<CustomerOrderDto> CustomerOrder { get; set; }

    public OrderDto(Guid customerId, DateTime creationTime, DateTime shippingDate)
    {
        Id = Guid.NewGuid();
        CustomerId = customerId;
        CreationTime = creationTime;
        ShippingDate = shippingDate;
        CustomerOrder = new List<CustomerOrderDto>();
    }
}