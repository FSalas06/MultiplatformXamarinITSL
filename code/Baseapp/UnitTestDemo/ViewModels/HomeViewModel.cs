using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using UnitTestDemo.Contracts.Services;
using UnitTestDemo.Contracts.Services.General;
using UnitTestDemo.Models;
using UnitTestDemo.Utilities.Constants;
using UnitTestDemo.Utilities.Extensions;
using UnitTestDemo.ViewModels.Base;
using Xamarin.Forms;

namespace UnitTestDemo.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public ObservableCollection<Pie> PiesOfTheWeek
        {
            get => _piesOfTheWeek;
            set
            {
                _piesOfTheWeek = value;
                OnPropertyChanged();
            }
        }

        public ICommand PieTappedCommand => new Command<Pie>(OnPieTapped);
        public ICommand AddToCartCommand => new Command<Pie>(OnAddToCart);

        private readonly ICatalogDataService _catalogDataService;

        private ObservableCollection<Pie> _piesOfTheWeek;

        public HomeViewModel(IConnectivityService connectivityService, INavigationService navigationService, IDialogService dialogService, ICatalogDataService catalogDataService) : base(connectivityService, navigationService, dialogService)
        {
            _catalogDataService = catalogDataService;

            PiesOfTheWeek = new ObservableCollection<Pie>();
        }        

        public override async Task InitializeAsync(object data)
        {
            PiesOfTheWeek = (await _catalogDataService.GetPiesOfTheWeekAsync()).ToObservableCollection();
        }

        private void OnPieTapped(Pie selectedPie)
        {
            _navigationService.NavigateToAsync<PieDetailViewModel>(selectedPie);
        }

        private async void OnAddToCart(Pie selectedPie)
        {
            MessagingCenter.Send(this, MessagingConstants.AddPieToBasket, selectedPie);
            await _dialogService.ShowDialog("Pie added to your cart", "Success", "OK");
        }
    }
}
