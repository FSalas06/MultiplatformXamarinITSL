﻿using System.Collections.ObjectModel;
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
    public class ShoppingCartViewModel : BaseViewModel
    {
        public ICommand CheckOutCommand => new Command(OnCheckOut);

        public ObservableCollection<ShoppingCartItem> ShoppingCartItems
        {
            get => _shoppingCartItems;
            set
            {
                _shoppingCartItems = value;
                RecalculateBasket();
                OnPropertyChanged();
            }
        }

        public decimal GrandTotal
        {
            get => _grandTotal;
            set
            {
                _grandTotal = value;
                OnPropertyChanged();
            }
        }

        public decimal Shipping
        {
            get => _shipping;
            set
            {
                _shipping = value;
                OnPropertyChanged();
            }
        }

        public decimal Taxes
        {
            get => _taxes;
            set
            {
                _taxes = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<ShoppingCartItem> _shoppingCartItems;

        private readonly IPreferencesService _preferencesService;

        private readonly IShoppingCartDataService _shoppingCartService;

        private decimal _orderTotal;

        private decimal _taxes;

        private decimal _shipping;

        private decimal _grandTotal;

        public ShoppingCartViewModel(IConnectivityService connectivityService, INavigationService navigationService, IDialogService dialogService, IShoppingCartDataService shoppingCartService, IPreferencesService settingsService) : base(connectivityService, navigationService, dialogService)
        {
            _shoppingCartService = shoppingCartService;
            _preferencesService = settingsService;
            _shoppingCartItems = new ObservableCollection<ShoppingCartItem>();
            _orderTotal = 0;
        }       

        public void InitializeMessenger()
        {
            MessagingCenter.Subscribe<PieDetailViewModel, Pie>(this, MessagingConstants.AddPieToBasket, (pieDetailViewModel, pie) => OnAddPieToBasketReceived(pie));
            MessagingCenter.Subscribe<HomeViewModel, Pie>(this, MessagingConstants.AddPieToBasket, (homeViewModel, pie) => OnAddPieToBasketReceived(pie));
            MessagingCenter.Subscribe<CheckoutViewModel>(this, "OrderPlaced", model => OnOrderPlaced());
        }

        private void OnCheckOut()
        {
            _navigationService.NavigateToAsync<CheckoutViewModel>();
        }

        private void OnOrderPlaced()
        {
            ShoppingCartItems.Clear();
        }

        private void RecalculateBasket()
        {
            _orderTotal = CalculateOrderTotal();
            Taxes = _orderTotal * (decimal)0.2;
            Shipping = _orderTotal * (decimal)0.1;
            GrandTotal = _orderTotal + _shipping + _taxes;
        }

        private decimal CalculateOrderTotal()
        {
            decimal total = 0;

            foreach (var shoppingCartItem in ShoppingCartItems)
            {
                total += shoppingCartItem.Quantity * shoppingCartItem.Pie.Price;
            }

            return total;
        }

        public override async Task InitializeAsync(object data)
        {
            var shoppingCart = await _shoppingCartService.GetShoppingCartAsync(_preferencesService.UserId);
            ShoppingCartItems = shoppingCart.ShoppingCartItems.ToObservableCollection();
        }

        private async void OnAddPieToBasketReceived(Pie pie)
        {
            var shoppingCartItem = new ShoppingCartItem() { Pie = pie, PieId = pie.PieId, Quantity = 1 };

            await _shoppingCartService.AddShoppingCartItemAsync(shoppingCartItem, _preferencesService.UserId);

            ShoppingCartItems.Add(shoppingCartItem);

            RecalculateBasket();
        }
    }
}