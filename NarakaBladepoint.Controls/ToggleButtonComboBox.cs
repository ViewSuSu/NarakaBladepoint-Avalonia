using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace NarakaBladepoint.Controls
{
    public class ToggleButtonComboBox : ComboBox
    {
        public static readonly StyledProperty<IBrush?> HighlightBackgroundProperty =
            AvaloniaProperty.Register<ToggleButtonComboBox, IBrush?>(nameof(HighlightBackground));

        public IBrush? HighlightBackground
        {
            get => GetValue(HighlightBackgroundProperty);
            set => SetValue(HighlightBackgroundProperty, value);
        }
    }

    public class ToggleButtonComboBoxItem : ComboBoxItem
    {
        public ToggleButtonComboBox? ParentComboBox { get; set; }

        public static readonly StyledProperty<bool> IsHighlightedProperty =
            AvaloniaProperty.Register<ToggleButtonComboBoxItem, bool>(nameof(IsHighlighted), true);

        public bool IsHighlighted
        {
            get => GetValue(IsHighlightedProperty);
            set => SetValue(IsHighlightedProperty, value);
        }
    }
}
