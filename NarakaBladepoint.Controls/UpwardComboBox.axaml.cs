using System.Collections;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Templates;
using Avalonia.Input;
using Avalonia.Interactivity;

namespace NarakaBladepoint.Controls
{
    public partial class UpwardComboBox : UserControl
    {
        public static readonly StyledProperty<IEnumerable?> ItemsSourceProperty =
            AvaloniaProperty.Register<UpwardComboBox, IEnumerable?>(nameof(ItemsSource));

        public IEnumerable? ItemsSource
        {
            get => GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        public static readonly StyledProperty<object?> SelectedItemProperty =
            AvaloniaProperty.Register<UpwardComboBox, object?>(nameof(SelectedItem));

        public object? SelectedItem
        {
            get => GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }

        public static readonly StyledProperty<IDataTemplate?> ItemTemplateProperty =
            AvaloniaProperty.Register<UpwardComboBox, IDataTemplate?>(nameof(ItemTemplate));

        public IDataTemplate? ItemTemplate
        {
            get => GetValue(ItemTemplateProperty);
            set => SetValue(ItemTemplateProperty, value);
        }

        public UpwardComboBox()
        {
            InitializeComponent();
        }

        private void DisplayBorder_PointerPressed(object? sender, PointerPressedEventArgs e)
        {
            if (PART_Popup != null)
                PART_Popup.IsOpen = !PART_Popup.IsOpen;

            if (ArrowCollapsed != null && ArrowExpanded != null)
            {
                ArrowCollapsed.IsVisible = !PART_Popup?.IsOpen ?? true;
                ArrowExpanded.IsVisible = PART_Popup?.IsOpen ?? false;
            }
        }
    }
}
