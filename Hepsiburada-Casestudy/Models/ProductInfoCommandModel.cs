using Hepsiburada_Casestudy.Abstract;
using Hepsiburada_Casestudy.Database;

namespace Hepsiburada_Casestudy.Models
{
    public class ProductInfoCommandModel: CommandModel
    {
        public ProductInfoCommandModel(string Command,IProductService _productService,IDataProvider _dataProvider)
        {
            this.Command = Command;
            this._productService = _productService;
            this._dataProvider = _dataProvider;
        }

        public IProductService _productService { get; set; }
        public IDataProvider _dataProvider { get; set; }
       
    }
}
