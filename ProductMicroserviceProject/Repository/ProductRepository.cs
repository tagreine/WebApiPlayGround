using ProductMicroserviceProject.Models;

namespace ProductMicroserviceProject.Repository;

public class ProductRepository: IProductRepository
{
    private readonly ProductDbContext _dbContext;

    public ProductRepository(ProductDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public IEnumerable<Product> GetAllProducts()
    {
        throw new NotImplementedException();
    }

    public Product? GetProductById(int productId)
    {
        var product = _dbContext.Products.SingleOrDefault(p => p.Id == productId);
        return product;
    }

    public void AddProduct(Product product)
    {
        throw new NotImplementedException();
    }

    public void DeleteProduct(int productId)
    {
        var product =_dbContext.Products.SingleOrDefault(p => p.Id == productId);
        if (product == null) return;
        _dbContext.Products.Remove(product);
        Save();
    }

    public void UpdateProduct(Product product)
    {
        if (_dbContext.Products.Find(product) == null) return;
        _dbContext.Products.Update(product);
        Save();
    }

    public void Save()
    {
        _dbContext.SaveChanges();
    }
}