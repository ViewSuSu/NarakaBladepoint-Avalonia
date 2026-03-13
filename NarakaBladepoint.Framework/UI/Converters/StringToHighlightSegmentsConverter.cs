using System.Globalization;
using Avalonia.Media;
using NarakaBladepoint.Framework.UI.AttachedProperties;

namespace NarakaBladepoint.Framework.UI.Converters
{
    public class StringToHighlightSegmentsConverter : Avalonia.Data.Converters.IValueConverter
    {
        public IBrush DefaultOrangeBrush { get; set; } = Brushes.Orange;

        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is not List<string> highlightTexts || highlightTexts.Count == 0)
                return null;

            var segments = new HighlightSegmentCollection();
            foreach (var text in highlightTexts)
            {
                if (string.IsNullOrWhiteSpace(text))
                    continue;
                segments.Add(new HighlightSegment { Text = text.Trim(), Foreground = DefaultOrangeBrush });
            }
            return segments.Count > 0 ? segments : null;
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
