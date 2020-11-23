using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using agenda_its.Models;
using agenda_its.Services;
using Xamarin.Forms;
using agenda_its.Views;
using System.Linq;

namespace agenda_its.ViewModels
{
    public class MainViewModel : BaseViewmodel
    {
        private readonly PokemonServices _pokemonServices;
        private ObservableCollection<Pokemon> _pokemonList;
        private Pokemon _pokemonSelected;

        public Pokemon PokemonSelected
        {
            get { return _pokemonSelected; }
            set
            {
                _pokemonSelected = value;
                OnPropertyChanged(nameof(PokemonSelected));
                if (_pokemonSelected != null)
                {
                    GoToNextPage(new DetailPokemonView(value));
                }
            }
        }

        public ObservableCollection<Pokemon> PokemonList
        {
            get { return _pokemonList; }
            set
            {
                _pokemonList = value;
                OnPropertyChanged();
            }
        }

        public ICommand NewPokemonCommand { get; set; }

        public MainViewModel()
        {
            _pokemonServices = new PokemonServices();
            NewPokemonCommand = new Command(AddNewPokemon);
        }

        public override void OnAppearing()
        {
            base.OnAppearing();
            PokemonList = new ObservableCollection<Pokemon>(_pokemonServices.GetPokemonList());
        }

        private void AddNewPokemon()
        {
            GoToNextPage(new AddPokemonView());
        }
    }
}
