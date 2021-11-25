using Hepsiburada_Casestudy.Abstract;
using Hepsiburada_Casestudy.Database;
using Hepsiburada_Casestudy.System;

namespace Hepsiburada_Casestudy.Models
{
    public class IncreaseTimeCommandModel : CommandModel
    {
        public IncreaseTimeCommandModel(string Command,ITimeProvider _timeProvider, ICampaignService _campaignService, IDataProvider _dataProvider)
        {
            this.Command = Command;
            this._timeProvider = _timeProvider;
            this._campaignService = _campaignService;
            this._dataProvider = _dataProvider;
        }

        public ITimeProvider _timeProvider { get; set; }
        public ICampaignService _campaignService { get; set; }
        public IDataProvider _dataProvider { get; set; }
       
    }
}
