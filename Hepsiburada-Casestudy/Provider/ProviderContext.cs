using Hepsiburada_Casestudy.Abstract;
using Hepsiburada_Casestudy.Database;
using Hepsiburada_Casestudy.Enum;
using Hepsiburada_Casestudy.Models;
using Hepsiburada_Casestudy.System;
using System.Collections.Generic;

namespace Hepsiburada_Casestudy.Provider
{
    public class ProviderContext
    {
        private readonly ICampaignService _campaignService;
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        private readonly IDataProvider _dataProvider;
        private readonly ITimeProvider _timeProvider;
        private static Dictionary<ProviderType, IProviderStrategy> _providers = new Dictionary<ProviderType, IProviderStrategy>();
        public ProviderContext(ICampaignService campaignService,
            IOrderService orderService,
            IProductService productService,
            IDataProvider dataProvider,
            ITimeProvider timeProvider)
        {
            _campaignService = campaignService;
            _orderService = orderService;
            _productService = productService;
            _dataProvider = dataProvider;
            _timeProvider = timeProvider;
            _providers.Add(ProviderType.CREATE_PRODUCT, new CreateProductProvider(_productService,_dataProvider));
            _providers.Add(ProviderType.CREATE_CAMPAIGN, new CreateCampaignProvider(_campaignService,_dataProvider));
            _providers.Add(ProviderType.CREATE_ORDER, new CreateOrderProvider(_orderService,_dataProvider));
            _providers.Add(ProviderType.GET_PRODUCT_INFO, new GetProductInfoProvider(_productService, _dataProvider));
            _providers.Add(ProviderType.GET_CAMPAIGN_INFO, new GetCampaignInfoProvider(_campaignService,_dataProvider,_timeProvider));
            _providers.Add(ProviderType.INCREASE_TIME, new IncreaseTimeProvider(_campaignService, _dataProvider, _timeProvider));
        }

        public CommandModel PrepareModel(ProviderType providerType, string row)
        {
            return _providers[providerType].Execute(row);
        }
    }

}

