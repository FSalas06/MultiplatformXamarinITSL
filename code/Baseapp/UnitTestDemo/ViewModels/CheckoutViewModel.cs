using System;
using System.Threading.Tasks;
using System.Windows.Input;
using UnitTestDemo.Contracts.Services;
using UnitTestDemo.Contracts.Services.General;
using UnitTestDemo.Models;
using UnitTestDemo.ViewModels.Base;
using Xamarin.Forms;

namespace UnitTestDemo.ViewModels
{
    public class CheckoutViewModel : BaseViewModel
    {
        private readonly IOrderDataService _orderDataService;
        private readonly IPreferencesService _preferencesService;
        private Order _order;

        public CheckoutViewModel(IConnectivityService connectivityService, INavigationService navigationService, IDialogService dialogService, IOrderDataService orderDataService, IPreferencesService preferencesService) : base(connectivityService, navigationService, dialogService)
        {
            _orderDataService = orderDataService;
            _preferencesService = preferencesService;
        }

        public ICommand PlaceOrderCommand => new Command(OnPlaceOrder);

        public Order Order
        {
            get => _order;
            set
            {
                _order = value;
                OnPropertyChanged();
            }
        }

        public override Task InitializeAsync(object data)
        {
            Order = new Order { OrderId = Guid.NewGuid().ToString(), Address = new Address(), UserId = _preferencesService.UserId };

            return base.InitializeAsync(data);
        }

        private async void OnPlaceOrder()
        {
            await _orderDataService.PlaceOrderAsync(Order);
            MessagingCenter.Send(this, "OrderPlaced");
            await _dialogService.ShowDialog("Order placed successfully", "Success", "OK");
            await _navigationService.PopToRootAsync();
        }
    }
}
