using Microsoft.AspNetCore.Mvc;
using ShoppingCartApi.Models;
using ShoppingCartApi.Services.ProductService;


namespace ShoppingCartApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Get All Products
        /// </summary>
        /// <returns>List of Products</returns>
        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _productService.GetProducts();

            if (products == null)
                return NotFound();

            return Ok(products);

        }

        /// <summary>
        /// Get a product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Product</returns>
        [HttpGet("{id:int}")]
        public IActionResult GetProductById(int id)
        {
            var product = _productService.GetProductById(id);

            if (product == null)
                return NotFound();

            return Ok(product);

        }

        /// <summary>
        /// Add a new product
        /// </summary>
        /// <param name="product"></param>
        /// <returns>Product</returns>
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {

            if (product == null)
                return BadRequest();

            _productService.AddProduct(product);

            return Ok(product);
        }

        /// <summary>
        /// Update an existing product
        /// </summary>
        /// <param name="product"></param>
        /// <returns>Product</returns>
        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {

            if (product == null)
                return BadRequest();

            _productService.UpdateProduct(product);

            return Ok(product);
        }

        /// <summary>
        /// Delete an existing product
        /// </summary>
        /// <param name="product"></param>
        /// <returns>Product</returns>
        [HttpDelete]
        public IActionResult DeleteProduct(Product product)
        {

            if (product == null)
                return BadRequest();

            _productService.DeleteProduct(product);

            return Ok(product);
        }
    }
}
