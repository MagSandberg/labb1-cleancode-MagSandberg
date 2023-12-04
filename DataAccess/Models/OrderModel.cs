using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models;

public class OrderModel
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid OrderId { get; set; }

    [Required]
    public Guid CustomerId { get; set; }

    public ICollection<OrderProductModel> OrderProducts { get; set; }

    [Required]
    public DateTime ShippingDate { get; set; }


    public OrderModel()
    {
        
    }

    public OrderModel(Guid customerId, DateTime shippingDate, ICollection<OrderProductModel> orderProducts)
    {
        CustomerId = customerId;
        ShippingDate = shippingDate;
        OrderProducts = orderProducts;
    }
}
