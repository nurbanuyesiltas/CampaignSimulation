using Hepsiburada_Casestudy.Abstract;
using Hepsiburada_Casestudy.Concrete;
using Hepsiburada_Casestudy.Database;
using Hepsiburada_Casestudy.Managers;
using Hepsiburada_Casestudy.System;
using Hepsiburada_Casestudy.Validator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hepsiburada_Casestudy.Test
{
    [TestClass]
    public class ManagerUnitTest
    {
        static IDataProvider dataProvider = new DataProvider();
        ICampaignService campaignService = new CampaignService(dataProvider);
        IOrderService orderService = new OrderService();
        IProductService productService = new ProductService();
        ITimeProvider timeProvider = new TimeProvider();
        ICommandValidator commandValidator = new CommandValidator();
        [TestMethod]
        public void DoTestCampaignSimulation()
        {
            CampaignSimulationManager businessService = new CampaignSimulationManager(campaignService, orderService, productService, dataProvider, timeProvider, commandValidator);
            businessService.CampaignSimulation("Scenario1.txt");

        }
    }
}

