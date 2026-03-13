using System.Globalization;
using Avalonia.Media;

namespace NarakaBladepoint.Framework.UI.Converters
{
    public class BoolToTransparentBrushConverter : Avalonia.Data.Converters.IValueConverter
    {
        private static readonly ISolidColorBrush WhiteBrush = Brushes.White;
        private static readonly ISolidColorBrush TransparentBrush = Brushes.Transparent;

        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is bool boolValue)
            {
                return boolValue ? WhiteBrush : TransparentBrush;
            }
            return TransparentBrush;
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is ISolidColorBrush brush)
            {
                return brush.Color == Colors.White;
            }
            return false;
        }
    }
}
