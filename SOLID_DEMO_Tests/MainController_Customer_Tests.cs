using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Controllers;
using Server.DataAccess;
using Shared;

namespace SOLID_DEMO_Tests
{
    public class MainController_Customer_Tests
    {
        public static DbContextOptions _options = new DbContextOptionsBuilder<ShopContext>()
            .UseInMemoryDatabase(databaseName: "InMemory_CustomersDb")
            .Options;
        public static ShopContext _shopContext = new ShopContext(_options);
        public static MainController _mainController = new MainController(_shopContext);

        [Fact]
        public void MainController_RegisterUser_Return_Ok()
        {
            //Arrange

            var sut = _mainController;

            //Act

            var result = sut.RegisterUser(new Customer("Magnus", "123")).Result;
            
            //Assert

            Assert.Equal("Magnus", "123");

        }

        [Fact]
        public void MainController_GetCustomers_Return_ListOfCustomers()
        {
            //Arrange

            var sut = _mainController;

            //Act

            var result = sut.GetCustomers().Result;

            //Assert

            Assert.IsType<OkObjectResult>(result);

        }
    }
}