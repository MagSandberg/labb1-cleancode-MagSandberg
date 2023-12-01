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
using SOLID_DEMO_Tests.Test_Services;

namespace SOLID_DEMO_Tests;

public class CustomerController_Tests
{
    private static readonly ICustomerMapperProfile _customerMapperProfile = new CustomerMapperProfile();

    private static readonly ShopContext_With_CustomerInMemoryDbService _customerInMemoryDbService = new ShopContext_With_CustomerInMemoryDbService();
    private static readonly IUnitOfWorkCustomer _unitOfWork = new UnitOfWorkCustomer(_customerInMemoryDbService.CustomerInMemoryDb().Result, _customerMapperProfile);

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
}
