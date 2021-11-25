using Hepsiburada_Casestudy.Models;
using System.Collections.Generic;

namespace Hepsiburada_Casestudy.Database
{
    public  interface IDataProvider
    {
        void AddCampaign(CampaignModel campaign);
        CampaignModel GetCampaignbyName(string name);
        CampaignModel GetLastCampaign();
        CampaignInfoModel GetCampaignInfo(string name, int systemHour);
        void AddOrder(OrderModel order, string productCode);
        IEnumerable<OrderModel> GetOrdersbyProductCode(string productCode);
        void AddProduct(ProductModel product);
        ProductModel GetProductbyProductCode(string productCode);
    }
}
