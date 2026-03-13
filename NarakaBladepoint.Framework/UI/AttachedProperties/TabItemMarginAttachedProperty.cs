using Avalonia;
using Avalonia.Controls;

namespace NarakaBladepoint.Framework.UI.AttachedProperties
{
    public static class TabItemMarginAttachedProperty
    {
        public static readonly AttachedProperty<Thickness> ItemMarginProperty =
            AvaloniaProperty.RegisterAttached<Control, Thickness>("ItemMargin", typeof(TabItemMarginAttachedProperty));

        public static Thickness GetItemMargin(Control element) => element.GetValue(ItemMarginProperty);
        public static void SetItemMargin(Control element, Thickness value) => element.SetValue(ItemMarginProperty, value);
    }
}
