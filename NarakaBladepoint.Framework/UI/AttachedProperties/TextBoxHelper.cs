using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace NarakaBladepoint.Framework.UI.AttachedProperties
{
    public static class TextBoxHelper
    {
        public static readonly AttachedProperty<string?> PlaceholderTextProperty =
            AvaloniaProperty.RegisterAttached<TextBox, string?>("PlaceholderText", typeof(TextBoxHelper));

        public static string? GetPlaceholderText(TextBox element) => element.GetValue(PlaceholderTextProperty);
        public static void SetPlaceholderText(TextBox element, string? value) => element.SetValue(PlaceholderTextProperty, value);

        public static readonly AttachedProperty<string?> PlaceholderProperty =
            AvaloniaProperty.RegisterAttached<TextBox, string?>("Placeholder", typeof(TextBoxHelper));

        public static string? GetPlaceholder(TextBox element) => element.GetValue(PlaceholderProperty);
        public static void SetPlaceholder(TextBox element, string? value) => element.SetValue(PlaceholderProperty, value);

        public static readonly AttachedProperty<IBrush?> PlaceholderForegroundProperty =
            AvaloniaProperty.RegisterAttached<TextBox, IBrush?>("PlaceholderForeground", typeof(TextBoxHelper));

        public static IBrush? GetPlaceholderForeground(TextBox element) => element.GetValue(PlaceholderForegroundProperty);
        public static void SetPlaceholderForeground(TextBox element, IBrush? value) => element.SetValue(PlaceholderForegroundProperty, value);

        public static readonly AttachedProperty<TextAlignment> PlaceholderTextAlignmentProperty =
            AvaloniaProperty.RegisterAttached<TextBox, TextAlignment>("PlaceholderTextAlignment", typeof(TextBoxHelper));

        public static TextAlignment GetPlaceholderTextAlignment(TextBox element) => element.GetValue(PlaceholderTextAlignmentProperty);
        public static void SetPlaceholderTextAlignment(TextBox element, TextAlignment value) => element.SetValue(PlaceholderTextAlignmentProperty, value);
    }
}
