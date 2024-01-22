using ShoppingCartApi.Models;

namespace ShoppingCartApi.Services.ProductService
{
    public interface IProductService
    {
        public IEnumerable<Product> GetProducts();
        public Product GetProductById(int id);
        public Product AddProduct(Product product);
        public Product UpdateProduct(Product product);
        public Product DeleteProduct(Product product);
    }
}
