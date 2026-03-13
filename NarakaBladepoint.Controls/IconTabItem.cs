using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace NarakaBladepoint.Controls
{
    public class IconTabItem : TabItem
    {
        public static readonly StyledProperty<IImage?> IconProperty =
            AvaloniaProperty.Register<IconTabItem, IImage?>(nameof(Icon));

        public IImage? Icon
        {
            get => GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        public static readonly StyledProperty<double> IconWidthProperty =
            AvaloniaProperty.Register<IconTabItem, double>(nameof(IconWidth), 30.0);

        public double IconWidth
        {
            get => GetValue(IconWidthProperty);
            set => SetValue(IconWidthProperty, value);
        }

        public static readonly StyledProperty<double> IconHeightProperty =
            AvaloniaProperty.Register<IconTabItem, double>(nameof(IconHeight), 30.0);

        public double IconHeight
        {
            get => GetValue(IconHeightProperty);
            set => SetValue(IconHeightProperty, value);
        }

        public static readonly StyledProperty<double> TextSpacingProperty =
            AvaloniaProperty.Register<IconTabItem, double>(nameof(TextSpacing), 4.0);

        public double TextSpacing
        {
            get => GetValue(TextSpacingProperty);
            set => SetValue(TextSpacingProperty, value);
        }

        public static readonly StyledProperty<double> BackgroundHeightFactorProperty =
            AvaloniaProperty.Register<IconTabItem, double>(nameof(BackgroundHeightFactor), 1.2);

        public double BackgroundHeightFactor
        {
            get => GetValue(BackgroundHeightFactorProperty);
            set => SetValue(BackgroundHeightFactorProperty, value);
        }

        public static readonly StyledProperty<double> HeaderFontSizeProperty =
            AvaloniaProperty.Register<IconTabItem, double>(nameof(HeaderFontSize));

        public double HeaderFontSize
        {
            get => GetValue(HeaderFontSizeProperty);
            set => SetValue(HeaderFontSizeProperty, value);
        }

        public static readonly StyledProperty<IBrush> HeaderForegroundProperty =
            AvaloniaProperty.Register<IconTabItem, IBrush>(nameof(HeaderForeground), Brushes.White);

        public IBrush HeaderForeground
        {
            get => GetValue(HeaderForegroundProperty);
            set => SetValue(HeaderForegroundProperty, value);
        }
    }
}
