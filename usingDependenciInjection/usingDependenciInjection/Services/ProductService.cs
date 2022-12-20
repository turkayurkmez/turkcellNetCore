using usingDependenciInjection.Models;

namespace usingDependenciInjection.Services
{
    public class ProductService : IProductService
    {
        private List<Product> products;
        public ProductService()
        {
            products = new List<Product>()
            {
                 new(){ Id=1, Name="ABC", Description="Test", Price=5},
                 new(){ Id=2, Name="DEF", Description="Test", Price=5},
                 new(){ Id=4, Name="XYZ", Description="Test", Price=5},

            };
        }


        public List<Product> GetProducts()
        {
            return products;
        }
    }
}
