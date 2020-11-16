using System.Threading.Tasks;
using UnitTestDemo.Contracts.Services;
using UnitTestDemo.Models;

namespace UnitTestDemo.Mocks.Services
{
    public class OrderDataServiceMock : IOrderDataService
    {
        public async Task<Order> PlaceOrderAsync(Order order)
        {
            await Task.Delay(500);
            return order;
        }
    }
}
