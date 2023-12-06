using DataAccess.Repositories.Interfaces;
using DataAccess.UnitOfWork.Interfaces;
using Shared.DTOs;

namespace DataAccess.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly IUnitOfWorkCustomer _unitOfWorkCustomer;

    public CustomerRepository(IUnitOfWorkCustomer unitOfWorkCustomer)
    {
        _unitOfWorkCustomer = unitOfWorkCustomer;
    }

    public async Task<List<CustomerDto>> GetCustomers()
    {
        var customers = await _unitOfWorkCustomer.GetCustomers();

        return customers.ToList();
    }

    public async Task<CustomerDto> GetCustomerByEmail(string email)
    {
        var customer = await _unitOfWorkCustomer.GetCustomerByEmail(email);

        return customer;
    }

    public async Task<string> RegisterUser(CustomerDto customer)
    {
        var result = await _unitOfWorkCustomer.RegisterUser(customer);

        return result;
    }

    public async Task<string> UpdateCustomer(CustomerDto customer, Guid id)
    {
        var result = await _unitOfWorkCustomer.UpdateCustomer(customer, id);

        return result;
    }

    public async Task<string> LoginCustomer(string email, string password)
    {
        var result = await _unitOfWorkCustomer.LoginCustomer(email, password);

        return result;
    }

    public async Task<string> DeleteCustomer(Guid id)
    {
        var result = await _unitOfWorkCustomer.DeleteCustomer(id);

        return result;
    }
}