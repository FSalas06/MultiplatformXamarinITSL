using Moq;
using System;
using System.Threading.Tasks;
using UnitTestDemo.Contracts.Services;
using UnitTestDemo.Contracts.Services.General;
using UnitTestDemo.Models;
using UnitTestDemo.ViewModels;
using Xunit;

namespace UnitTestDemo.Test.ViewModels
{
    public class LoginViewModelTest
    {
        private IConnectivityService _connectivityService;

        private IPreferencesService _preferencesService;

        private INavigationService _navigationService;

        private IAuthenticationService _authenticationService;

        private IDialogService _dialogService;

        public LoginViewModelTest()
        {
            //Constructor is called for every test
            _connectivityService = new Mock<IConnectivityService>().Object;
            _preferencesService = new Mock<IPreferencesService>().Object;
            _navigationService = new Mock<INavigationService>().Object;
            _authenticationService = new Mock<IAuthenticationService>().Object;
            _dialogService = new Mock<IDialogService>().Object;
        }

        [Fact]
        public void LoginViewModel_CorrectInitialization_ObjectCreated() 
        {
            //Arrange

            //Act
            var loginViewModel = new LoginViewModel(_connectivityService, 
                                                    _preferencesService,
                                                    _navigationService, 
                                                    _authenticationService, 
                                                    _dialogService);

            //Assert
            Assert.NotNull(loginViewModel);
        }

        [Fact]
        public void LoginViewModel_IncorrectInitializationOnMissingDialogService_ThrowArgumentNullException()
        {
            //Arrange               

            //Act-Assert
            Assert.Throws<ArgumentNullException>(() => 
            {
                var loginViewModel = new LoginViewModel(_connectivityService,
                                                        _preferencesService,
                                                        _navigationService,
                                                        _authenticationService,
                                                        null);
            });
        }

        [Theory]
        [InlineData("Javs", "Password")]
        [InlineData("Ulises", "Abcd1234")]
        public async Task Login_CorrectLogin_ReturnTrue(string username, string password)
        {
            //Arrange       
            var mockConnectivityService = new Mock<IConnectivityService>();
            var mockAuthenticationService = new Mock<IAuthenticationService>();

            mockConnectivityService.Setup(connectivity => connectivity.NetworkStatus).Returns(Enumerations.DeviceNetworkAccess.Internet);
            mockAuthenticationService.Setup(auth => auth.AuthenticateAsync(It.IsAny<string>(), It.IsAny<string>()))
                                     .Returns(Task.FromResult(new AuthenticationResponse
                                     {
                                         IsAuthenticated = true,
                                         User = new User
                                         {
                                             Id = "1234",
                                             Email = "fakeemail@mail.com",
                                             UserName = username,
                                             LastName = "Javier",
                                             FirstName = "Sánchez"
                                         }
                                     }));

            var loginViewModel = new LoginViewModel(mockConnectivityService.Object,
                                                    _preferencesService,
                                                    _navigationService,
                                                    mockAuthenticationService.Object,
                                                    _dialogService);

            //Act
            var result = await loginViewModel.LoginAsync(username, password);

            //Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData("Javs", "Pa")]
        [InlineData("Ul", "Abcd1234")]        
        [InlineData("Ulises", "Ab")]
        public async Task Login_IncorrectLoginIfInvalidPassOrUsername_ReturnFalse(string username, string password)
        {
            //Arrange       
            var mockConnectivityService = new Mock<IConnectivityService>();
            var mockAuthenticationService = new Mock<IAuthenticationService>();

            mockConnectivityService.Setup(connectivity => connectivity.NetworkStatus).Returns(Enumerations.DeviceNetworkAccess.Internet);
            mockAuthenticationService.Setup(auth => auth.AuthenticateAsync(It.IsAny<string>(), It.IsAny<string>()))
                                    .Returns(Task.FromResult(new AuthenticationResponse
                                    {
                                        IsAuthenticated = false,
                                        User = new User
                                        {
                                            Id = "1234",
                                            Email = "fakeemail@mail.com",
                                            UserName = username,
                                            LastName = "Javier",
                                            FirstName = "Sánchez"
                                        }
                                    }));            

            var loginViewModel = new LoginViewModel(mockConnectivityService.Object,
                                                    _preferencesService,
                                                    _navigationService,
                                                    mockAuthenticationService.Object,
                                                    _dialogService);

            //Act
            var result = await loginViewModel.LoginAsync(username, password);

            //Assert
            Assert.False(result);
        }

        [Fact]        
        public async Task Login_IncorrectLoginIfNoInternetConnection_ReturnFalse()
        {
            //Arrange    
            var validUsername = "Javier";
            var validPassword = "Abcd1234";
            var mockConnectivityService = new Mock<IConnectivityService>();
            var mockAuthenticationService = new Mock<IAuthenticationService>();

            mockConnectivityService.Setup(connectivity => connectivity.NetworkStatus).Returns(Enumerations.DeviceNetworkAccess.None);
            mockAuthenticationService.Setup(auth => auth.AuthenticateAsync(validUsername, validPassword))
                                     .Returns(Task.FromResult(new AuthenticationResponse 
                                     {
                                         IsAuthenticated = true,
                                         User = new User
                                         {
                                             Id = "1234",
                                             Email = "fakeemail@mail.com",
                                             UserName = validUsername,
                                             LastName = "Javier",
                                             FirstName = "Sánchez"
                                         }
                                     }));            

            var loginViewModel = new LoginViewModel(mockConnectivityService.Object,
                                                    _preferencesService,
                                                    _navigationService,
                                                    mockAuthenticationService.Object,
                                                    _dialogService);

            //Act
            var result = await loginViewModel.LoginAsync(validUsername, validPassword);

            //Assert
            Assert.False(result);            
        }

        [Fact]        
        public async Task Login_IncorrectLoginIfServiceResponseIsNull_ReturnFalse()
        {
            //Arrange    
            var validUsername = "Javier";
            var validPassword = "Abcd1234";
            var mockConnectivityService = new Mock<IConnectivityService>();
            var mockAuthenticationService = new Mock<IAuthenticationService>();

            mockConnectivityService.Setup(connectivity => connectivity.NetworkStatus).Returns(Enumerations.DeviceNetworkAccess.Internet);
            mockAuthenticationService.Setup(auth => auth.AuthenticateAsync(It.IsAny<string>(), It.IsAny<string>()))
                                     .Returns(Task.FromResult(default(AuthenticationResponse)));                                     

            var loginViewModel = new LoginViewModel(mockConnectivityService.Object,
                                                    _preferencesService,
                                                    _navigationService,
                                                    mockAuthenticationService.Object,
                                                    _dialogService);

            //Act
            var result = await loginViewModel.LoginAsync(validUsername, validPassword);

            //Assert
            Assert.False(result);
        }
    }
}
