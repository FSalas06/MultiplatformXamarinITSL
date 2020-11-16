using UnitTestDemo.Enumerations;

namespace UnitTestDemo.Contracts.Services.General
{    
    public interface IPhoneDialerService
    {       
        PlacePhoneCallStatus PlacePhoneCall(string phoneNumber);
    }
}
