using System.Threading.Tasks;
using System.Windows.Input;
using UnitTestDemo.Contracts.Services.General;
using UnitTestDemo.Models;
using UnitTestDemo.Utilities.Constants;
using UnitTestDemo.ViewModels.Base;
using Xamarin.Forms;

namespace UnitTestDemo.ViewModels
{
    public class PieDetailViewModel : BaseViewModel
    {
        public Pie SelectedPie
        {
            get => _selectedPie;
            set
            {
                _selectedPie = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddToCartCommand => new Command(OnAddToCart);

        private Pie _selectedPie;        

        public PieDetailViewModel(IConnectivityService connectivityService, INavigationService navigationService, IDialogService dialogService) : base(connectivityService, navigationService, dialogService)
        { 
        }        

        public override async Task InitializeAsync(object data)
        {
            SelectedPie = (Pie)data;
        }

        private async void OnAddToCart()
        {
            MessagingCenter.Send(this, MessagingConstants.AddPieToBasket, SelectedPie);
            await _dialogService.ShowDialog("Pie added to your cart", "Success", "OK");
        }        
    }
}
