using System.Threading.Tasks;
using UnitTestDemo.Models;

namespace UnitTestDemo.Contracts.Services
{
    public interface IOrderDataService
    {
        Task<Order> PlaceOrderAsync(Order order);
    }
}
