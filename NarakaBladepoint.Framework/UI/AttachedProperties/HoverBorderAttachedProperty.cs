using Avalonia.Controls;
using Avalonia.Media;

namespace NarakaBladepoint.Framework.UI.AttachedProperties
{
    public static class HoverBorderAttachedProperty
    {
        public static readonly Avalonia.AttachedProperty<IBrush?> HoverBrushProperty =
            AvaloniaProperty.RegisterAttached<Control, IBrush?>("HoverBrush", typeof(HoverBorderAttachedProperty));

        public static IBrush? GetHoverBrush(Control element) => element.GetValue(HoverBrushProperty);
        public static void SetHoverBrush(Control element, IBrush? value) => element.SetValue(HoverBrushProperty, value);
    }
}
