using System.Globalization;
using Avalonia;
using Avalonia.Data.Converters;

namespace NarakaBladepoint.Controls.Converters
{
    internal class BoolInverterConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool b)
            {
                return !b;
            }

            return AvaloniaProperty.UnsetValue;
        }

        public object ConvertBack(
            object value,
            Type targetType,
            object parameter,
            CultureInfo culture
        )
        {
            if (value is bool b)
            {
                return !b;
            }

            return AvaloniaProperty.UnsetValue;
        }
    }
}

