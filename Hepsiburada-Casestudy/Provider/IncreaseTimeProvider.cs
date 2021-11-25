using Hepsiburada_Casestudy.Abstract;
using Hepsiburada_Casestudy.Database;
using Hepsiburada_Casestudy.Models;
using Hepsiburada_Casestudy.System;

namespace Hepsiburada_Casestudy.Provider
{
    public class IncreaseTimeProvider : IProviderStrategy
    {
        private readonly ICampaignService _campaignService;
        private readonly IDataProvider _dataProvider;
        private readonly ITimeProvider _timeProvider;
        public IncreaseTimeProvider(ICampaignService campaignService,
           IDataProvider dataProvider,
           ITimeProvider timeProvider)
        {
            _campaignService = campaignService;
            _dataProvider = dataProvider;
            _timeProvider = timeProvider;
        }
        public CommandModel Execute(string row)
        {
           return new IncreaseTimeCommandModel(row, _timeProvider, _campaignService, _dataProvider);
        }
    }
}
