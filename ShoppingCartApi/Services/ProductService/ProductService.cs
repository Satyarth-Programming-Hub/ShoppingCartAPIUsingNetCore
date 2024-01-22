using ShoppingCartApi.DatabaseContext;
using ShoppingCartApi.Models;

namespace ShoppingCartApi.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly ApiDbContext _dbContext;
        public ProductService(ApiDbContext dbContext)
        {
                _dbContext = dbContext;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _dbContext.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            return _dbContext.Products.FirstOrDefault(p => p.ProductId == id);
        }

        public Product AddProduct(Product product)
        {
            var addedProduct = _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return addedProduct.Entity;
        }

        public Product UpdateProduct(Product product)
        {
            var updatedProduct = _dbContext.Products.Update(product);
            _dbContext.SaveChanges();
            return updatedProduct.Entity;
        }

        public Product DeleteProduct(Product product)
        {
            var deletedProduct = _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
            return deletedProduct.Entity;
        }

    }
}
