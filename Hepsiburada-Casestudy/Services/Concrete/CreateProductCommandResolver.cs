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
    public class CreateProductCommandResolver: ICommandResolver
    {
        private static CreateProductCommandResolver instance = new CreateProductCommandResolver();
       
        private CreateProductCommandResolver()
        {
           
        }
        public static CreateProductCommandResolver GetInstance()
        {
            return instance;
        }

        public void Execute(CommandModel commandModel)
        {
            CreateProductCommandModel createProductCommandModel = (CreateProductCommandModel)commandModel;
            var columns=createProductCommandModel.Command.Split(" ");
            createProductCommandModel._dataProvider.AddProduct(new ProductModel()
            {
                ProductCode = columns[1],
                Price = Convert.ToInt32(columns[2]),
                Stock = Convert.ToInt32(columns[3])
            });
            createProductCommandModel._productService.PrintCreateProduct(columns[1], Convert.ToInt32(columns[2]), Convert.ToInt32(columns[3]));
        }
        ProviderType ICommandResolver.GetType()
        {
            return ProviderType.CREATE_PRODUCT;
        }
    }
}
