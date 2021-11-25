using Hepsiburada_Casestudy.Abstract;
using Hepsiburada_Casestudy.Concrete;
using Hepsiburada_Casestudy.Database;
using Hepsiburada_Casestudy.Models;
using Hepsiburada_Casestudy.Services.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Hepsiburada_Casestudy.Test
{
    [TestClass]
    public class CampaignUnitTest
    {
        static IDataProvider dataProvider = new DataProvider();
        IProductService productService = new ProductService();
        IOrderService orderService = new OrderService();
        ICampaignService campaignService = new CampaignService(dataProvider);
        [TestMethod]
        public void DoTestPrintCampaignInfo()
        {
            CampaignService businessService = new CampaignService(dataProvider);
            businessService.PrintCampaignInfo("C1", "Actived", 100, 100, 2000, 20);
        }
        [TestMethod]
        public void DoTestPrintIncreaseTime()
        {
            CampaignService businessService = new CampaignService(dataProvider);
            businessService.PrintIncreaseTime(1);

        }
        [TestMethod]
        public void DoTestCalculatePrice()
        {
            CampaignService businessService = new CampaignService(dataProvider);
            var createCampaignBusinessService = CreateCampaignCommandResolver.GetInstance();
            var createOrderBusinessService = CreateOrderCommandResolver.GetInstance();
            var createProductBusinessService = CreateProductCommandResolver.GetInstance();

            createCampaignBusinessService.Execute(new CreateCampaignCommandModel("create_campaign C11 P4 10 20 100", campaignService, dataProvider));
            var Campaign = dataProvider.GetCampaignbyName("C11");
            Assert.AreEqual(Campaign.Name, "C11");
            Assert.AreEqual(Campaign.ProductCode, "P4");
            Assert.AreEqual(Campaign.Duration, 10);
            Assert.AreEqual(Campaign.PMLimit, 20);
            Assert.AreEqual(Campaign.TargetSalesCount, 100);
            createProductBusinessService.Execute(new CreateProductCommandModel("create_product P4 100 1000", productService, dataProvider));
            var Product = dataProvider.GetProductbyProductCode("P4");
            Assert.AreEqual(Product.ProductCode, "P4");
            Assert.AreEqual(Product.Price, 100);
            Assert.AreEqual(Product.Stock, 1000);
            createOrderBusinessService.Execute(new CreateOrderCommandModel("create_order P4 20", orderService, dataProvider));
            var Orders = dataProvider.GetOrdersbyProductCode("P4");
            Assert.IsNotNull(Orders);
            businessService.CalculatePrice("C11", 1);
        }
    }
}

