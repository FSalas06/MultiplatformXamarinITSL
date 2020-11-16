using System.Collections.Generic;
using UnitTestDemo.Enumerations;
using UnitTestDemo.Utilities.Helpers;

namespace UnitTestDemo.Contracts.Services.General
{    
    public interface IConnectivityService
    {        
        event DeviceConnectivityChangedEventHandler OnDeviceConnectivityChanged;
        
        DeviceNetworkAccess NetworkStatus { get; }
        
        IEnumerable<DeviceConnectionProfile> CurrentConnectionProfiles();
       
        bool ActiveProfile(DeviceConnectionProfile profile);
    }
}
