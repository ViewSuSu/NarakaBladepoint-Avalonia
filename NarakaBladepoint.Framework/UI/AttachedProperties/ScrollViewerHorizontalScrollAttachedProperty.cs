using Avalonia;
using Avalonia.Controls;

namespace NarakaBladepoint.Framework.UI.AttachedProperties
{
    public static class ScrollViewerHorizontalScrollAttachedProperty
    {
        public static readonly AttachedProperty<bool> EnableHorizontalScrollProperty =
            AvaloniaProperty.RegisterAttached<ScrollViewer, bool>("EnableHorizontalScroll", typeof(ScrollViewerHorizontalScrollAttachedProperty));

        public static bool GetEnableHorizontalScroll(ScrollViewer element) => element.GetValue(EnableHorizontalScrollProperty);
        public static void SetEnableHorizontalScroll(ScrollViewer element, bool value) => element.SetValue(EnableHorizontalScrollProperty, value);

        public static readonly AttachedProperty<bool> EnableMouseWheelScrollProperty =
            AvaloniaProperty.RegisterAttached<ScrollViewer, bool>("EnableMouseWheelScroll", typeof(ScrollViewerHorizontalScrollAttachedProperty));

        public static bool GetEnableMouseWheelScroll(ScrollViewer element) => element.GetValue(EnableMouseWheelScrollProperty);
        public static void SetEnableMouseWheelScroll(ScrollViewer element, bool value) => element.SetValue(EnableMouseWheelScrollProperty, value);
    }
}
