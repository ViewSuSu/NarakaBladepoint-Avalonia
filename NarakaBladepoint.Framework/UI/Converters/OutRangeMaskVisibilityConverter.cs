using System.Collections.Generic;
using System.Globalization;
using Avalonia.Data.Converters;

namespace NarakaBladepoint.Framework.UI.Converters
{
    public class OutRangeMaskVisibilityConverter : IMultiValueConverter
    {
        public object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
        {
            if (values.Count != 3)
                return false;

            if (values[0] is not int selectedCount || values[1] is not bool isSelected || values[2] is not int maxCount)
                return false;

            return selectedCount >= maxCount && !isSelected;
        }
    }
}
