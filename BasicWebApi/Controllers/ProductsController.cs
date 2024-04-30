using BasicWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BasicWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        
        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        [HttpPost("add")]
        public IActionResult AddProduct(Product product)
        {
            try
            {
                _context.Products.Add(product);
                _context.SaveChanges(true);
                return StatusCode(StatusCodes.Status201Created, product);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("get")]
        public Product? GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        [HttpPut("update")]
        public IActionResult UpdateProduct(int id, Product product)
        {
            try
            {
                if (id != product.Id)
                    return StatusCode(StatusCodes.Status400BadRequest);
                _context.Products.Update(product);
                _context.SaveChanges(true);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("delete")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                var product = _context.Products.FirstOrDefault(p => p.Id == id);
                if (product == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }

                _context.Products.Remove(product);
                _context.SaveChanges(true);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
