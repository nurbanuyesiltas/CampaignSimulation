using Hepsiburada_Casestudy.Enum;
using Hepsiburada_Casestudy.Models;
using Hepsiburada_Casestudy.Services.Abstract;

namespace Hepsiburada_Casestudy.Services.Concrete
{
    public class ProductInfoCommandResolver : ICommandResolver
    {
        private static ProductInfoCommandResolver instance = new ProductInfoCommandResolver();

        private ProductInfoCommandResolver()
        {

        }
        public static ProductInfoCommandResolver GetInstance()
        {
            return instance;
        }

        public void Execute(CommandModel commandModel)
        {
            ProductInfoCommandModel model = (ProductInfoCommandModel)commandModel;
            var columns = model.Command.Split(" ");
            var product = model._dataProvider.GetProductbyProductCode(columns[1]);
            model._productService.PrintProductInfo(product.ProductCode, product.Price, product.Stock);
        }
        ProviderType ICommandResolver.GetType()
        {
            return ProviderType.GET_PRODUCT_INFO;
        }
    }
}
