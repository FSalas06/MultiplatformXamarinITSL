using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using agenda_its.Enumeration;
using agenda_its.Models;
using agenda_its.Views;
using Xamarin.Forms;

namespace agenda_its.ViewModels
{
    public class AddPokemonViewModel : BaseViewmodel
    {
        private ObservableCollection<string> _typeSource;
        private int _number;
        private string _name;
        private string _typePokemon;

        public string TypePokemon
        {
            get
            {
                return _typePokemon;
            }
            set
            {
                _typePokemon = value;
                OnPropertyChanged(nameof(TypePokemon));
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public int Number
        {
            get
            {
                return _number;
            }
            set
            {
                _number = value;
                OnPropertyChanged(nameof(Number));
            }
        }

        public ObservableCollection<string> TypeSource
        {
            get
            {
                return _typeSource;
            }
            set
            {
                _typeSource = value;
                OnPropertyChanged(nameof(TypeSource));
            }
        }

        public ICommand AddPokemonCommand { get; set; }

        public AddPokemonViewModel()
        {
            AddPokemonCommand = new Command(AddPokemon);
        }

        public override void OnAppearing()
        {
            base.OnAppearing();

            var types = Enum.GetValues(typeof(TypePokemonEnum)).Cast<TypePokemonEnum>();
            var auxType = new List<string>();

            foreach(var x in types)
            {
                auxType.Add(x.ToString());
            }

            TypeSource = new ObservableCollection<string>(auxType);
        }

        
        private async void AddPokemon()
        {
            TypePokemonEnum typePokemon =
                (TypePokemonEnum)Enum.Parse(typeof(TypePokemonEnum), TypePokemon, true);

            Pokemon pokemon = new Pokemon()
            {
                Number = Number,
                Name = Name,
                TypePokemon = typePokemon,
            };

            await App.Database.SaveItemAsync(pokemon);
            AlertToast("Pokemon Saved!");
            //goback
        }
    }
}
