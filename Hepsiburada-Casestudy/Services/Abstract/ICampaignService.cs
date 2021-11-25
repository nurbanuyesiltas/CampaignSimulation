namespace Hepsiburada_Casestudy.Abstract
{
    public interface ICampaignService
    {
        void PrintCreateCampaign(string name, string productCode, int duration, int priceManipulationLimit, int targetSalesCount);
        void PrintCampaignInfo(string name, string status, int targetSales, int totalSales, int turnover, int averageItemPrice);
        void PrintIncreaseTime(int hour);
        void CalculatePrice(string CampaignName, int hour);
     }
}
