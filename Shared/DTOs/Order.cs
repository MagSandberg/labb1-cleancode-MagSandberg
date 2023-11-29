namespace Shared.DTOs;

public class Order
{
    public int Id { get; set; }
    public List<ProductDto> Products { get; set; }
    public CustomerDto CustomerDto { get; set; }
    public DateTime ShippingDate { get; set; }
}