using System.Threading.Tasks;
using UnitTestDemo.Contracts.Services;
using UnitTestDemo.Models;

namespace UnitTestDemo.Mocks.Services
{
    public class ContactDataServiceMock : IContactDataService
    {
        public async Task<ContactInfo> AddContactInfoAsync(ContactInfo contactInfo)
        {
            await Task.Delay(500);
            return new ContactInfo
            {
                ContactInfoId = 143243,
                Email = "javier.sanchez@unosquare.com",
                Message = "Contact message"
            };
        }
    }
}
