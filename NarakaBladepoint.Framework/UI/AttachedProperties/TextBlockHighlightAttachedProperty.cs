using Avalonia.Media;

namespace NarakaBladepoint.Framework.UI.AttachedProperties
{
    public class HighlightSegmentCollection : List<HighlightSegment> { }

    public class HighlightSegment
    {
        public string Text { get; set; } = string.Empty;
        public IBrush Foreground { get; set; } = Brushes.Orange;
    }

    public static class TextBlockHighlightAttachedProperty
    {
        public static readonly Avalonia.AttachedProperty<string?> HighlightTextProperty =
            AvaloniaProperty.RegisterAttached<Avalonia.Controls.TextBlock, string?>(
                "HighlightText", typeof(TextBlockHighlightAttachedProperty));

        public static string? GetHighlightText(Avalonia.Controls.TextBlock element) =>
            element.GetValue(HighlightTextProperty);

        public static void SetHighlightText(Avalonia.Controls.TextBlock element, string? value) =>
            element.SetValue(HighlightTextProperty, value);

        public static readonly Avalonia.AttachedProperty<object?> HighlightSegmentsProperty =
            AvaloniaProperty.RegisterAttached<Avalonia.Controls.TextBlock, object?>(
                "HighlightSegments", typeof(TextBlockHighlightAttachedProperty));

        public static object? GetHighlightSegments(Avalonia.Controls.TextBlock element) =>
            element.GetValue(HighlightSegmentsProperty);

        public static void SetHighlightSegments(Avalonia.Controls.TextBlock element, object? value) =>
            element.SetValue(HighlightSegmentsProperty, value);

        public static readonly Avalonia.AttachedProperty<IBrush?> HighlightForegroundProperty =
            AvaloniaProperty.RegisterAttached<Avalonia.Controls.TextBlock, IBrush?>(
                "HighlightForeground", typeof(TextBlockHighlightAttachedProperty));

        public static IBrush? GetHighlightForeground(Avalonia.Controls.TextBlock element) =>
            element.GetValue(HighlightForegroundProperty);

        public static void SetHighlightForeground(Avalonia.Controls.TextBlock element, IBrush? value) =>
            element.SetValue(HighlightForegroundProperty, value);
    }
}
