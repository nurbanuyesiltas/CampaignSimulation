using Hepsiburada_Casestudy.Abstract;
using System;

namespace Hepsiburada_Casestudy.Concrete
{
    public class ProductService : IProductService
    {
        public void PrintCreateProduct(string productCode, int price, int stock)
        {
            Console.WriteLine($"Product created; code {productCode}, price {price}, stock {stock}");
        }
        public void PrintProductInfo(string productCode, int price, int stock)
        {
            Console.WriteLine($"Product {productCode} info; price {price}, stock {stock}");
        }
     
    }
}
