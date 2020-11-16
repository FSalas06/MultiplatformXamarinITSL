using System.Collections.Generic;
using System.Threading.Tasks;
using UnitTestDemo.Contracts.Services;
using UnitTestDemo.Models;

namespace UnitTestDemo.Mocks.Services
{
    public class ShoppingCartDataServiceMock : IShoppingCartDataService
    {
        private readonly List<ShoppingCartItem> _cartItemList;        

        public ShoppingCartDataServiceMock()
        {
            _cartItemList = new List<ShoppingCartItem>();    
        }

        public async Task<ShoppingCartItem> AddShoppingCartItemAsync(ShoppingCartItem shoppingCartItem, string userId)
        {
            await Task.Delay(500);
            _cartItemList.Add(shoppingCartItem);

            return shoppingCartItem;
        }

        public async Task<ShoppingCart> GetShoppingCartAsync(string userId)
        {
            await Task.Delay(500);

            return new ShoppingCart
            {
                ShoppingCartId = 1343234,
                UserId = userId,
                ShoppingCartItems = _cartItemList
            };
        }
    }
}
