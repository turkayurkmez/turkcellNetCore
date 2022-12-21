using Microsoft.EntityFrameworkCore;
using shop.DataAccess.Data;
using shop.Entities;

namespace shop.DataAccess.Repositories
{
    public class EFProductRepository : IProductRepository
    {
        private readonly shopDbContext _dbContext;

        public EFProductRepository(shopDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task CreateAsync(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await GetById(id);
            //Remove ve Update gibi dbContext eylemleri; DbState'i takip eder (Tracking). Birim zamanda yalnızca bir eylem tracking flagini kullanabilir.
            //Fakat burada GetById içindeki FindAsync eylemi de tracking flag'ini kullanır. Ardından Remove da tracking yapmaya çalışırsa hata alabilirsiniz.
            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
        }

        public IEnumerable<Product> GetAll()
        {
            return _dbContext.Products.ToList();
        }

        public async Task<Product> GetById(int id)
        {
            return await _dbContext.Products.FindAsync(id);
        }

        public async Task<bool> ItemIsExistAsync(int id)
        {
            return await _dbContext.Products.AnyAsync(p => p.Id == id);

        }

        public IEnumerable<Product> SearchByName(string name)
        {
            return _dbContext.Products.Where(p => p.Name.ToLower().Contains(name.ToLower()))
                                      .ToList();
        }

        public async Task UpdateAsync(Product product)
        {
            _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync();
        }
    }
}
