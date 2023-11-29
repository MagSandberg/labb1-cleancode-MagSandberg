using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Server.DataAccess;
using Server.Services.Mapping;
using Server.Services.Mapping.Interfaces;
using Shared.DTOs;

namespace Server.Controllers;

[ApiController]
[Route("/api")]
public class CustomerController : ControllerBase
{
    public ICustomerMapperProfiles CustomerMapper = new CustomerMapperProfile();
    public ShopContext _shopContext;

    public CustomerController(ShopContext shopContext)
    {
        _shopContext = shopContext;
    }

    [HttpGet("/customers")]
    public async Task<IActionResult> GetCustomers()
    {
        return Ok(await _shopContext.Customers.ToListAsync());
    }

    //Fix this to use email
    [HttpGet("/customers/{email}")]
    public async Task<IActionResult> GetCustomer(string email)
    {
        return Ok(await _shopContext.Customers.FirstOrDefaultAsync(c => c.Email.Equals(email)));
    }

    //Change model to include email or remove @ check
    [HttpPost("/customers/register")]
    public async Task<IActionResult> RegisterUser(CustomerDto customerDto)
    {
        if (!customerDto.Email.Contains("@"))
            throw new ValidationException("Email is not an email");
        await _shopContext.AddAsync(CustomerMapper.MapToCustomerModel(customerDto));
        await _shopContext.SaveChangesAsync();
        return Ok();
    }

    //Fix this to use email
    [HttpPost("/customers/login")]
    public async Task<IActionResult> LoginCustomer(string email, string password)
    {
        var customer = await _shopContext.Customers.FirstOrDefaultAsync(c => c.Email.Equals(email) && c.Password.Equals(password));
        if (customer is not null)
        {
            return Ok();
        }
        return BadRequest();
    }

    [HttpDelete("/customers/delete/{id}")]
    public async Task<IActionResult> DeleteCustomer(Guid id)
    {
        var customer = await _shopContext.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
        if (customer is null) return BadRequest();

        _shopContext.Customers.Remove(customer);
        await _shopContext.SaveChangesAsync();
        return Ok();
    }
}