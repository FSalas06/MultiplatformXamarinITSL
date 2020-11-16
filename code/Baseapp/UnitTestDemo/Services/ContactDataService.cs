using System;
using System.Threading.Tasks;
using UnitTestDemo.Contracts.Services;
using UnitTestDemo.Contracts.Services.General;
using UnitTestDemo.Models;
using UnitTestDemo.Utilities.Constants;

namespace UnitTestDemo.Services
{
    public class ContactDataService : IContactDataService
    {
        private IApiService _apiService;

        public ContactDataService(IApiService apiService)
        {
            _apiService = apiService;
        }         

        public async Task<ContactInfo> AddContactInfoAsync(ContactInfo contactInfo)
        {
            UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
            {
                Path = ApiConstants.AddContactInfoEndpoint
            };

            var result = await _apiService.PostAsync(builder.ToString(), contactInfo);

            return result;
        }
    }
}
