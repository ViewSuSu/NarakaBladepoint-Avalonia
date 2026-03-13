using Avalonia;
using Avalonia.Controls.Primitives;
using Avalonia.Layout;
using Avalonia.Media;
using System.Windows.Input;

namespace NarakaBladepoint.Controls
{
    public class IconTextBlockCustomControl : TemplatedControl
    {
        public static readonly StyledProperty<IImage?> IconProperty =
            AvaloniaProperty.Register<IconTextBlockCustomControl, IImage?>(nameof(Icon));

        public IImage? Icon
        {
            get => GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        public static readonly StyledProperty<string> TextProperty =
            AvaloniaProperty.Register<IconTextBlockCustomControl, string>(nameof(Text), string.Empty);

        public string Text
        {
            get => GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public static readonly StyledProperty<ICommand?> CommandProperty =
            AvaloniaProperty.Register<IconTextBlockCustomControl, ICommand?>(nameof(Command));

        public ICommand? Command
        {
            get => GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public static readonly StyledProperty<double> IconWidthProperty =
            AvaloniaProperty.Register<IconTextBlockCustomControl, double>(nameof(IconWidth), 30.0);

        public double IconWidth
        {
            get => GetValue(IconWidthProperty);
            set => SetValue(IconWidthProperty, value);
        }

        public static readonly StyledProperty<double> IconHeightProperty =
            AvaloniaProperty.Register<IconTextBlockCustomControl, double>(nameof(IconHeight), 30.0);

        public double IconHeight
        {
            get => GetValue(IconHeightProperty);
            set => SetValue(IconHeightProperty, value);
        }

        public static readonly StyledProperty<Stretch> IconStretchProperty =
            AvaloniaProperty.Register<IconTextBlockCustomControl, Stretch>(nameof(IconStretch), Stretch.Uniform);

        public Stretch IconStretch
        {
            get => GetValue(IconStretchProperty);
            set => SetValue(IconStretchProperty, value);
        }

        public static readonly StyledProperty<double> TextFontSizeProperty =
            AvaloniaProperty.Register<IconTextBlockCustomControl, double>(nameof(TextFontSize), 10.0);

        public double TextFontSize
        {
            get => GetValue(TextFontSizeProperty);
            set => SetValue(TextFontSizeProperty, value);
        }

        public static readonly StyledProperty<IBrush> TextForegroundProperty =
            AvaloniaProperty.Register<IconTextBlockCustomControl, IBrush>(nameof(TextForeground), Brushes.White);

        public IBrush TextForeground
        {
            get => GetValue(TextForegroundProperty);
            set => SetValue(TextForegroundProperty, value);
        }

        public static readonly StyledProperty<double> SpacingProperty =
            AvaloniaProperty.Register<IconTextBlockCustomControl, double>(nameof(Spacing), 0.0);

        public double Spacing
        {
            get => GetValue(SpacingProperty);
            set => SetValue(SpacingProperty, value);
        }

        public static readonly StyledProperty<Thickness> TextMarginProperty =
            AvaloniaProperty.Register<IconTextBlockCustomControl, Thickness>(nameof(TextMargin), new Thickness(0));

        public Thickness TextMargin
        {
            get => GetValue(TextMarginProperty);
            set => SetValue(TextMarginProperty, value);
        }

        public static readonly StyledProperty<HorizontalAlignment> HorizontalContentAlignmentProperty =
            AvaloniaProperty.Register<IconTextBlockCustomControl, HorizontalAlignment>(nameof(HorizontalContentAlignment), HorizontalAlignment.Center);

        public HorizontalAlignment HorizontalContentAlignment
        {
            get => GetValue(HorizontalContentAlignmentProperty);
            set => SetValue(HorizontalContentAlignmentProperty, value);
        }

        public static readonly StyledProperty<VerticalAlignment> VerticalContentAlignmentProperty =
            AvaloniaProperty.Register<IconTextBlockCustomControl, VerticalAlignment>(nameof(VerticalContentAlignment), VerticalAlignment.Center);

        public VerticalAlignment VerticalContentAlignment
        {
            get => GetValue(VerticalContentAlignmentProperty);
            set => SetValue(VerticalContentAlignmentProperty, value);
        }

        protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
        {
            base.OnPropertyChanged(change);
            if (change.Property == SpacingProperty)
            {
                TextMargin = new Thickness(0, (double)change.NewValue!, 0, 0);
            }
        }
    }
}
