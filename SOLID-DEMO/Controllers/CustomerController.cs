using Microsoft.AspNetCore.Mvc;
using DataAccess.Repositories.Interfaces;
using Shared.DTOs;

namespace Server.Controllers;

[ApiController]
[Route("/api")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerController(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    [HttpGet("/customers")]
    public async Task<IActionResult> GetCustomers()
    {
        var customers = await _customerRepository.GetCustomers();

        if (customers.Count == 0)
        {
            return NotFound("No customers found.");
        }

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
        var result = await _customerRepository.RegisterUser(customerDto);

        if (!result.Equals("User registered successful.")) return BadRequest(result);

        return Ok(result);
    }

    [HttpPost("/customers/login")]
    public async Task<IActionResult> LoginCustomer(string email, string password)
    {
        var result = await _customerRepository.LoginCustomer(email, password);

        return result.Equals("Login successful.") ? Ok(result) : BadRequest(result);
    }

    [HttpPut("/customers/update/{id}")]
    public async Task<IActionResult> UpdateCustomer(CustomerDto customer, Guid id)
    {
        var result = await _customerRepository.UpdateCustomer(customer, id);

        if (!result.Equals("User updated successful.")) return BadRequest(result);

        return Ok(result);
    }

    [HttpDelete("/customers/delete/{id}")]
    public async Task<IActionResult> DeleteCustomer(Guid id)
    {
        var result = await _customerRepository.DeleteCustomer(id);

        return result.Equals("User deleted successful.") ? Ok(result) : BadRequest(result);
    }
}