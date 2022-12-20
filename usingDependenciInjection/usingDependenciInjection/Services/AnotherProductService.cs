using usingDependenciInjection.Models;

namespace usingDependenciInjection.Services
{
    public class AnotherProductService : IProductService
    {
        public List<Product> GetProducts()
        {
            return new List<Product>
           {
               new(){ Id=1, Name="XXX", Price=1, Description="Falan filan"}
           };
        }
    }
}
