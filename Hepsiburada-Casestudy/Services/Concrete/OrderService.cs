using Hepsiburada_Casestudy.Abstract;
using System;

namespace Hepsiburada_Casestudy.Concrete
{
    public class OrderService : IOrderService
    {
        public void PrintCreateOrder(string productCode, int quantity)
        {
            Console.WriteLine($"Order created; product {productCode}, quantity {quantity}");
        }   
    }
}
