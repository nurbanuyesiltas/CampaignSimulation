using Hepsiburada_Casestudy.Abstract;
using Hepsiburada_Casestudy.Database;
using Hepsiburada_Casestudy.Models;

namespace Hepsiburada_Casestudy.Provider
{
    public class CreateProductProvider : IProviderStrategy
    {
        private readonly IProductService _productService;
        private readonly IDataProvider _dataProvider;
        public CreateProductProvider(IProductService productService,
           IDataProvider dataProvider)
        {
            _productService = productService;
            _dataProvider = dataProvider;
        }
        public CommandModel Execute(string row)
        {
            return new CreateProductCommandModel(row, _productService, _dataProvider);
        }
    }
}
