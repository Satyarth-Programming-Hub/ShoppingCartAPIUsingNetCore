using ShoppingCartApi.Models;

namespace ShoppingCartApi.Services.CartItemService
{
    public interface ICartItemService
    {
        public IEnumerable<CartItem> GetCartItems();
        public CartItem GetCartItemById(int id);
        public CartItem AddCartItems(CartItem cartItem);
        public CartItem UpdateCartItem(CartItem cartItem);
        public CartItem DeleteCartItem(CartItem cartItem);
    }
}
