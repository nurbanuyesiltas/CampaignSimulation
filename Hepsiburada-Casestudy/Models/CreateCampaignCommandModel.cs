using Hepsiburada_Casestudy.Abstract;
using Hepsiburada_Casestudy.Database;

namespace Hepsiburada_Casestudy.Models
{
    public class CreateCampaignCommandModel: CommandModel
    {
        public CreateCampaignCommandModel(string Command,ICampaignService _campaignService, IDataProvider _dataProvider)
        {
            this.Command = Command;
            this._campaignService = _campaignService;
            this._dataProvider = _dataProvider;
        }
        public ICampaignService _campaignService { get; set; }
        public IDataProvider _dataProvider { get; set; }
       
    }
}
