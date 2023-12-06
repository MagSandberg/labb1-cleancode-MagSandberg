using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models;

public class OrderModel
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid OrderId { get; init; }

    [Required]
    public Guid CustomerId { get; set; }

    [Required]
    public DateTime CreationTime { get; init; }

    public DateTime ShippingDate { get; set; }

    public List<CustomerOrderModel> CustomerOrder { get; set; }

    public OrderModel(Guid customerId, DateTime creationTime, DateTime shippingDate)
    {
        CustomerId = customerId;
        CreationTime = creationTime;
        ShippingDate = shippingDate;
        CustomerOrder = new List<CustomerOrderModel>();
    }
}
