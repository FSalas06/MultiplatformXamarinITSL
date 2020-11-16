using System.Threading.Tasks;
using UnitTestDemo.Models;

namespace UnitTestDemo.Contracts.Services
{
    public interface IContactDataService
    {
        Task<ContactInfo> AddContactInfoAsync(ContactInfo contactInfo);
    }
}
