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
    public class CreateCampaignCommandResolver : ICommandResolver
    {
        private static CreateCampaignCommandResolver instance = new CreateCampaignCommandResolver();
       
        private CreateCampaignCommandResolver()
        {
           
        }
        public static CreateCampaignCommandResolver GetInstance()
        {
            return instance;
        }

        public void Execute(CommandModel commandModel)
        {
            CreateCampaignCommandModel model = (CreateCampaignCommandModel)commandModel;
            var columns= model.Command.Split(" ");
            model._dataProvider.AddCampaign(new CampaignModel()
            {
                Name = columns[1],
                ProductCode = columns[2],
                Duration = Convert.ToInt32(columns[3]),
                PMLimit = Convert.ToInt32(columns[4]),
                TargetSalesCount = Convert.ToInt32(columns[5])                
            });
            model._campaignService.PrintCreateCampaign(columns[1], columns[2], Convert.ToInt32(columns[3]), Convert.ToInt32(columns[4]), Convert.ToInt32(columns[5]));

        }

        ProviderType ICommandResolver.GetType()
        {
            return ProviderType.CREATE_CAMPAIGN;
        }
    }
}
