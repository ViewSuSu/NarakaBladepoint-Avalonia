using System.Globalization;
using Avalonia.Media.Imaging;

namespace NarakaBladepoint.Framework.UI.Converters
{
    public class ImageSourceToFileNameConverter : Avalonia.Data.Converters.IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is Bitmap bitmap)
            {
                return bitmap.ToString();
            }
            return value?.ToString();
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
