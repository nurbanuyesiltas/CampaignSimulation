using Hepsiburada_Casestudy.Abstract;
using Hepsiburada_Casestudy.Provider;
using Hepsiburada_Casestudy.Database;
using Hepsiburada_Casestudy.Models;
using Hepsiburada_Casestudy.Services.Abstract;
using Hepsiburada_Casestudy.Services.Concrete;
using Hepsiburada_Casestudy.System;
using Hepsiburada_Casestudy.Validator;
using System.IO;

namespace Hepsiburada_Casestudy.Managers
{
    public class CampaignSimulationManager : ICampaignSimulationManager
    {
        private readonly ICampaignService _campaignService;
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        private readonly IDataProvider _dataProvider;
        private readonly ITimeProvider _timeProvider;
        private readonly ICommandValidator _commandValidator;
        public CampaignSimulationManager(ICampaignService campaignService, 
            IOrderService orderService, 
            IProductService productService,
            IDataProvider dataProvider,
            ITimeProvider timeProvider, 
            ICommandValidator commandValidator)
        {
            _campaignService = campaignService;
            _orderService = orderService;
            _productService = productService;
            _dataProvider = dataProvider;
            _timeProvider = timeProvider;
            _commandValidator = commandValidator;
        }
        public void CampaignSimulation(string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);            
            using (var sr = new StreamReader(fs))
            {
                ProviderContext strategyContext = new ProviderContext(_campaignService, _orderService, _productService, _dataProvider, _timeProvider);
                string row;
                while ((row = sr.ReadLine()) != null) 
                {
                    _commandValidator.CheckCommand(row);
                    var columns = row.Split(" ");                  
                    ICommandResolver resolver =CommandResolverFactory.GetCommandResolver(columns[0]);
                     CommandModel model = strategyContext.PrepareModel(resolver.GetType(),row);
                    resolver.Execute(model);
                }
            }
            fs.Close();
        }

    }
}
