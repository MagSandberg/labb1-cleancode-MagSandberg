using DataAccess.Models;
using DataAccess.Services.Mapping;
using DataAccess.Services.Mapping.Interfaces;
using Shared.DTOs;

namespace SOLID_DEMO_Tests.Tests_Mappers;

public class CustomerMapper_Tests
{
    public ICustomerMapper Mapper = new CustomerMapper();

    [Fact]
    public void CustomerMapper_MapToCustomerModel_Return_CustomerModel()
    {
        // Arrange

        var sut = Mapper;

        //Act

        var result = sut.MapToCustomerModel(new CustomerDto("Test", "Test", "Test", "Test"));

        //Assert

        Assert.IsType<CustomerModel>(result);
    }

    [Fact]
    public void CustomerMapper_MapToCustomerDto_Return_CustomerDto()
    {
        // Arrange

        var sut = Mapper;

        //Act

        var result = sut.MapToCustomerDto(new CustomerModel("Test", "Test", "Test", "Test"));

        //Assert

        Assert.IsType<CustomerDto>(result);
    }
}