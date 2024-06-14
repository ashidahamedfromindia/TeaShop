using Microsoft.EntityFrameworkCore;
using TeaShop.Domain.Entities;

namespace TeaShop.Infrastructure.ApplicationDbContext
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<ProductCategory> CategoryTable { get; set; }
        public DbSet<AllProducts> ProductsTable { get; set; }
        public DbSet<CustomerOrder> OrderTable { get; set; }
    }
}
