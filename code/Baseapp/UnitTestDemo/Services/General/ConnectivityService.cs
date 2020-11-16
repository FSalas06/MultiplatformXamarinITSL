using System;
using System.Collections.Generic;
using System.Linq;
using UnitTestDemo.Contracts.Services.General;
using UnitTestDemo.Enumerations;
using UnitTestDemo.Utilities.Helpers;
using Xamarin.Essentials;

namespace UnitTestDemo.Services.General
{ 
    public class ConnectivityService : IConnectivityService
    {
        #region Properties        
                
        public event DeviceConnectivityChangedEventHandler OnDeviceConnectivityChanged;
               
        public DeviceNetworkAccess NetworkStatus
        {
            get => NetworkAccessToDeviceNetworkAccess(Connectivity.NetworkAccess);
        }

        #endregion Properties

        #region Constructors
              
        public ConnectivityService()
        {
            Connectivity.ConnectivityChanged += OnConnectivityChanged;
        }

        #endregion Constructors

        #region Methods        
               
        public IEnumerable<DeviceConnectionProfile> CurrentConnectionProfiles()
        {
            return ConnectionProfileToDeviceConnectionProfile(Connectivity.ConnectionProfiles);
        }
                
        public bool ActiveProfile(DeviceConnectionProfile profile)
        {
            var currentActiveProfileList = Connectivity.ConnectionProfiles;

            return (currentActiveProfileList != null
                    && currentActiveProfileList.Contains(DeviceConnectionProfileToConnectionProfile(profile)));
        }
                
        private void OnConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            var deviceConnectivityEventArgs = new DeviceConnectivityChangedEventArgs
            {
                NetworkAccess = DeviceNetworkAccess.Unknown,
                ConnectionProfileList = new List<DeviceConnectionProfile>()
            };

            if (e != null)
            {
                deviceConnectivityEventArgs.NetworkAccess = NetworkAccessToDeviceNetworkAccess(e.NetworkAccess);
                deviceConnectivityEventArgs.ConnectionProfileList = ConnectionProfileToDeviceConnectionProfile(e.ConnectionProfiles);
            }

            OnDeviceConnectivityChanged?.Invoke(this, deviceConnectivityEventArgs);
        }
                
        private DeviceNetworkAccess NetworkAccessToDeviceNetworkAccess(NetworkAccess networkAccess)
        {
            switch (networkAccess)
            {
                case NetworkAccess.Internet:
                    return DeviceNetworkAccess.Internet;

                case NetworkAccess.ConstrainedInternet:
                    return DeviceNetworkAccess.ConstrainedInternet;

                case NetworkAccess.Local:
                    return DeviceNetworkAccess.Local;

                case NetworkAccess.None:
                    return DeviceNetworkAccess.None;

                default:
                    return DeviceNetworkAccess.Unknown;
            }
        }
               
        private IEnumerable<DeviceConnectionProfile> ConnectionProfileToDeviceConnectionProfile(IEnumerable<ConnectionProfile> connectionProfileList)
        {
            var result = new List<DeviceConnectionProfile>();

            if (connectionProfileList != null)
            {
                foreach (var profile in connectionProfileList)
                {
                    result.Add(ConnectionProfileToDeviceConnectionProfile(profile));
                }
            }

            return result;
        }
                
        private DeviceConnectionProfile ConnectionProfileToDeviceConnectionProfile(ConnectionProfile connectionProfile)
        {
            switch (connectionProfile)
            {
                case ConnectionProfile.Bluetooth:
                    return DeviceConnectionProfile.Bluetooth;

                case ConnectionProfile.Cellular:
                    return DeviceConnectionProfile.Cellular;

                case ConnectionProfile.Ethernet:
                    return DeviceConnectionProfile.Ethernet;

                case ConnectionProfile.WiFi:
                    return DeviceConnectionProfile.WiFi;

                default:
                    return DeviceConnectionProfile.Unknown;
            }
        }
                
        private ConnectionProfile DeviceConnectionProfileToConnectionProfile(DeviceConnectionProfile connectionProfile)
        {
            switch (connectionProfile)
            {
                case DeviceConnectionProfile.Bluetooth:
                    return ConnectionProfile.Bluetooth;

                case DeviceConnectionProfile.Cellular:
                    return ConnectionProfile.Cellular;

                case DeviceConnectionProfile.Ethernet:
                    return ConnectionProfile.Ethernet;

                case DeviceConnectionProfile.WiFi:
                    return ConnectionProfile.WiFi;

                default:
                    return ConnectionProfile.Unknown;
            }
        }

        #endregion Methods
    }
}
