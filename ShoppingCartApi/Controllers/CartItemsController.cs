using Microsoft.AspNetCore.Mvc;
using ShoppingCartApi.Models;
using ShoppingCartApi.Services.CartItemService;


namespace ShoppingCartApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemsController : ControllerBase
    {
        private readonly ICartItemService _cartItemService;

        public CartItemsController(ICartItemService cartItemService)
        {
            _cartItemService = cartItemService;
        }

        /// <summary>
        /// Get all cart items
        /// </summary>
        /// <returns>List of cart items</returns>
        [HttpGet]
        public ActionResult<IEnumerable<CartItem>> GetCartItems()
        {
            var cartItems = _cartItemService.GetCartItems();

            if (cartItems == null)
                return NotFound();

            return Ok(cartItems);

        }

        /// <summary>
        /// Get a single cart items by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>CartItem</returns>
        [HttpGet("{id:int}")]
        public IActionResult GetCartItemsById(int id)
        {
            var cartItem = _cartItemService.GetCartItemById(id);

            if (cartItem == null)
                return NotFound();

            return Ok(cartItem);

        }

        /// <summary>
        /// Add new item/increate quntity of the cart
        /// </summary>
        /// <param name="cartItem"></param>
        /// <returns>CartItem</returns>
        [HttpPost]
        public ActionResult<CartItem> AddCartItems(CartItem cartItem)
        {

            if (cartItem == null)
                return BadRequest();

            var crtItem = _cartItemService.AddCartItems(cartItem);

            return Ok(crtItem);
        }

        /// <summary>
        /// Update an existing cart item
        /// </summary>
        /// <param name="cartItem"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult UpdateCartItems(CartItem cartItem)
        {

            if (cartItem == null)
                return BadRequest();

            var crtItem = _cartItemService.UpdateCartItem(cartItem);

            return Ok(crtItem);
        }

        /// <summary>
        /// Delete cart items - It will decrease the quantity upto 0
        /// </summary>
        /// <param name="cartItem"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult DeleteCartItems(CartItem cartItem)
        {

            if (cartItem == null)
                return BadRequest();

            var crtItem = _cartItemService.DeleteCartItem(cartItem);

            return Ok(crtItem);
        }
    }
}
