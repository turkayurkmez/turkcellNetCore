using shop.Entities;

namespace eshop.Application
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetProducts(string name);

        Task<Product> GetProduct(int id);
        Task AddAsync(Product product);
        Task<bool> ProductIsExistAsync(int id);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);
    }
}
