using Hepsiburada_Casestudy.Abstract;
using Hepsiburada_Casestudy.Database;
using Hepsiburada_Casestudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hepsiburada_Casestudy.Concrete
{
    public class CampaignService : ICampaignService
    {
        private readonly IDataProvider _dataProvider;
        public CampaignService(IDataProvider dataProvider)
        {
            _dataProvider=dataProvider;
        }
        public void PrintCreateCampaign(string name, string productCode, int duration, int priceManipulationLimit, int targetSalesCount)
        {
            Console.WriteLine($"Campaign created; name {name}, product {productCode}, duration {duration}, limit {priceManipulationLimit}, target sales count {targetSalesCount}");

        }

        public void PrintCampaignInfo(string name, string status, int targetSales, int totalSales, int turnover, int averageItemPrice)
        {
            Console.WriteLine($"Campaign {name} info; Status {status}, Target Sales {targetSales}, Total Sales {totalSales}, Turnover {turnover}, Average Item Price {averageItemPrice}");
        }

        public void PrintIncreaseTime(int hour)
        {
            Console.WriteLine($"Time is {hour}:00");
        }

        public void CalculatePrice(string CampaignName, int hour)
        {
            var campaign = _dataProvider.GetCampaignbyName(CampaignName);
            var order = _dataProvider.GetOrdersbyProductCode(campaign.ProductCode);
            var product = _dataProvider.GetProductbyProductCode(campaign.ProductCode);
            int increase = campaign.PMLimit < 5 ? campaign.PMLimit : 5;
            if (!order.Any())
                product.Price = product.Price - product.Price * increase / 100;
            else
            {
                product.Price = product.Price + product.Price * ((increase * hour) > campaign.PMLimit ? increase : increase * hour) / 100;
            }
        }
    }
}
