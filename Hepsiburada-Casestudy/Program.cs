using Hepsiburada_Casestudy.Abstract;
using Hepsiburada_Casestudy.Concrete;
using Hepsiburada_Casestudy.Database;
using Hepsiburada_Casestudy.Managers;
using Hepsiburada_Casestudy.System;
using Hepsiburada_Casestudy.Validator;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Hepsiburada_Casestudy
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Dependency Injection
            //Dependency Injection configuration
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddSingleton<ICampaignSimulationManager, CampaignSimulationManager>()
                .AddSingleton<ICampaignService, CampaignService>()
                .AddSingleton<IOrderService, OrderService>()
                .AddSingleton<IProductService, ProductService>()
                .AddSingleton<IDataProvider, DataProvider>()
                .AddSingleton<ITimeProvider, TimeProvider>()
                .AddSingleton<ICommandValidator, CommandValidator>()
                .BuildServiceProvider();
            var _manager = serviceProvider.GetService<ICampaignSimulationManager>();
            #endregion

            // User enters scenario file path
            Console.WriteLine("Please enter the file path: ");           
            string filePath = Console.ReadLine();
            _manager.CampaignSimulation(filePath);

        }
    }

}
