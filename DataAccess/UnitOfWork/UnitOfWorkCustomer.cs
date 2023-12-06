using DataAccess.Contexts;
using DataAccess.Services.Mapping.Interfaces;
using DataAccess.UnitOfWork.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shared.DTOs;

namespace DataAccess.UnitOfWork;

public class UnitOfWorkCustomer : IUnitOfWorkCustomer
{
    private readonly ICustomerMapper? _customerMapper;
    private readonly ShopContext _shopContext;

    public UnitOfWorkCustomer(ShopContext shopContext, ICustomerMapper? customerMapper)
    {
        _shopContext = shopContext;
        _customerMapper = customerMapper;
    }

    public async Task<List<CustomerDto>> GetCustomers()
    {
        var customers = await _shopContext.Customers.ToListAsync();

        if (customers.Count == 0) return new List<CustomerDto>();

        return customers.Select(customer => _customerMapper.MapToCustomerDto(customer)).ToList();
    }

    public async Task<CustomerDto> GetCustomerByEmail(string email)
    {
        var customer = await _shopContext.Customers.FirstOrDefaultAsync(c => c.Email.Equals(email));

        if (!email.Contains('@')) return new CustomerDto("", "", "You forgot the @", "");

        if (customer == null) return new CustomerDto("", "", "Customer does not exist.", "");

        return _customerMapper!.MapToCustomerDto(customer);
    }

    public async Task<string> RegisterUser(CustomerDto customer)
    {
        var customerExists = await _shopContext.Customers.FirstOrDefaultAsync(c => c.Email.Equals(customer.Email));

        if (customerExists is not null) return "User already exists.";
        if (!customer.Email.Contains('@')) return "Invalid email address.";

        await _shopContext.Customers.AddAsync(_customerMapper!.MapToCustomerModel(customer));
        var result = await _shopContext.SaveChangesAsync();

        return result > 0 ? "User registered successful." : "Failed to register user.";
    }

    public async Task<string> UpdateCustomer(CustomerDto customer, Guid id)
    {
        var customerToUpdate = await _shopContext.Customers.FirstOrDefaultAsync(c => c.CustomerId.Equals(id));

        if (customerToUpdate == null) return "Customer does not exist.";
        if (customerToUpdate.CustomerId.Equals(Guid.Empty)) return "Customer Id does not exist.";

        if (customerToUpdate.FirstName.Equals(customer.FirstName) &&
            customerToUpdate.LastName.Equals(customer.LastName) &&
            customerToUpdate.Email.Equals(customer.Email) &&
            customerToUpdate.Password.Equals(customer.Password))
            return "No changes made.";

        customerToUpdate.FirstName = customer.FirstName;
        customerToUpdate.LastName = customer.LastName;
        customerToUpdate.Email = customer.Email;
        customerToUpdate.Password = customer.Password;

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

        if (customerToDelete == null) return "The ID provided does not exist.";

        _shopContext.Customers.Remove(customerToDelete);
        var result = await _shopContext.SaveChangesAsync();

        return result > 0 ? "User removed successful." : "Failed to remove user.";
    }
}