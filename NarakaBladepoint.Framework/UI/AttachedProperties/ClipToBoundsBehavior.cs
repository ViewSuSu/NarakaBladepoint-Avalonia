using Avalonia.Controls;

namespace NarakaBladepoint.Framework.UI.AttachedProperties
{
    public static class ClipToBoundsBehavior
    {
        public static readonly Avalonia.AttachedProperty<bool> ClipToBoundsProperty =
            AvaloniaProperty.RegisterAttached<Control, bool>("ClipToBounds", typeof(ClipToBoundsBehavior));

        public static bool GetClipToBounds(Control element) => element.GetValue(ClipToBoundsProperty);
        public static void SetClipToBounds(Control element, bool value) => element.SetValue(ClipToBoundsProperty, value);
    }
}
