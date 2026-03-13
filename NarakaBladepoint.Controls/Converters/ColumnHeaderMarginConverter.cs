using System.Collections.Generic;
using System.Globalization;
using Avalonia;
using Avalonia.Data.Converters;

namespace NarakaBladepoint.Controls.Converters
{
    /// <summary>
    /// 灏嗗垪澶寸殑 DisplayIndex 鍜屾€诲垪鏁拌浆鎹负 Thickness margin
    /// - 绗竴鍒楋紙棣栧垪锛? left=0, right=5 锛堥鍒楀乏渚ч棿璺濅负 0锛?
    /// - 涓棿鍒? left=0, right=5 锛堜腑闂村垪鍙充晶闂磋窛涓?5锛?
    /// - 鏈€鍚庝竴鍒楋紙鏈垪锛? left=0, right=0 锛堟湯鍒楀彸渚ч棿璺濅负 0锛?
    /// </summary>
    internal class ColumnHeaderMarginConverter : IMultiValueConverter
    {
        public object? Convert(
            IList<object?> values,
            Type targetType,
            object? parameter,
            CultureInfo culture
        )
        {
            if (values == null || values.Count < 2)
                return new Thickness(0);

            if (!int.TryParse(values[0]?.ToString() ?? "0", out int displayIndex))
                displayIndex = 0;

            if (!int.TryParse(values[1]?.ToString() ?? "0", out int count))
                count = 0;

            // 濡傛灉鍙湁涓€鍒楁垨娌℃湁鍒楋紝杩斿洖鏃犻棿璺?
            if (count <= 1)
                return new Thickness(0);

            const double gap = 5.0;
            double left = 0;  // 鎵€鏈夊垪宸︿晶闂磋窛閮戒负 0
            double right = gap;  // 榛樿鍙充晶闂磋窛涓?5

            // 鏈€鍚庝竴鍒楀彸渚ч棿璺濅负 0
            if (displayIndex == count - 1)
                right = 0;

            return new Thickness(left, 0, right, 0);
        }
    }
}



