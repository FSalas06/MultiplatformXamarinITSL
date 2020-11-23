using System;
using System.Collections.Generic;
using agenda_its.ViewModels;
using Xamarin.Forms;

namespace agenda_its.Views
{
    public partial class AddPokemonView : ContentPage
    {
        private AddPokemonViewModel _viewModel;

        public AddPokemonView()
        {
            InitializeComponent();
            BindingContext = _viewModel = new AddPokemonViewModel();

            NavigationPage.SetBackButtonTitle(this, string.Empty);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel?.OnAppearing();
        }
    }
}
