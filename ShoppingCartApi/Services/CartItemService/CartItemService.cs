using Microsoft.EntityFrameworkCore;
using ShoppingCartApi.DatabaseContext;
using ShoppingCartApi.Models;

namespace ShoppingCartApi.Services.CartItemService
{
    public class CartItemService : ICartItemService
    {
        private readonly ApiDbContext _dbContext;

        public CartItemService(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<CartItem> GetCartItems()
        {
            return _dbContext.CartItems.ToList();
        }

        public CartItem GetCartItemById(int id)
        {
            return _dbContext.CartItems.FirstOrDefault(c => c.CartItemId == id);
        }

        public CartItem AddCartItems(CartItem cartItem)
        {
            if (cartItem is null) return null;

            //Cart Item Quantity is optional and will be defaulted to 1 if not supplied
            if (cartItem.Quantity == null || cartItem.Quantity <= 0)
            {
                cartItem.Quantity = 1;
            }


            var existingCartItem = GetCartItemByProductAndUserId(cartItem.ProductId, cartItem.UserId);

            if (existingCartItem is null)
            {
                //Inserting new cart item
                _dbContext.CartItems.Add(cartItem);
                _dbContext.SaveChanges();
                return cartItem;
            }
            else 
            {
                //Updating existing cart item
                existingCartItem.Quantity += cartItem.Quantity;
                _dbContext.Entry(existingCartItem).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return existingCartItem;
            }
        }

        public CartItem UpdateCartItem(CartItem cartItem)
        {
            var crtItem = _dbContext.CartItems.Update(cartItem);
            _dbContext.SaveChanges();
            return crtItem.Entity;
        }

        public CartItem DeleteCartItem(CartItem cartItem)
        {
            if (cartItem is null) return null;

            var existingCartItem = GetCartItemByProductAndUserId(cartItem.ProductId, cartItem.UserId);

            if (existingCartItem.Quantity >= 1)
            {
                existingCartItem.Quantity -= cartItem.Quantity;
                _dbContext.Entry(existingCartItem).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return existingCartItem;
            }
            return null;
        }

        private CartItem GetCartItemByProductAndUserId(int productId, int userId) 
        {
            return _dbContext.CartItems.FirstOrDefault(ci => ci.ProductId == productId && ci.UserId == userId);        
        }
    }
}
