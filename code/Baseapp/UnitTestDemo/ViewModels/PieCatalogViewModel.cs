
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using UnitTestDemo.Contracts.Services;
using UnitTestDemo.Contracts.Services.General;
using UnitTestDemo.Models;
using UnitTestDemo.Utilities.Extensions;
using UnitTestDemo.ViewModels.Base;
using Xamarin.Forms;

namespace UnitTestDemo.ViewModels
{
    public class PieCatalogViewModel : BaseViewModel
    {
        public ObservableCollection<Pie> Pies
        {
            get => _pies;
            set
            {
                _pies = value;
                OnPropertyChanged();
            }
        }

        public ICommand PieTappedCommand => new Command<Pie>(OnPieTapped);

        private readonly ICatalogDataService _catalogDataService;

        private ObservableCollection<Pie> _pies;

        public PieCatalogViewModel(IConnectivityService connectivityService, INavigationService navigationService, IDialogService dialogService, ICatalogDataService catalogDataService) : base(connectivityService, navigationService, dialogService)
        {
            _catalogDataService = catalogDataService;
        }        

        private void OnPieTapped(Pie selectedPie)
        {
            _navigationService.NavigateToAsync<PieDetailViewModel>(selectedPie);
        }

        public override async Task InitializeAsync(object data)
        {
            IsBusy = true;

            Pies = (await _catalogDataService.GetAllPiesAsync()).ToObservableCollection();

            IsBusy = false;
        }
    }
}
