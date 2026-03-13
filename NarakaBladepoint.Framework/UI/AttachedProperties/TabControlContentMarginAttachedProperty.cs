using Avalonia;
using Avalonia.Controls;

namespace NarakaBladepoint.Framework.UI.AttachedProperties
{
    public static class TabControlContentMarginAttachedProperty
    {
        public static readonly AttachedProperty<Thickness> ContentMarginProperty =
            AvaloniaProperty.RegisterAttached<TabControl, Thickness>("ContentMargin", typeof(TabControlContentMarginAttachedProperty));

        public static Thickness GetContentMargin(TabControl element) => element.GetValue(ContentMarginProperty);
        public static void SetContentMargin(TabControl element, Thickness value) => element.SetValue(ContentMarginProperty, value);

        public static readonly AttachedProperty<bool> IsAutoAdjustContentMarginProperty =
            AvaloniaProperty.RegisterAttached<TabControl, bool>("IsAutoAdjustContentMargin", typeof(TabControlContentMarginAttachedProperty));

        public static bool GetIsAutoAdjustContentMargin(TabControl element) => element.GetValue(IsAutoAdjustContentMarginProperty);
        public static void SetIsAutoAdjustContentMargin(TabControl element, bool value) => element.SetValue(IsAutoAdjustContentMarginProperty, value);
    }
}
