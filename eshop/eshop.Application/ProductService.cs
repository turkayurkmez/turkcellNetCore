using shop.DataAccess.Repositories;
using shop.Entities;

namespace eshop.Application
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task AddAsync(Product product)
        {
            await _repository.CreateAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _repository.GetById(id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _repository.GetAll();
        }

        public IEnumerable<Product> GetProducts(string name)
        {
            return _repository.SearchByName(name);
        }

        public async Task<bool> ProductIsExistAsync(int id)
        {
            bool isExist = await _repository.ItemIsExistAsync(id);
            return isExist;
        }

        public async Task UpdateProductAsync(Product product)
        {
            await _repository.UpdateAsync(product);
        }
    }
}
