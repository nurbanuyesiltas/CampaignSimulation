using Hepsiburada_Casestudy.Database;
using Hepsiburada_Casestudy.Enum;
using Hepsiburada_Casestudy.Models;
using Hepsiburada_Casestudy.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsiburada_Casestudy.Services.Concrete
{
    public class CampaignInfoCommandResolver : ICommandResolver
    {
        private static CampaignInfoCommandResolver instance = new CampaignInfoCommandResolver();

        private CampaignInfoCommandResolver()
        {

        }
        public static CampaignInfoCommandResolver GetInstance()
        {
            return instance;
        }

        public void Execute(CommandModel commandModel)
        {
            CampaignInfoCommandModel model = (CampaignInfoCommandModel)commandModel;
            var columns = model.Command.Split(" ");
            var campaingInfo = model._dataProvider.GetCampaignInfo(columns[1], model._timeProvider.GetTimeModel().CurrentHour);
            model._campaignService.PrintCampaignInfo(campaingInfo.Name, campaingInfo.Status, campaingInfo.TargetSales, campaingInfo.TotalSales, campaingInfo.Turnover, campaingInfo.AverageItemPrice);

        }
        ProviderType ICommandResolver.GetType()
        {
            return ProviderType.GET_CAMPAIGN_INFO;
        }
    }
}
