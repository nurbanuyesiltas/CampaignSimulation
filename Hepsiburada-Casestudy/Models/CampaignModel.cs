namespace Hepsiburada_Casestudy.Models
{
    public class CampaignModel
    {
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public int Duration { get; set; }
        public int PMLimit { get; set; }
        public int TargetSalesCount { get; set; }
        public string GetStatus(int systemHour)
        {
            return systemHour > Duration ? "Ended" : "Active";
        }
       
    }
    public class CampaignInfoModel
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public int TargetSales { get; set; }
        public int TotalSales { get; set; }
        public int Turnover { get; set; }
        public int AverageItemPrice { get; set; }
    }
}
