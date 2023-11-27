namespace Shared.DTOs;

public class Order
{
    public int Id { get; set; }
    public List<Product> Products { get; set; }
    public CustomerDTO CustomerDto { get; set; }
    public DateTime ShippingDate { get; set; }
}