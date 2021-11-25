using Hepsiburada_Casestudy.Abstract;
using Hepsiburada_Casestudy.Database;
using Hepsiburada_Casestudy.Models;

namespace Hepsiburada_Casestudy.Provider
{
    public class CreateCampaignProvider : IProviderStrategy
    {
        private readonly ICampaignService _campaignService;
        private readonly IDataProvider _dataProvider;
        public CreateCampaignProvider(ICampaignService campaignService,
           IDataProvider dataProvider)
        {
            _campaignService = campaignService;
            _dataProvider = dataProvider;
        }
        public CommandModel Execute(string row)
        {
            return new CreateCampaignCommandModel(row, _campaignService, _dataProvider); 
        }
    }
}
