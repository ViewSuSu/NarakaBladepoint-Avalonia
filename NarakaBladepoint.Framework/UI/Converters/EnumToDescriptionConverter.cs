using System.Globalization;
using NarakaBladepoint.Framework.Core.Extensions;

namespace NarakaBladepoint.Framework.UI.Converters
{
    public class EnumToDescriptionConverter : Avalonia.Data.Converters.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return string.Empty;
            if (value is Enum enumValue)
            {
                return enumValue.GetDescription() ?? enumValue.ToString();
            }
            return value.ToString();
        }

        public object ConvertBack(
            object value,
            Type targetType,
            object parameter,
            CultureInfo culture
        )
        {
            return Avalonia.Data.BindingOperations.DoNothing;
        }
    }
}
