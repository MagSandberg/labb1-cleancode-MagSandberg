using Microsoft.AspNetCore.Mvc;
using DataAccess.Repositories.Interfaces;
using Shared.DTOs;

namespace Server.Controllers;

[ApiController]
[Route("/api")]
public class OrderController : ControllerBase
{
    private readonly IOrderRepository _orderRepository;

    public OrderController(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    [HttpGet("/orders")]
    public async Task<IActionResult> GetOrders()
    {
        var orders = await _orderRepository.GetOrders();

        if (orders.Count == 0) return NotFound("No orders registered.");

        return Ok(orders);
    }

    [HttpGet("/orders/{id}")]
    public async Task<IActionResult> GetOrder(Guid id)
    {
        var order = await _orderRepository.GetOrder(id);

        if (order.Id.Equals(Guid.Empty)) return NotFound("No order found.");
        if (order.CustomerId.Equals(Guid.Empty)) return NotFound("No customer registered for this order.");

        return Ok(order);
    }

    [HttpPost("/orders/add")]
    public async Task<IActionResult> AddOrder(OrderDto orderDto)
    {
        var result = await _orderRepository.AddOrder(orderDto);

        if (!result.Equals("Order added successfully.")) return BadRequest(result);

        return Ok(result);
    }

    [HttpPut("/orders/update")]
    public async Task<IActionResult> UpdateOrder(OrderDto orderDto, Guid id)
    {
        var result = await _orderRepository.UpdateOrder(orderDto, id);

        if (result.Equals("Order does not exist.")) return BadRequest(result);

        return Ok(result);
    }

    [HttpDelete("/orders/delete/{id}")]
    public async Task<IActionResult> DeleteOrder(Guid id)
    {
        var result = await _orderRepository.DeleteOrder(id);

        if (result.Equals("Order does not exist.")) return BadRequest(result);

        return Ok(result);
    }
}