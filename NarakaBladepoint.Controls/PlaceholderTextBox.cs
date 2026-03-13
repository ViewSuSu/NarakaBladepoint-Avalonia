using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace NarakaBladepoint.Controls
{
    public class PlaceholderTextBox : TextBox
    {
        public static readonly StyledProperty<string> PlaceholderProperty =
            AvaloniaProperty.Register<PlaceholderTextBox, string>(nameof(Placeholder), "请在此输入");

        public static readonly StyledProperty<IBrush> PlaceholderForegroundProperty =
            AvaloniaProperty.Register<PlaceholderTextBox, IBrush>(nameof(PlaceholderForeground),
                new SolidColorBrush(Color.FromRgb(136, 136, 136)));

        public static readonly StyledProperty<Thickness> PlaceholderMarginProperty =
            AvaloniaProperty.Register<PlaceholderTextBox, Thickness>(nameof(PlaceholderMargin), new Thickness(0));

        public string Placeholder
        {
            get => GetValue(PlaceholderProperty);
            set => SetValue(PlaceholderProperty, value);
        }

        public IBrush PlaceholderForeground
        {
            get => GetValue(PlaceholderForegroundProperty);
            set => SetValue(PlaceholderForegroundProperty, value);
        }

        public Thickness PlaceholderMargin
        {
            get => GetValue(PlaceholderMarginProperty);
            set => SetValue(PlaceholderMarginProperty, value);
        }

        public PlaceholderTextBox()
        {
            Watermark = "请在此输入";
        }

        protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
        {
            base.OnPropertyChanged(change);
            if (change.Property == PlaceholderProperty)
            {
                Watermark = Placeholder;
            }
        }
    }
}
