using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace NarakaBladepoint.Controls
{
    public partial class RewardItemsControl : UserControl
    {
        public static readonly StyledProperty<IEnumerable<RewardViewModel>?> ItemsSourceProperty =
            AvaloniaProperty.Register<RewardItemsControl, IEnumerable<RewardViewModel>?>(nameof(ItemsSource));

        public IEnumerable<RewardViewModel>? ItemsSource
        {
            get => GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        public static readonly StyledProperty<int> ProgressbarValueProperty =
            AvaloniaProperty.Register<RewardItemsControl, int>(nameof(ProgressbarValue), 0);

        public int ProgressbarValue
        {
            get => GetValue(ProgressbarValueProperty);
            set => SetValue(ProgressbarValueProperty, value);
        }

        public static readonly StyledProperty<int> ProgressbarMaximumProperty =
            AvaloniaProperty.Register<RewardItemsControl, int>(nameof(ProgressbarMaximum), 0);

        public int ProgressbarMaximum
        {
            get => GetValue(ProgressbarMaximumProperty);
            set => SetValue(ProgressbarMaximumProperty, value);
        }

        public static readonly StyledProperty<double> ImageWidthProperty =
            AvaloniaProperty.Register<RewardItemsControl, double>(nameof(ImageWidth), 60.0);

        public double ImageWidth
        {
            get => GetValue(ImageWidthProperty);
            set => SetValue(ImageWidthProperty, value);
        }

        public static readonly StyledProperty<double> ImageHeightProperty =
            AvaloniaProperty.Register<RewardItemsControl, double>(nameof(ImageHeight), 60.0);

        public double ImageHeight
        {
            get => GetValue(ImageHeightProperty);
            set => SetValue(ImageHeightProperty, value);
        }

        public static readonly StyledProperty<IBrush> CountTextForegroundProperty =
            AvaloniaProperty.Register<RewardItemsControl, IBrush>(nameof(CountTextForeground), Brushes.White);

        public IBrush CountTextForeground
        {
            get => GetValue(CountTextForegroundProperty);
            set => SetValue(CountTextForegroundProperty, value);
        }

        public static readonly StyledProperty<double> CountTextFontSizeProperty =
            AvaloniaProperty.Register<RewardItemsControl, double>(nameof(CountTextFontSize), 12.0);

        public double CountTextFontSize
        {
            get => GetValue(CountTextFontSizeProperty);
            set => SetValue(CountTextFontSizeProperty, value);
        }

        public static readonly StyledProperty<IBrush> ValueTextForegroundProperty =
            AvaloniaProperty.Register<RewardItemsControl, IBrush>(nameof(ValueTextForeground), Brushes.White);

        public IBrush ValueTextForeground
        {
            get => GetValue(ValueTextForegroundProperty);
            set => SetValue(ValueTextForegroundProperty, value);
        }

        public static readonly StyledProperty<string> CountUnitTextProperty =
            AvaloniaProperty.Register<RewardItemsControl, string>(nameof(CountUnitText), "件");

        public string CountUnitText
        {
            get => GetValue(CountUnitTextProperty);
            set => SetValue(CountUnitTextProperty, value);
        }

        public RewardItemsControl()
        {
            InitializeComponent();
        }
    }

    public class RewardViewModel
    {
        public IImage? ImageSource { get; set; }
        public int Value { get; set; }
        public int Count { get; set; }
    }
}
