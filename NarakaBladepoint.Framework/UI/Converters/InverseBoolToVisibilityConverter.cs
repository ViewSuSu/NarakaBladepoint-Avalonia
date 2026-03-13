using System.Globalization;

namespace NarakaBladepoint.Framework.UI.Converters
{
    /// <summary>
    /// Converts bool to inverse bool (for IsVisible binding: true -> false, false -> true)
    /// </summary>
    public class InverseBoolToVisibilityConverter : Avalonia.Data.Converters.IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is bool boolValue)
            {
                return !boolValue;
            }
            return true;
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is bool boolValue)
            {
                return !boolValue;
            }
            return false;
        }
    }
}
