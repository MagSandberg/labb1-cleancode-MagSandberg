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

        var customerOrderDto = new CustomerOrderDto(Guid.NewGuid(), 1);
        var expectedId = customerOrderDto.Id;

        // Act

        var actualId = customerOrderDto.Id;
        var result = sut.MapToCustomerOrderModel(new CustomerOrderDto(Guid.NewGuid(), 1));

        //Assert

        Assert.IsType<CustomerOrderModel>(result);
        Assert.Equal(expectedId, actualId);
    }

    [Fact]
    public void CustomerOrderMapper_MapToCustomerOrderDto_Return_CustomerOrderDto()
    {
        // Arrange

        var sut = Mapper;

        var customerOrderModel = new CustomerOrderModel(Guid.NewGuid(), 1);
        var expectedId = customerOrderModel.Id;

        //Act

        var actualId = customerOrderModel.Id;
        var result = sut.MapToCustomerOrderDto(new CustomerOrderModel(Guid.NewGuid(), 1));

        //Assert

        Assert.IsType<CustomerOrderDto>(result);
        Assert.Equal(expectedId, actualId);
    }
}