using Autofac;
using System;
using UnitTestDemo.Contracts.Services;
using UnitTestDemo.Contracts.Services.General;
using UnitTestDemo.Mocks.Services;
using UnitTestDemo.Services;
using UnitTestDemo.Services.General;
using UnitTestDemo.ViewModels;

namespace UnitTestDemo.Utilities.Helpers
{    
    public class AppContainer
    {        
        private static IContainer _container;
        
        public static void RegisterDependencies(bool useMockData)
        {
            var builder = new ContainerBuilder();

            //ViewModels
            builder.RegisterType<CheckoutViewModel>();
            builder.RegisterType<ContactViewModel>();
            builder.RegisterType<LoginViewModel>();
            builder.RegisterType<MainViewModel>();
            builder.RegisterType<PieCatalogViewModel>();
            builder.RegisterType<PieDetailViewModel>();            
            builder.RegisterType<ShoppingCartViewModel>().SingleInstance();
            builder.RegisterType<MenuViewModel>();
            builder.RegisterType<HomeViewModel>();

            //services - data
            if (useMockData)
            {
                RegisterMockDataServices(builder);
            }
            else 
            {
                RegisterDataServices(builder);
            }

            //services - general
            builder.RegisterType<ApiService>().As<IApiService>();
            builder.RegisterType<ConnectivityService>().As<IConnectivityService>();
            builder.RegisterType<NavigationService>().As<INavigationService>();            
            builder.RegisterType<DialogService>().As<IDialogService>();
            builder.RegisterType<PhoneDialerService>().As<IPhoneDialerService>();
            builder.RegisterType<PreferencesService>().As<IPreferencesService>().SingleInstance();

            //General

            _container = builder.Build();
        }
                
        public static object Resolve(Type typeName)
        {
            return _container.Resolve(typeName);
        }
                
        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        private static void RegisterDataServices(ContainerBuilder builder) 
        {
            //Regiter data servieces 
            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>();
            builder.RegisterType<CatalogDataService>().As<ICatalogDataService>();
            builder.RegisterType<ContactDataService>().As<IContactDataService>();
            builder.RegisterType<OrderDataService>().As<IOrderDataService>();
            builder.RegisterType<ShoppingCartDataService>().As<IShoppingCartDataService>();
        }

        private static void RegisterMockDataServices(ContainerBuilder builder)
        {
            //Register mock data services
            builder.RegisterType<AuthenticationServiceMock>().As<IAuthenticationService>();
            builder.RegisterType<CatalogDataServiceMock>().As<ICatalogDataService>();
            builder.RegisterType<ContactDataServiceMock>().As<IContactDataService>();
            builder.RegisterType<OrderDataServiceMock>().As<IOrderDataService>();
            builder.RegisterType<ShoppingCartDataServiceMock>().As<IShoppingCartDataService>();
        }
    }
}
