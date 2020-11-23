using agenda_its.Models;

namespace agenda_its.ViewModels
{
    public class DetailPokemonViewModel : BaseViewmodel
    {
        private Pokemon _pokemon;

        public Pokemon Pokemon
        {
            get
            {
                return _pokemon;
            }
            set
            {
                _pokemon = value;
                OnPropertyChanged(nameof(Pokemon));
            }
        }

        public DetailPokemonViewModel(Pokemon pokemon)
        {
            Pokemon = pokemon;
        }
    }
}
