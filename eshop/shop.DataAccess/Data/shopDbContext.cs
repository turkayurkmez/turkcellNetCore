using Microsoft.EntityFrameworkCore;
using shop.Entities;

namespace shop.DataAccess.Data
{
    public class shopDbContext : DbContext
    {
        //POCO: Plain Old C# Object
        //POJO: Plain Old Java Object (Hibernate)

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public shopDbContext(DbContextOptions<shopDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired()
                                                                .HasMaxLength(100);

            modelBuilder.Entity<Product>().HasOne(p => p.Category)
                                          .WithMany(c => c.Products)
                                          .HasForeignKey(p => p.CategoryId)
                                          .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, CreatedDate = DateTime.Now, Description = "Açıklama 1", Name = "Dumble", Price = 100 },
                new Product { Id = 2, CreatedDate = DateTime.Now, Description = "Açıklama 2", Name = "Barfix bar", Price = 250 },
                new Product { Id = 3, CreatedDate = DateTime.Now, Description = "Açıklama 3", Name = "Jimnastik Topu", Price = 300 }
            );

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Fiziksel DB nerede olacak? ConnectionString bilgisini burada verebilirsiniz.
            //optionsBuilder.UseSqlServer("Data Source=(localdb)\\Mssqllocaldb;Initial Catalog=turkcellShopDb;Integrated Security=True");

            base.OnConfiguring(optionsBuilder);

        }


    }

}
