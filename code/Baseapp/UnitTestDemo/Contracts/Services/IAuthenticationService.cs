using System.Threading.Tasks;
using UnitTestDemo.Models;

namespace UnitTestDemo.Contracts.Services
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> AuthenticateAsync(string userName, string password);

        bool IsUserAuthenticated();
    }
}
