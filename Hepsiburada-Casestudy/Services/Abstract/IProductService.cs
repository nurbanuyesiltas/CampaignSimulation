namespace Hepsiburada_Casestudy.Abstract
{
    public interface IProductService
    {
        void PrintCreateProduct(string productCode, int price, int stock);
        void PrintProductInfo(string productCode, int price, int stock);
    }
}
