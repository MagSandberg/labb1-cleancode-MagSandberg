using DataAccess.Repositories;
using DataAccess.Repositories.Interfaces;
using DataAccess.Services.Mapping;
using DataAccess.Services.Mapping.Interfaces;
using DataAccess.UnitOfWork;
using DataAccess.UnitOfWork.Interfaces;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Server.Controllers;
using Shared.DTOs;
using SOLID_DEMO_Tests.Test_ControllerServices;

namespace SOLID_DEMO_Tests.Tests_Controllers;

public class CustomerController_Tests
{
    private static readonly ICustomerMapper CustomerMapper = new CustomerMapper();

    private static readonly ShopContext_With_CustomerInMemoryDbService _customerInMemoryDbService = new ShopContext_With_CustomerInMemoryDbService();
    private static readonly IUnitOfWorkCustomer _unitOfWork = new UnitOfWorkCustomer(_customerInMemoryDbService.CustomerInMemoryDb().Result, CustomerMapper);

    private static readonly ICustomerRepository _customerRepository = new CustomerRepository(_unitOfWork);

    private static readonly CustomerController _customerController = new CustomerController(_customerRepository);


    [Fact]
    public async Task CustomerController_GetCustomers_Return_Ok()
    {
        // Arrange
        var sut = _customerController;

        // Act

        var result = await sut.GetCustomers();

        // Assert

        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task CustomerController_GetCustomers_Return_NotFound()
    {
        // Arrange
        var fakeCustomerRepository = A.Fake<ICustomerRepository>();
        var sut = new CustomerController(fakeCustomerRepository);

        // Act
        var result = await sut.GetCustomers();

        // Assert
        Assert.IsType<NotFoundObjectResult>(result);
    }

    [Fact]
    public async Task CustomerController_GetCustomerByEmail_Return_Ok()
    {
        // Arrange
        var sut = _customerController;

        var customers = await _customerRepository.GetCustomers();
        var customerEmail = customers[0].Email;

        // Act
        var result = await sut.GetCustomerByEmail(customerEmail);

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task CustomerController_GetCustomerByEmail_Return_NotFound()
    {
        // Arrange
        var sut = _customerController;

        // Act
        var result = await sut.GetCustomerByEmail("customerEmail");

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task CustomerController_RegisterUser_Return_Ok()
    {

        // Arrange
        var sut = _customerController;

        // Act
        var result = await sut.RegisterUser(
            new CustomerDto(
                "Firstname",
                "Lastname",
                "first@last.com",
                "123123123"
                )); ;

        // Assert
        Assert.IsType<OkObjectResult>(result);
        var okObjectResult = (OkObjectResult)result;

        var statusCode = okObjectResult.StatusCode;
        var value = okObjectResult.Value;

        Assert.Equal("User registered successful.", value);
        Assert.Equal(200, statusCode);
    }

    [Fact]
    public async Task CustomerController_RegisterUser_Return_BadRequest()
    {
        // Arrange
        var sut = _customerController;

        var customerDto = new CustomerDto(
            "Firstname",
            "Lastname",
            "firstlastcom",
            "123123123"
        );

        // Act
        var result = await sut.RegisterUser(customerDto);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
        var badRequestObjectResult = (BadRequestObjectResult)result;

        var statusCode = badRequestObjectResult.StatusCode;
        var value = badRequestObjectResult.Value;

        Assert.Equal("Invalid email address.", value);
        Assert.Equal(400, statusCode);
    }

    [Fact]
    public async Task CustomerController_RegisterUser_Return_BadRequest_UserExists()
    {
        // Arrange
        var sut = _customerController;

        var customers = await _customerRepository.GetCustomers();
        var customer = customers[0];

        var customerDto = new CustomerDto(customer.FirstName, customer.LastName, customer.Email, customer.Password );

        // Act
        var result = await sut.RegisterUser(customerDto);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
        var badRequestObjectResult = (BadRequestObjectResult)result;

        var statusCode = badRequestObjectResult.StatusCode;
        var value = badRequestObjectResult.Value;

        Assert.Equal("User already exists.", value);
        Assert.Equal(400, statusCode);
    }

    [Fact]
    public async Task CustomerController_LoginCustomer_Return_Ok()
    {
        // Arrange
        var sut = _customerController;

        var customers = await _customerRepository.GetCustomers();
        var customerEmail = customers[0].Email;
        var customerPassword = customers[0].Password;

        // Act
        var result = await sut.LoginCustomer(customerEmail, customerPassword);

        // Assert
        Assert.IsType<OkObjectResult>(result);

        var okObjectResult = (OkObjectResult)result;
        var value = okObjectResult.Value;

        Assert.Equal("Login successful.", value);
    }

    [Fact]
    public async Task CustomerController_LoginCustomer_Return_BadRequest()
    {
        // Arrange
        var sut = _customerController;

        // Act
        var result = await sut.LoginCustomer("customerEmail", "customerPassword");

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);

        var badRequestObjectResult = (BadRequestObjectResult)result;
        var value = badRequestObjectResult.Value;

        Assert.Equal("Invalid email or password.", value);
    }

    [Fact]
    public async Task CustomerController_UpdateCustomer_Return_Ok()
    {
        // Arrange
        var sut = _customerController;

        var customers = await _customerRepository.GetCustomers();
        var customer = customers[0];

        var updatedCustomer = new CustomerDto("Johan", "Falk", customer.Email, customer.Password);

        // Act
        var result = await sut.UpdateCustomer(updatedCustomer, customer.Id);

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task CustomerController_UpdateCustomer_Return_BadRequest()
    {
        // Arrange
        var sut = _customerController;

        var customers = await _customerRepository.GetCustomers();
        var customer = customers[0];

        var updatedCustomer = new CustomerDto("Johan", "Falk", customer.Email, customer.Password);

        // Act
        var result = await sut.UpdateCustomer(updatedCustomer, Guid.NewGuid());

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public async Task CustomerController_DeleteCustomer_Return_Ok()
    {
        // Arrange
        var sut = _customerController;

        var customers = await _customerRepository.GetCustomers();
        var customer = customers[0];

        // Act
        var result = await sut.DeleteCustomer(customer.Id);

        // Assert
        Assert.IsType<OkObjectResult>(result);

        var okObjectResult = (OkObjectResult)result;
        var value = okObjectResult.Value;

        Assert.Equal("User removed successful.", value);
    }

    [Fact]
    public async Task CustomerController_DeleteCustomer_Return_BadRequest()
    {
        // Arrange
        var sut = _customerController;

        // Act
        var result = await sut.DeleteCustomer(Guid.NewGuid());

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);

        var badRequestObjectResult = (BadRequestObjectResult)result;
        var value = badRequestObjectResult.Value;

        Assert.Equal("The ID provided does not exist.", value);
    }
}
