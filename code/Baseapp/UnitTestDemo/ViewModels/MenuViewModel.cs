using System.Collections.ObjectModel;
using System.Windows.Input;
using UnitTestDemo.Contracts.Services.General;
using UnitTestDemo.Enumerations;
using UnitTestDemo.Models;
using UnitTestDemo.ViewModels.Base;
using Xamarin.Forms;

namespace UnitTestDemo.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        public string WelcomeText => "Hello " + _preferencesService.Username;

        public ICommand MenuItemTappedCommand => new Command(OnMenuItemTapped);

        private ObservableCollection<MainMenuItem> _menuItems;

        private readonly IPreferencesService _preferencesService;

        public MenuViewModel(IConnectivityService connectivityService, INavigationService navigationService, IDialogService dialogService, IPreferencesService preferencesService) : base(connectivityService, navigationService, dialogService)
        {
            _preferencesService = preferencesService;
            MenuItems = new ObservableCollection<MainMenuItem>();
            LoadMenuItems();
        }        

        public ObservableCollection<MainMenuItem> MenuItems
        {
            get => _menuItems;
            set
            {
                _menuItems = value;
                OnPropertyChanged();
            }
        }

        private void OnMenuItemTapped(object menuItemTappedEventArgs)
        {
            var menuItem = ((menuItemTappedEventArgs as ItemTappedEventArgs)?.Item as MainMenuItem);

            if (menuItem != null && menuItem.MenuText == "Log out")
            {
                _preferencesService.UserId = null;
                _preferencesService.Username = null;
                _navigationService.ClearBackStack();
            }

            var type = menuItem?.ViewModelToLoad;
            _navigationService.NavigateToAsync(type);
        }

        private void LoadMenuItems()
        {
            MenuItems.Add(new MainMenuItem
            {
                MenuText = "Home",
                ViewModelToLoad = typeof(MainViewModel),
                MenuItemType = MenuItemType.Home
            });

            MenuItems.Add(new MainMenuItem
            {
                MenuText = "Pies",
                ViewModelToLoad = typeof(PieCatalogViewModel),
                MenuItemType = MenuItemType.Pies
            });

            MenuItems.Add(new MainMenuItem
            {
                MenuText = "Cart",
                ViewModelToLoad = typeof(ShoppingCartViewModel),
                MenuItemType = MenuItemType.ShoppingCart
            });

            MenuItems.Add(new MainMenuItem
            {
                MenuText = "Contact us",
                ViewModelToLoad = typeof(ContactViewModel),
                MenuItemType = MenuItemType.Contact
            });

            MenuItems.Add(new MainMenuItem
            {
                MenuText = "Log out",
                ViewModelToLoad = typeof(LoginViewModel),
                MenuItemType = MenuItemType.Logout
            });
        }
    }
}
