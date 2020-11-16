using System;
using System.Collections.Generic;
using UnitTestDemo.Enumerations;

namespace UnitTestDemo.Utilities.Helpers
{    
    public class DeviceConnectivityChangedEventArgs : EventArgs
    {        
        public DeviceNetworkAccess NetworkAccess { get; set; }
                
        public IEnumerable<DeviceConnectionProfile> ConnectionProfileList { get; set; }
    }
}
