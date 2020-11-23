using System;
using System.Collections.Generic;
using agenda_its.Models;

namespace agenda_its.Contracts
{
    public interface IPokemonServices
    {
        List<Pokemon> GetPokemonList();

        //List<string> PokeType();
    }
}
