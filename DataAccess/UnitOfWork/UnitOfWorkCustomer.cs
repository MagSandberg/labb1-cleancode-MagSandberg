﻿using DataAccess.Services.Mapping.Interfaces;
using DataAccess.UnitOfWork.Interfaces;
using Microsoft.EntityFrameworkCore;
using Server.DataAccess;
using Shared.DTOs;

namespace DataAccess.UnitOfWork;

public class UnitOfWorkCustomer : IUnitOfWorkCustomer
{
    private readonly ShopContext _shopContext;
    private readonly ICustomerMapperProfile? _customerMapper;

    public UnitOfWorkCustomer(ShopContext shopContext, ICustomerMapperProfile? customerMapper)
    {
        _shopContext = shopContext;
        _customerMapper = customerMapper;
    }

    public async Task<List<CustomerDto>> GetCustomers()
    {
        var customers = await _shopContext.Customers.ToListAsync();

        return customers.Select(customer => _customerMapper!.MapToCustomerDto(customer)).ToList();
    }

    public async Task<CustomerDto> GetCustomerByEmail(string email)
    {
        var customer = await _shopContext.Customers.FirstOrDefaultAsync(c => c.Email.Equals(email));

        if (customer == null)
        {
            return new CustomerDto(email, "Customer does not exist", "***", "***", Guid.Empty);
        }

        return _customerMapper!.MapToCustomerDto(customer);
    }

    public async Task<string> RegisterUser(CustomerDto customer)
    {
        var customerExists = await _shopContext.Customers.FirstOrDefaultAsync(c => c.Email.Equals(customer.Email));
        if (customerExists is not null) return "User already exists.";

        await _shopContext.Customers.AddAsync(_customerMapper!.MapToCustomerModel(customer));
        var result = await _shopContext.SaveChangesAsync();

        return result > 0 ? "User registered successful." : "Failed to register user.";
    }

    public async Task<string> UpdateCustomer(CustomerDto customer, Guid id)
    {
        var customerToUpdate = await _shopContext.Customers.FirstOrDefaultAsync(c => c.CustomerId.Equals(id));

        if (_customerMapper != null) customerToUpdate = _customerMapper.MapToCustomerModel(customer);
        if (customerToUpdate != null) _shopContext.Customers.Update(customerToUpdate);

        var result = await _shopContext.SaveChangesAsync();

        return result > 0 ? "User updated successful." : "Failed to update user.";
    }

    public async Task<string> LoginCustomer(string email, string password)
    {
        var result = await _shopContext.Customers.FirstOrDefaultAsync(c => c.Email == email && c.Password == password);

        return result != null ? "Login successful." : "Invalid email or password.";
    }

    public async Task<string> DeleteCustomer(Guid id)
    {
        var customerToDelete = await _shopContext.Customers.FirstOrDefaultAsync(c => c.CustomerId.Equals(id));
        
        if (customerToDelete == null) return "Customer does not exist.";

        _shopContext.Customers.Remove(customerToDelete);
        var result = await _shopContext.SaveChangesAsync();

        return result > 0 ? "User removed successful." : "Failed to remove user.";

    }

}