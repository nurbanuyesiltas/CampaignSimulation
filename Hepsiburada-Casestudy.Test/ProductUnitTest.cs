using Hepsiburada_Casestudy.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hepsiburada_Casestudy.Test
{
    [TestClass]
    public class ProductUnitTest
    {
        [TestMethod]
        public void DoTestPrintCreateProduct()
        {
            ProductService businessService = new ProductService();
            businessService.PrintCreateProduct("P1", 100, 1000);
        }
        [TestMethod]
        public void DoTestProductInfo()
        {
            ProductService businessService = new ProductService();
            businessService.PrintProductInfo("P1", 100, 1000);
        }
    }
}
