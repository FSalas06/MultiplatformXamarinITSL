using System.Threading.Tasks;
using UnitTestDemo.Contracts.Services;
using UnitTestDemo.Contracts.Services.General;
using UnitTestDemo.Models;

namespace UnitTestDemo.Mocks.Services
{
    public class AuthenticationServiceMock : IAuthenticationService
    {
        private readonly IPreferencesService _preferencesService;

        public AuthenticationServiceMock(IPreferencesService preferencesService)
        {
            _preferencesService = preferencesService;
        }

        public async Task<AuthenticationResponse> AuthenticateAsync(string userName, string password)
        {
            await Task.Delay(500);

            return new AuthenticationResponse
            {
                IsAuthenticated = true,
                User = new User 
                {
                    Id = "123453",
                    Email = "javier.sanchez@unosquare.com",
                    FirstName = "Javier",
                    LastName = "Sánchez",
                    UserName = "jsanchez"
                }
            };
        }

        public bool IsUserAuthenticated()
        {
            return !string.IsNullOrEmpty(_preferencesService.UserId);
        }

        public async Task<AuthenticationResponse> RegisterAsync(string firstName, string lastName, string email, string userName, string password)
        {
            await Task.Delay(500);

            return new AuthenticationResponse
            {
                IsAuthenticated = true,
                User = new User
                {
                    Id = "99999",
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName,
                    UserName = userName
                }
            };           
        }
    }
}
