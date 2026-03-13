using System.Collections.Generic;
using System.Globalization;
using Avalonia.Data.Converters;

namespace NarakaBladepoint.Framework.UI.Converters
{
    public class OutRangeEnableConverter : IMultiValueConverter
    {
        public object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
        {
            if (values.Count != 3)
                return true;

            if (values[0] is not int selectedCount || values[1] is not bool isSelected || values[2] is not int maxCount)
                return true;

            if (isSelected)
                return true;

            return selectedCount < maxCount;
        }
    }
}
