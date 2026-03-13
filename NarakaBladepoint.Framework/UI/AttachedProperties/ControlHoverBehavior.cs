using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;

namespace NarakaBladepoint.Framework.UI.AttachedProperties
{
    public static class ControlHoverBehavior
    {
        public static readonly Avalonia.AttachedProperty<bool> IsEnabledProperty =
            AvaloniaProperty.RegisterAttached<Control, bool>("IsEnabled", typeof(ControlHoverBehavior));

        public static bool GetIsEnabled(Control element) => element.GetValue(IsEnabledProperty);
        public static void SetIsEnabled(Control element, bool value) => element.SetValue(IsEnabledProperty, value);
    }
}
