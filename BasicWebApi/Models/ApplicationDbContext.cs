using Microsoft.EntityFrameworkCore;

namespace BasicWebApi.Models;

public class ApplicationDbContext: DbContext
{
    public DbSet<Product> Products => Set<Product>();
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}
}