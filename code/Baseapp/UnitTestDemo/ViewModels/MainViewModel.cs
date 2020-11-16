using System.Threading.Tasks;
using UnitTestDemo.Contracts.Services.General;
using UnitTestDemo.ViewModels.Base;

namespace UnitTestDemo.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MenuViewModel MenuViewModel
        {
            get => _menuViewModel;
            set
            {
                _menuViewModel = value;
                OnPropertyChanged();
            }
        }

        private MenuViewModel _menuViewModel;

        public MainViewModel(IConnectivityService connectivityService, INavigationService navigationService, IDialogService dialogService, MenuViewModel menuViewModel) : base(connectivityService, navigationService, dialogService)
        {
            _menuViewModel = menuViewModel;
        }
        
        public override async Task InitializeAsync(object data)
        {
            await Task.WhenAll
            (
                _menuViewModel.InitializeAsync(data),
                _navigationService.NavigateToAsync<HomeViewModel>()
            );
        }
    }
}
