using System;
using System.Threading.Tasks;
using UnitTestDemo.Contracts.Services;
using UnitTestDemo.Contracts.Services.General;
using UnitTestDemo.Models;
using UnitTestDemo.Utilities.Constants;

namespace UnitTestDemo.Services
{
    public class OrderDataService : IOrderDataService
    {
        private IApiService _apiService;

        public OrderDataService(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<Order> PlaceOrderAsync(Order order)
        {
            UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
            {
                Path = ApiConstants.PlaceOrderEndpoint
            };

            var result =
                await _apiService.PostAsync<Order>(builder.ToString(), order);

            return order;
        }
    }
}
