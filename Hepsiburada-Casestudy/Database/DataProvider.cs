using Hepsiburada_Casestudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsiburada_Casestudy.Database
{
    public class DataProvider : IDataProvider
    {
        List<ProductModel> products = new List<ProductModel>();
        List<OrderModel> orders = new List<OrderModel>();
        List<CampaignModel> campaigns = new List<CampaignModel>();
    
        public void AddOrder(OrderModel order, string productCode)
        {
            var product = GetProductbyProductCode(productCode);
            product.Stock = product.Stock - order.Quantity;
            orders.Add(new OrderModel()
            {
                ProductCode = order.ProductCode,
                Quantity = order.Quantity,
                Price= product.Price
            });
        }
        public IEnumerable<OrderModel> GetOrdersbyProductCode(string productCode)
        {
            return orders.Where(x => x.ProductCode.Equals(productCode));
        }
        public void AddProduct(ProductModel product)
        {
            products.Add(new ProductModel()
            {
                ProductCode = product.ProductCode,
                Price = product.Price,
                Stock = product.Stock
            });
        }
        public ProductModel GetProductbyProductCode(string productCode)
        {
            return products.Where(x => x.ProductCode.Equals(productCode)).FirstOrDefault();
        }
        public void AddCampaign(CampaignModel campaign)
        {
            campaigns.Add(new CampaignModel()
            {
                Name = campaign.Name,
                ProductCode = campaign.ProductCode,
                Duration = campaign.Duration,
                PMLimit = campaign.PMLimit,
                TargetSalesCount = campaign.TargetSalesCount
            });
        }
        public CampaignModel GetCampaignbyName(string name)
        {
            return campaigns.Where(x => x.Name.Equals(name)).FirstOrDefault();
        }
        public CampaignInfoModel GetCampaignInfo(string name, int systemHour)
        {
            int totalSales = 0;
            int totalPrice = 0;
            var campaign = GetCampaignbyName(name);
            var order = GetOrdersbyProductCode(campaign.ProductCode);
            foreach (var item in order)
            {
                totalSales = totalSales + item.Quantity;
                totalPrice = totalPrice + item.Price;
            }
            int averageSales = totalSales / order.Count();
            int turnover = (totalSales / averageSales) * 100;
            int averageItemPrice = totalPrice / order.Count();
            string status = campaign.GetStatus(systemHour);
            return new CampaignInfoModel()
            {
                Name = name,
                Status = status,
                AverageItemPrice = averageItemPrice,
                TargetSales = campaign.TargetSalesCount,
                TotalSales = totalSales,
                Turnover = turnover
            };
        }

        public CampaignModel GetLastCampaign()
        {
            return campaigns.LastOrDefault();
        }
    }
}
