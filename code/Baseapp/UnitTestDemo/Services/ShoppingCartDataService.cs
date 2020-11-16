using System;
using System.Threading.Tasks;
using UnitTestDemo.Contracts.Services;
using UnitTestDemo.Contracts.Services.General;
using UnitTestDemo.Models;
using UnitTestDemo.Utilities.Constants;

namespace UnitTestDemo.Services
{
    public class ShoppingCartDataService : IShoppingCartDataService
    {
        private IApiService _apiService;

        public ShoppingCartDataService(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<ShoppingCartItem> AddShoppingCartItemAsync(ShoppingCartItem shoppingCartItem, string userId)
        {
            UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
            {
                Path = ApiConstants.AddShoppingCartItemEndpoint
            };

            var userShoppingCartItem = new UserShoppingCartItem
            {
                ShoppingCartItem = shoppingCartItem,
                UserId = userId
            };

            var result = await _apiService.PostAsync(builder.ToString(), userShoppingCartItem);

            return shoppingCartItem;
        }

        public async Task<ShoppingCart> GetShoppingCartAsync(string userId)
        {
            UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
            {
                Path = $"{ApiConstants.ShoppingCartEndpoint}/{userId}"
            };

            var shoppingCart = await _apiService.GetAsync<ShoppingCart>(builder.ToString());

            return shoppingCart;
        }
    }
}
