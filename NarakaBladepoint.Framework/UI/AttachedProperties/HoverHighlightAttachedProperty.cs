using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;

namespace NarakaBladepoint.Framework.UI.AttachedProperties
{
    public static class HoverHighlightAttachedProperty
    {
        public static readonly AttachedProperty<bool> EnableHoverHighlightProperty =
            AvaloniaProperty.RegisterAttached<Control, bool>("EnableHoverHighlight", typeof(HoverHighlightAttachedProperty), false);

        public static bool GetEnableHoverHighlight(Control element) => element.GetValue(EnableHoverHighlightProperty);
        public static void SetEnableHoverHighlight(Control element, bool value) => element.SetValue(EnableHoverHighlightProperty, value);

        public static readonly AttachedProperty<IBrush?> HighlightBrushProperty =
            AvaloniaProperty.RegisterAttached<Control, IBrush?>("HighlightBrush", typeof(HoverHighlightAttachedProperty));

        public static IBrush? GetHighlightBrush(Control element) => element.GetValue(HighlightBrushProperty);
        public static void SetHighlightBrush(Control element, IBrush? value) => element.SetValue(HighlightBrushProperty, value);

        static HoverHighlightAttachedProperty()
        {
            EnableHoverHighlightProperty.Changed.AddClassHandler<Control>(OnEnableHoverHighlightChanged);
        }

        private static void OnEnableHoverHighlightChanged(Control control, AvaloniaPropertyChangedEventArgs e)
        {
            if (e.NewValue is true)
            {
                control.PointerEntered += OnPointerEntered;
                control.PointerExited += OnPointerExited;
            }
            else
            {
                control.PointerEntered -= OnPointerEntered;
                control.PointerExited -= OnPointerExited;
                control.Opacity = 1.0;
            }
        }

        private static void OnPointerEntered(object? sender, PointerEventArgs e)
        {
            if (sender is Control c) c.Opacity = 0.7;
        }

        private static void OnPointerExited(object? sender, PointerEventArgs e)
        {
            if (sender is Control c) c.Opacity = 1.0;
        }
    }
}
