using Hepsiburada_Casestudy.Abstract;
using Hepsiburada_Casestudy.Database;
using Hepsiburada_Casestudy.Models;

namespace Hepsiburada_Casestudy.Provider
{
    public class CreateOrderProvider : IProviderStrategy
    {
        private readonly IOrderService _orderService;
        private readonly IDataProvider _dataProvider;
        public CreateOrderProvider(IOrderService orderService,
           IDataProvider dataProvider)
        {
            _orderService = orderService;
            _dataProvider = dataProvider;
        }
        public CommandModel Execute(string row)
        {
            return new CreateOrderCommandModel(row, _orderService, _dataProvider);
        }
    }
}
