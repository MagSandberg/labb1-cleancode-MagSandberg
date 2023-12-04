using Microsoft.EntityFrameworkCore;
using Server.Controllers;
using Shared;
using Shared.DTOs;
using SOLID_DEMO_Tests.Test_Interfaces;

namespace SOLID_DEMO_Tests.Test_Services;

public class MainController_OrderInMemoryDb_Service
{
    private readonly MainController _mainController;

    //public MainController_OrderInMemoryDb_Service()
    //{
    //    _mainController = new MainController(IMainControllerWithShopContext._shopContext);
    //}

    //public async Task<MainController> OrderInMemoryDatabase()
    //{
    //    var mainController = _mainController;

    //    var prodOne = new Product { Name = "Mouse", Description = "Mouse Description" };
    //    var prodTwo = new Product { Name = "Keyboard", Description = "Keyboard Description" };
    //    var prodThree = new Product { Name = "Screen", Description = "Screen Description" };

    //    var customerOne = new CustomerDTO("hej@gimajl.com", "123");

    //    var orderOne = new Order
    //    {
    //        Products = new List<Product> { prodOne, prodTwo, prodThree },
    //        Customer = customerOne,
    //        ShippingDate = DateTime.Now.AddDays(3)
    //    };

    //    await mainController._shopContext.Orders.AddAsync(orderOne);
    //    await mainController._shopContext.SaveChangesAsync();

    //    return mainController;
    //}
}