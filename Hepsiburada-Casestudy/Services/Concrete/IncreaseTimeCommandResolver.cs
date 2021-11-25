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
    public class IncreaseTimeCommandResolver : ICommandResolver
    {
        private static IncreaseTimeCommandResolver instance = new IncreaseTimeCommandResolver();

        private IncreaseTimeCommandResolver()
        {

        }
        public static IncreaseTimeCommandResolver GetInstance()
        {
            return instance;
        }

        public void Execute(CommandModel commandModel)
        {
            IncreaseTimeCommandModel model = (IncreaseTimeCommandModel)commandModel;
            var columns = model.Command.Split(" ");
            int time = Convert.ToInt32(columns[1]);
            model._timeProvider.IncreaseTime(time);
            CampaignModel lastCampaign = model._dataProvider.GetLastCampaign();
            if (lastCampaign != null)
                model._campaignService.CalculatePrice(lastCampaign.Name, Convert.ToInt32(columns[1]));
            model._campaignService.PrintIncreaseTime(model._timeProvider.GetTimeModel().CurrentHour);
        }
        ProviderType ICommandResolver.GetType()
        {
            return ProviderType.INCREASE_TIME;
        }
    }
}
