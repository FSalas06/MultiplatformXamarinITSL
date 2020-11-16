using System;
using System.Diagnostics;
using UnitTestDemo.Contracts.Services.General;
using UnitTestDemo.Enumerations;
using Xamarin.Essentials;

namespace UnitTestDemo.Services.General
{    
    public class PhoneDialerService : IPhoneDialerService
    {               
        public PlacePhoneCallStatus PlacePhoneCall(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                return PlacePhoneCallStatus.InvalidNumber;
            }

            var result = PlacePhoneCallStatus.Unknown;

            try
            {
                PhoneDialer.Open(phoneNumber);
                result = PlacePhoneCallStatus.Placed;

            }
            catch (FeatureNotSupportedException ex)
            {
                Debug.Write(ex);
                result = PlacePhoneCallStatus.NotSupported;                
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                result = PlacePhoneCallStatus.Error;                
            }

            return result;
        }
    }
}
