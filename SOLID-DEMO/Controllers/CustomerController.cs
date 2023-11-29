using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using DataAccess.Repositories.Interfaces;
using DataAccess.Services.Mapping;
using DataAccess.Services.Mapping.Interfaces;
using Server.DataAccess;
using Shared.DTOs;

namespace Server.Controllers;

[ApiController]
[Route("/api")]
public class CustomerController : ControllerBase
{
    public ICustomerMapperProfiles CustomerMapper = new CustomerMapperProfile();
    public ShopContext _shopContext;
    public ICustomerRepository _customerRepository;

    public CustomerController(ShopContext shopContext)
    {
        _shopContext = shopContext;
    }

    [HttpGet("/customers")]
    public async Task<IActionResult> GetCustomers()
    {
        var customers = await _customerRepository.GetCustomers();
        return Ok(customers);
    }

    [HttpGet("/customers/{email}")]
    public async Task<IActionResult> GetCustomerByEmail(string email)
    {
        var customer = await _customerRepository.GetCustomerByEmail(email);
        return Ok(customer);
    }

    [HttpPost("/customers/register")]
    public async Task<IActionResult> RegisterUser(CustomerDto customerDto)
    {
        await _customerRepository.RegisterUser(customerDto);

        var result = await RegisterUser(customerDto);
        if (result is OkObjectResult)
        {
            return Ok("Customer successfully registered!");
        }

        return BadRequest("Customer could not register. Are you missing a field?");
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