using System.Threading.Tasks;
using UnitTestDemo.Models;

namespace UnitTestDemo.Contracts.Services
{    public interface IShoppingCartDataService
    {
        Task<ShoppingCart> GetShoppingCartAsync(string userId);
        Task<ShoppingCartItem> AddShoppingCartItemAsync(ShoppingCartItem shoppingCartItem, string userId);
    }
}
