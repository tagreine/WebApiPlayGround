using ProductMicroserviceProject.Models;

namespace ProductMicroserviceProject.Repository;

public interface IProductRepository
{
    IEnumerable<Product> GetAllProducts();
    Product? GetProductById(int productId);
    void AddProduct(Product product);
    void DeleteProduct(int productId);
    void UpdateProduct(Product product);
    void Save();
}