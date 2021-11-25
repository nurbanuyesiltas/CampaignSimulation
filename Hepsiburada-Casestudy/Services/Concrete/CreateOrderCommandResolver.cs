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
    public class CreateOrderCommandResolver : ICommandResolver
    {
        private static CreateOrderCommandResolver instance = new CreateOrderCommandResolver();
       
        private CreateOrderCommandResolver()
        {
           
        }
        public static CreateOrderCommandResolver GetInstance()
        {
            return instance;
        }

        public void Execute(CommandModel commandModel)
        {
            CreateOrderCommandModel model = (CreateOrderCommandModel)commandModel;
            var columns= model.Command.Split(" ");
            model._dataProvider.AddOrder(new OrderModel()
            {
                ProductCode = columns[1],
                Quantity = Convert.ToInt32(columns[2])
            }, columns[1]);
            model._orderService.PrintCreateOrder(columns[1], Convert.ToInt32(columns[2]));
        }
        ProviderType ICommandResolver.GetType()
        {
            return ProviderType.CREATE_ORDER;
        }
    }
}
