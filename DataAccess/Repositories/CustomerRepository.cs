using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using DataAccess.Services.Mapping.Interfaces;
using Microsoft.EntityFrameworkCore;
using Server.DataAccess;
using Shared.DTOs;

namespace DataAccess.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly ShopContext _shopContext;
    private readonly ICustomerMapperProfiles _customerMapper;

    public CustomerRepository(ShopContext shopContext)
    {
        _shopContext = shopContext;
    }

    public async Task<List<CustomerDto>> GetCustomers()
    {
        var customers = await _shopContext.Customers.ToListAsync();
        var customerDtos = new List<CustomerDto>();

        foreach (var customer in customers)
        {
            customerDtos.Add(_customerMapper.MapToCustomerDto(customer));
        }

        return customerDtos;
    }

    public async Task<CustomerDto> GetCustomerByEmail(string email)
    {
        var customer = await _shopContext.Customers.FirstOrDefaultAsync(c => c.Email.Equals(email));
        return _customerMapper.MapToCustomerDto(customer);
    }

    public async Task RegisterUser(CustomerDto customer)
    {
        await _shopContext.AddAsync(_customerMapper.MapToCustomerModel(customer));
        await _shopContext.SaveChangesAsync();
    }

    public async Task UpdateCustomer(CustomerDto customer)
    {
        var customerToUpdate = await _shopContext.Customers.FirstOrDefaultAsync(c => c.CustomerId.Equals(customer.CustomerId));
        customerToUpdate = _customerMapper.MapToCustomerModel(customer);
        await _shopContext.SaveChangesAsync();
    }

    public async Task DeleteCustomer(Guid id)
    {
        var customerToDelete = await _shopContext.Customers.FirstOrDefaultAsync(c => c.CustomerId.Equals(id));
        _shopContext.Remove(customerToDelete);
        await _shopContext.SaveChangesAsync();
    }
}