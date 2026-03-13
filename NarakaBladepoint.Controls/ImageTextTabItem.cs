using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Media;

namespace NarakaBladepoint.Controls
{
    public class ImageTextTabItem : TabItem
    {
        public static readonly StyledProperty<Thickness> ContentMarginProperty =
            AvaloniaProperty.Register<ImageTextTabItem, Thickness>(nameof(ContentMargin), new Thickness(0));

        public Thickness ContentMargin
        {
            get => GetValue(ContentMarginProperty);
            set => SetValue(ContentMarginProperty, value);
        }

        public static readonly StyledProperty<HorizontalAlignment> ContentHorizontalAlignmentProperty =
            AvaloniaProperty.Register<ImageTextTabItem, HorizontalAlignment>(nameof(ContentHorizontalAlignment), HorizontalAlignment.Center);

        public HorizontalAlignment ContentHorizontalAlignment
        {
            get => GetValue(ContentHorizontalAlignmentProperty);
            set => SetValue(ContentHorizontalAlignmentProperty, value);
        }

        public static readonly StyledProperty<bool> IsSelectedHilgihtBoderProperty =
            AvaloniaProperty.Register<ImageTextTabItem, bool>(nameof(IsSelectedHilgihtBoder), false);

        public bool IsSelectedHilgihtBoder
        {
            get => GetValue(IsSelectedHilgihtBoderProperty);
            set => SetValue(IsSelectedHilgihtBoderProperty, value);
        }

        public static readonly StyledProperty<bool> IsMouseOverHilightBoderProperty =
            AvaloniaProperty.Register<ImageTextTabItem, bool>(nameof(IsMouseOverHilightBoder), false);

        public bool IsMouseOverHilightBoder
        {
            get => GetValue(IsMouseOverHilightBoderProperty);
            set => SetValue(IsMouseOverHilightBoderProperty, value);
        }

        public static readonly StyledProperty<IImage?> ImageSourceProperty =
            AvaloniaProperty.Register<ImageTextTabItem, IImage?>(nameof(ImageSource));

        public IImage? ImageSource
        {
            get => GetValue(ImageSourceProperty);
            set => SetValue(ImageSourceProperty, value);
        }

        public static readonly StyledProperty<double> ImageWidthProperty =
            AvaloniaProperty.Register<ImageTextTabItem, double>(nameof(ImageWidth), 20.0);

        public double ImageWidth
        {
            get => GetValue(ImageWidthProperty);
            set => SetValue(ImageWidthProperty, value);
        }

        public static readonly StyledProperty<double> ImageHeightProperty =
            AvaloniaProperty.Register<ImageTextTabItem, double>(nameof(ImageHeight), 20.0);

        public double ImageHeight
        {
            get => GetValue(ImageHeightProperty);
            set => SetValue(ImageHeightProperty, value);
        }

        public static readonly StyledProperty<string> TextProperty =
            AvaloniaProperty.Register<ImageTextTabItem, string>(nameof(Text), string.Empty);

        public string Text
        {
            get => GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public static readonly StyledProperty<IBrush> MouseOverTextColorProperty =
            AvaloniaProperty.Register<ImageTextTabItem, IBrush>(nameof(MouseOverTextColor),
                new SolidColorBrush(Color.FromRgb(0xE6, 0xE6, 0xE6)));

        public IBrush MouseOverTextColor
        {
            get => GetValue(MouseOverTextColorProperty);
            set => SetValue(MouseOverTextColorProperty, value);
        }

        public static readonly StyledProperty<IBrush> SelectedBackgroundProperty =
            AvaloniaProperty.Register<ImageTextTabItem, IBrush>(nameof(SelectedBackground), Brushes.Transparent);

        public IBrush SelectedBackground
        {
            get => GetValue(SelectedBackgroundProperty);
            set => SetValue(SelectedBackgroundProperty, value);
        }

        public static readonly StyledProperty<bool> ShowSelectedBorderProperty =
            AvaloniaProperty.Register<ImageTextTabItem, bool>(nameof(ShowSelectedBorder), false);

        public bool ShowSelectedBorder
        {
            get => GetValue(ShowSelectedBorderProperty);
            set => SetValue(ShowSelectedBorderProperty, value);
        }

        public static readonly StyledProperty<bool> ShowMouseOverBorderProperty =
            AvaloniaProperty.Register<ImageTextTabItem, bool>(nameof(ShowMouseOverBorder), false);

        public bool ShowMouseOverBorder
        {
            get => GetValue(ShowMouseOverBorderProperty);
            set => SetValue(ShowMouseOverBorderProperty, value);
        }
    }
}
