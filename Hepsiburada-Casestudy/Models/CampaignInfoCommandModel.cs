using Hepsiburada_Casestudy.Abstract;
using Hepsiburada_Casestudy.Database;
using Hepsiburada_Casestudy.System;

namespace Hepsiburada_Casestudy.Models
{
    public class CampaignInfoCommandModel: CommandModel
    {
        public CampaignInfoCommandModel(string Command,ICampaignService _campaignService,ITimeProvider _timeProvider,IDataProvider _dataProvider)
        {
            this.Command = Command;
            this._campaignService = _campaignService;
            this._timeProvider = _timeProvider;
            this._dataProvider = _dataProvider;
        }

        public ICampaignService _campaignService { get; set; }
        public ITimeProvider _timeProvider { get; set; }
        public IDataProvider _dataProvider { get; set; }
       
    }
}
