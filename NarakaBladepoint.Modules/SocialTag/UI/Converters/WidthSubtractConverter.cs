using System;
using System.Globalization;
using Avalonia.Data;using Avalonia.Data.Converters;

namespace NarakaBladepoint.Modules.SocialTag.UI.Converters
{
    public class WidthSubtractConverter : IMultiValueConverter
    {
        public object? Convert(IList<object?> values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Count >= 2 && values[0] is double tabControlWidth && values[1] is double tabItemWidth)
            {
                double result = tabControlWidth - tabItemWidth;
                return result > 0 ? result : 0;
            }
            return 0;
        }

        
    }
}
