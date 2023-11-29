using DataAccess.Models;
using Server.Controllers;
using SOLID_DEMO_Tests.Test_Interfaces;

namespace SOLID_DEMO_Tests.Test_Services;

public class MainController_CustomerInMemoryDb_Service : IMainControllerWithShopContext
{
    private readonly MainController _mainController;

    public MainController_CustomerInMemoryDb_Service()
    {
        _mainController = new MainController(IMainControllerWithShopContext._shopContext);
    }

    public async Task<MainController> CustomerInMemoryDb()
    {
        var customerOne = new CustomerModel("ana@ana.com", "123", "Ana", "Anason");
        var customerTwo = new CustomerModel("bnb@bnb.com", "123", "Bnb", "Bnbson");
        var customerThree = new CustomerModel("cnc@cnc.com", "123", "Cnc", "Cncson");

        await _mainController._shopContext.Customers.AddRangeAsync(customerOne, customerTwo, customerThree);
        await _mainController._shopContext.SaveChangesAsync();

        return _mainController;
    }
}