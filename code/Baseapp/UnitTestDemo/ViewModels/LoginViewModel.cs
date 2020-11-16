using System;
using System.Threading.Tasks;
using System.Windows.Input;
using UnitTestDemo.Contracts.Services;
using UnitTestDemo.Contracts.Services.General;
using UnitTestDemo.Enumerations;
using UnitTestDemo.Utilities.Helpers;
using UnitTestDemo.ViewModels.Base;
using Xamarin.Forms;

namespace UnitTestDemo.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoginCommand { get; private set; }

        private readonly IAuthenticationService _authenticationService;

        private readonly IPreferencesService _preferencesService;

        private readonly ValidatorHelper _validatorHelper;

        private string _userName;

        private string _password;        

        public LoginViewModel(IConnectivityService connectivityService, IPreferencesService settingsService, INavigationService navigationService, IAuthenticationService authenticationService, IDialogService dialogService)
            : base(connectivityService, navigationService, dialogService)
        {
            //Valid input parameters
            if (connectivityService is null) throw new ArgumentNullException(nameof(connectivityService));
            if (settingsService is null) throw new ArgumentNullException(nameof(settingsService));
            if (navigationService is null) throw new ArgumentNullException(nameof(navigationService));
            if (authenticationService is null) throw new ArgumentNullException(nameof(authenticationService));
            if (dialogService is null) throw new ArgumentNullException(nameof(dialogService));

            //Initialize
            _authenticationService = authenticationService;
            _preferencesService = settingsService;
            _validatorHelper = new ValidatorHelper();
            LoginCommand = new Command(async () => await LoginAsync(UserName, Password));           
        }

        public async Task<bool> LoginAsync(string username, string password) 
        {
            IsBusy = true;
            
            var result = false;

            if (_validatorHelper.IsValidUsername(username)
                && _validatorHelper.IsValidPassword(password))
            {
                if (_connectivityService.NetworkStatus == DeviceNetworkAccess.Internet)
                {
                    if (await InternalLoginAsync(username, password))
                    {
                        result = true;
                        await _navigationService.NavigateToAsync<MainViewModel>();                        
                    }                    
                }
                else 
                {
                    await _dialogService.ShowDialog("No internet connection avaiable",
                                                    "Connectivity Error",
                                                    "OK");
                }                
            }
            else 
            {
                await _dialogService.ShowDialog("This username/password combination isn't known", 
                                                "Error logging you in", 
                                                "OK");
            }

            IsBusy = false;
            return result;
        }

        private async Task<bool> InternalLoginAsync(string username, string password) 
        {
            var authenticationResponse = await _authenticationService.AuthenticateAsync(username, password);

            if (authenticationResponse != null 
                && authenticationResponse.IsAuthenticated)
            {
                //we store the Id to know if the user is already logged in to the application
                _preferencesService.UserId = authenticationResponse.User.Id;
                _preferencesService.Username = authenticationResponse.User.FirstName;
                return true;                
            }

            return false;
        }            
    }
}
