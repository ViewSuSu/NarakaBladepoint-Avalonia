using System.Collections.Generic;
using System.Globalization;
using Avalonia.Data.Converters;

namespace NarakaBladepoint.Controls.Converters
{
    /// <summary>
    /// 计算底部背景高度：IconHeight * BackgroundHeightFactor
    /// </summary>
    internal class IconTabItemConverter : IMultiValueConverter
    {
        public object? Convert(
            IList<object?> values,
            Type targetType,
            object? parameter,
            CultureInfo culture
        )
        {
            if (values.Count >= 2 && values[0] is double iconHeight && values[1] is double factor)
            {
                return iconHeight * factor;
            }
            return 30.0 * 1.1;
        }
    }
}



