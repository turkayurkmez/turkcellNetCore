using shop.Entities;

namespace shop.DataAccess.Repositories
{
    public interface IProductRepository
    {
        Task CreateAsync(Product product);
        Task DeleteAsync(int id);
        IEnumerable<Product> GetAll();
        Task<Product> GetById(int id);
        Task<bool> ItemIsExistAsync(int id);
        IEnumerable<Product> SearchByName(string name);
        Task UpdateAsync(Product product);
    }
}
