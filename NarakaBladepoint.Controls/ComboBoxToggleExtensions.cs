using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace NarakaBladepoint.Controls
{
    public class ComboBoxToggleExtensions
    {
        public static readonly AttachedProperty<int> HighlightIndexProperty =
            AvaloniaProperty.RegisterAttached<ComboBoxToggleExtensions, Control, int>("HighlightIndex", -1);

        public static int GetHighlightIndex(Control obj) => obj.GetValue(HighlightIndexProperty);
        public static void SetHighlightIndex(Control obj, int value) => obj.SetValue(HighlightIndexProperty, value);

        public static readonly AttachedProperty<IBrush> HighlightBackgroundProperty =
            AvaloniaProperty.RegisterAttached<ComboBoxToggleExtensions, Control, IBrush>("HighlightBackground", Brushes.Transparent);

        public static IBrush GetHighlightBackground(Control obj) => obj.GetValue(HighlightBackgroundProperty);
        public static void SetHighlightBackground(Control obj, IBrush value) => obj.SetValue(HighlightBackgroundProperty, value);

        public static readonly AttachedProperty<bool> IsHighlightedProperty =
            AvaloniaProperty.RegisterAttached<ComboBoxToggleExtensions, Control, bool>("IsHighlighted", false);

        public static bool GetIsHighlighted(Control obj) => obj.GetValue(IsHighlightedProperty);
        public static void SetIsHighlighted(Control obj, bool value) => obj.SetValue(IsHighlightedProperty, value);
    }
}
