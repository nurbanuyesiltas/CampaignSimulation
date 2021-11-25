using Hepsiburada_Casestudy.Concrete;
using Hepsiburada_Casestudy.Services.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Hepsiburada_Casestudy.Test
{
    [TestClass]
    public class OrderUnitTest
    {
        [TestMethod]
        public void DoTestPrintCreateOrder()
        {
            OrderService businessService = new OrderService();
            businessService.PrintCreateOrder("P1", 10);
        }
    }
}

