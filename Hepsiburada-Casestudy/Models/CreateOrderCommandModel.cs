using Hepsiburada_Casestudy.Abstract;
using Hepsiburada_Casestudy.Database;

namespace Hepsiburada_Casestudy.Models
{
    public class CreateOrderCommandModel: CommandModel
    {
        public CreateOrderCommandModel(string Command,IOrderService _orderService, IDataProvider _dataProvider)
        {
            this.Command = Command;
            this._orderService = _orderService;
            this._dataProvider = _dataProvider;
        }
        public IOrderService _orderService { get; set; }
        public IDataProvider _dataProvider { get; set; }
       
    }
}
