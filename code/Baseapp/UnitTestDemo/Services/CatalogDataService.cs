using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnitTestDemo.Contracts.Services;
using UnitTestDemo.Contracts.Services.General;
using UnitTestDemo.Models;
using UnitTestDemo.Utilities.Constants;

namespace UnitTestDemo.Services
{
    public class CatalogDataService : ICatalogDataService
    {
        private IApiService _apiService;

        public CatalogDataService(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IEnumerable<Pie>> GetAllPiesAsync()
        {
            UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
            {
                Path = ApiConstants.CatalogEndpoint
            };

            var pies = await _apiService.GetAsync<List<Pie>>(builder.ToString());

            return pies;
        }

        public async Task<IEnumerable<Pie>> GetPiesOfTheWeekAsync()
        {            
            UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
            {
                Path = ApiConstants.PiesOfTheWeekEndpoint
            };

            var pies = await _apiService.GetAsync<List<Pie>>(builder.ToString());          

            return pies;
        }
    }
}
