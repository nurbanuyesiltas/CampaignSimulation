using Hepsiburada_Casestudy.Services.Abstract;
using System;

namespace Hepsiburada_Casestudy.Services.Concrete
{
    public class CommandResolverFactory
    {
        public static ICommandResolver GetCommandResolver(string commandType)
        {
            switch (commandType)
            {
                case "create_product":
                    return CreateProductCommandResolver.GetInstance();
                case "create_campaign":
                    return CreateCampaignCommandResolver.GetInstance();
                case "create_order":
                    return CreateOrderCommandResolver.GetInstance();
                case "get_product_info":
                    return ProductInfoCommandResolver.GetInstance();
                case "get_campaign_info":
                    return CampaignInfoCommandResolver.GetInstance();
                case "increase_time":
                    return IncreaseTimeCommandResolver.GetInstance();
                default:
                    Console.WriteLine("Invalid method!");
                    return null;
            }
        }
    }
}
