using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using ShoppingCartApi.Controllers;
using ShoppingCartApi.Models;
using ShoppingCartApi.Services.CartItemService;

namespace ShoppingCartApiTest
{
    public class CartItemsControllerTest
    {

        [Fact]            
        public void GetCartItems_Returns_The_Correct_Number_Of_CartItems() 
        {

            //Arrange
            int count = 5;
            var fakeCartItems = A.CollectionOfDummy<CartItem>(count).AsEnumerable();
            var _cartItemService = A.Fake<ICartItemService>();
            A.CallTo(() => _cartItemService.GetCartItems()).Returns(fakeCartItems);
            var controller = new CartItemsController(_cartItemService);

            //Act
            var actionResult = controller.GetCartItems();

            //Assert
            var result = actionResult.Result as OkObjectResult;
            var returnCartItems = result.Value as IEnumerable<CartItem>;
            Assert.Equal(count, returnCartItems.Count());

        }
        
    }
}
