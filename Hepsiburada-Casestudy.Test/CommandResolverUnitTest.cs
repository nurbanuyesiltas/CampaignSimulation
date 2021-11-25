using Hepsiburada_Casestudy.Abstract;
using Hepsiburada_Casestudy.Concrete;
using Hepsiburada_Casestudy.Database;
using Hepsiburada_Casestudy.Models;
using Hepsiburada_Casestudy.Services.Concrete;
using Hepsiburada_Casestudy.System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hepsiburada_Casestudy.Test
{
    [TestClass]
    public class CommandResolverUnitTest
    {
        static IDataProvider dataProvider = new DataProvider();
        IProductService productService = new ProductService();
        IOrderService orderService = new OrderService();
        ICampaignService campaignService = new CampaignService(dataProvider);
        ITimeProvider timeProvider = new TimeProvider();
        [TestMethod]
        public void DoTestCreateProductCommandResolver()
        {
            var businessService = CreateProductCommandResolver.GetInstance();
            businessService.Execute(new CreateProductCommandModel("create_product P4 100 1000", productService, dataProvider));
        }
        [TestMethod]
        public void DoTestCreateCampaignCommandResolver()
        {
            var businessService = CreateCampaignCommandResolver.GetInstance();
            businessService.Execute(new CreateCampaignCommandModel("create_campaign C11 P11 10 20 100", campaignService, dataProvider));
        }
        [TestMethod]
        public void DoTestCreateOrderCommandResolver()
        {
            var businessService = CreateOrderCommandResolver.GetInstance();
            var createProductBusinessService = CreateProductCommandResolver.GetInstance();

            createProductBusinessService.Execute(new CreateProductCommandModel("create_product P4 100 1000", productService, dataProvider));
            var Product = dataProvider.GetProductbyProductCode("P4");
            Assert.AreEqual(Product.ProductCode, "P4");
            Assert.AreEqual(Product.Price, 100);
            Assert.AreEqual(Product.Stock, 1000);
            businessService.Execute(new CreateOrderCommandModel("create_order P4 20", orderService, dataProvider));
        }
        [TestMethod]
        public void DoTestCampaignInfoCommandResolver()
        {
            var businessService = CampaignInfoCommandResolver.GetInstance();
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
            businessService.Execute(new CampaignInfoCommandModel("get_campaign_info C11", campaignService, timeProvider, dataProvider));
        }
        [TestMethod]
        public void DoTestIncreaseTimeCommandResolver()
        {
            var businessService = IncreaseTimeCommandResolver.GetInstance();
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
            businessService.Execute(new IncreaseTimeCommandModel("increase_time 1", timeProvider, campaignService, dataProvider));
        }
        [TestMethod]
        public void DoTestProductInfoCommandResolver()
        {
            var businessService = ProductInfoCommandResolver.GetInstance();
            var createProductBusinessService = CreateProductCommandResolver.GetInstance();

            createProductBusinessService.Execute(new CreateProductCommandModel("create_product P4 100 1000", productService, dataProvider));
            var Product = dataProvider.GetProductbyProductCode("P4");
            Assert.AreEqual(Product.ProductCode, "P4");
            Assert.AreEqual(Product.Price, 100);
            Assert.AreEqual(Product.Stock, 1000);
            businessService.Execute(new ProductInfoCommandModel("get_product_info P4", productService, dataProvider));
        }
    }
}

