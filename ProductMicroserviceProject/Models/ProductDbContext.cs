using Microsoft.EntityFrameworkCore;

namespace ProductMicroserviceProject.Models;

public class ProductDbContext: DbContext
{
    public DbSet<Product> Products => Set<Product>();

    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
    {
    }
}