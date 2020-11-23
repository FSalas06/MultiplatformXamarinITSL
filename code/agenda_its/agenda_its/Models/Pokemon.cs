using System;
using agenda_its.Enumeration;
using SQLite;

namespace agenda_its.Models
{
    public class Pokemon
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string URLImagen { get; set; }
        public TypePokemonEnum TypePokemon { get; set; }

        public string ComposedName
        {
            get { return $"# {Number} {Name}"; }
        }
    }
}
