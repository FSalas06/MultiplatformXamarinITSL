
using agenda_its.Models;
using agenda_its.ViewModels;
using Xamarin.Forms;

namespace agenda_its.Views
{
    public partial class DetailPokemonView : ContentPage
    {
        private DetailPokemonViewModel _viewModel;

        public DetailPokemonView(Pokemon pokemon)
        {
            InitializeComponent();
            BindingContext = _viewModel = new DetailPokemonViewModel(pokemon);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel?.OnAppearing();
        }
    }
}
