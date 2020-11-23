using System;
using System.Globalization;
using agenda_its.Enumeration;
using agenda_its.Models;
using Xamarin.Forms;

namespace agenda_its.Utilities
{
    public class TypeColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var pokType = (TypePokemonEnum)value;
            switch (pokType)
            {
                case TypePokemonEnum.Fire:
                    return Color.Orange;

                case TypePokemonEnum.Earth:
                    return Color.Brown;

                case TypePokemonEnum.Thunder:
                    return Color.Yellow;

                case TypePokemonEnum.Water:
                    return Color.Aqua;

                default:
                    return Color.Silver;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
