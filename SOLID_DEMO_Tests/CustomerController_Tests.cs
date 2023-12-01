using DataAccess.Models;
using DataAccess.Repositories;
using DataAccess.Repositories.Interfaces;
using DataAccess.Services.Mapping;
using DataAccess.Services.Mapping.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Controllers;
using Server.DataAccess;

namespace SOLID_DEMO_Tests;

public class CustomerController_Tests
{
    //private readonly ShopContext _shopContext;
    //private readonly ICustomerMapperProfile _customerMapper = new CustomerMapperProfile();

    //public CustomerController_Tests(ShopContext shopContext)
    //{
    //    _shopContext = shopContext;
    //}

    //[Fact]
    //public async Task CustomerController_RegisterUser_Return_Ok()
    //{
    //    // Arrange
    //    var repository = new CustomerRepository(_shopContext, _customerMapper);

    //    var sut = new CustomerController(_shopContext, repository);
    //    var customer = new CustomerModel("magnus@email.com", "123123123", "Magnus", "Sandberg");

    //    // Act

    //    var result = await sut.RegisterUser(_customerMapper.MapToCustomerDto(customer));

    //    // Assert
    //    Assert.IsType<OkResult>(result);
    //}
}
