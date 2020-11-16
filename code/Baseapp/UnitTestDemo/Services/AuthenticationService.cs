using System;
using System.Threading.Tasks;
using UnitTestDemo.Contracts.Services;
using UnitTestDemo.Contracts.Services.General;
using UnitTestDemo.Models;
using UnitTestDemo.Utilities.Constants;

namespace UnitTestDemo.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IApiService _apiService;

        private readonly IPreferencesService _preferencesService;

        public AuthenticationService(IApiService apiService, IPreferencesService preferencesService)
        {
            _apiService = apiService;
            _preferencesService = preferencesService;
        }

        public async Task<AuthenticationResponse> AuthenticateAsync(string userName, string password)
        {
            UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
            {
                Path = ApiConstants.AuthenticateEndpoint
            };

            AuthenticationRequest authenticationRequest = new AuthenticationRequest()
            {
                UserName = userName,
                Password = password
            };

            return await _apiService.PostAsync<AuthenticationRequest, AuthenticationResponse>(builder.ToString(), authenticationRequest);
        }

        public bool IsUserAuthenticated()
        {
            return !string.IsNullOrEmpty(_preferencesService.UserId);
        }        
    }
}
