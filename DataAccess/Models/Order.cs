using DataAccess.Models;

namespace Shared;

public class Order
{
    public int Id { get; set; }
    public List<ProductModel> Products { get; set; }
    public CustomerModel CustomerModel { get; set; }
    public DateTime ShippingDate { get; set; }
}