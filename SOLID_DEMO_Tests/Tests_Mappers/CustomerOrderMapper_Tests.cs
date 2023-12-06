using DataAccess.Models;
using DataAccess.Services.Mapping;
using DataAccess.Services.Mapping.Interfaces;
using Shared.DTOs;

namespace SOLID_DEMO_Tests.Tests_Mappers;

public class CustomerOrderMapper_Tests
{
    public ICustomerOrderMapper Mapper = new CustomerOrderMapper();

    [Fact]
    public void CustomerOrderMapper_MapToCustomerOrderModel_Return_CustomerOrderModel()
    {
        // Arrange

        var sut = Mapper;

        //Act

        var result = sut.MapToCustomerOrderModel(new CustomerOrderDto(Guid.NewGuid(), 1));

        //Assert

        Assert.IsType<CustomerOrderModel>(result);
    }

    [Fact]
    public void CustomerOrderMapper_MapToCustomerOrderDto_Return_CustomerOrderDto()
    {
        // Arrange

        var sut = Mapper;

        //Act

        var result = sut.MapToCustomerOrderDto(new CustomerOrderModel(Guid.NewGuid(), 1));

        //Assert

        Assert.IsType<CustomerOrderDto>(result);
    }
}