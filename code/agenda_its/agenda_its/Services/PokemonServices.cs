using System.Collections.Generic;
using agenda_its.Contracts;
using agenda_its.Enumeration;
using agenda_its.Models;

namespace agenda_its.Services
{
    public class PokemonServices : IPokemonServices
    {
        private static List<Pokemon> _pokemonlist;
        private readonly string _dummyDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged";

        public List<Pokemon> GetPokemonList()
        {
            _pokemonlist = new List<Pokemon>
            {
                new Pokemon
                {
                    Number = 25,
                    Name = "Pikachu",
                    TypePokemon = TypePokemonEnum.Thunder,
                    Description = _dummyDescription,
                },
                new Pokemon
                {
                    Number = 30,
                    Name = "Pikachu",
                    TypePokemon = TypePokemonEnum.Earth,
                    Description = _dummyDescription,
                },
                new Pokemon
                {
                    Number = 31,
                    Name = "Pikachu",
                    TypePokemon = TypePokemonEnum.Fire,
                    Description = _dummyDescription,
                },
                new Pokemon
                {
                    Number = 32,
                    Name = "Pikachu",
                    TypePokemon = TypePokemonEnum.Water,
                    Description = _dummyDescription,
                },
            };

            return _pokemonlist;
        }
    }
}
