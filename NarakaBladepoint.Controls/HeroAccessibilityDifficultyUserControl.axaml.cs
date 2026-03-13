using Avalonia;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace NarakaBladepoint.Controls
{
    public partial class HeroAccessibilityDifficultyUserControl : UserControl
    {
        public HeroAccessibilityDifficultyUserControl()
        {
            InitializeComponent();
            UpdateStars();
        }

        public static readonly StyledProperty<double> NumberProperty =
            AvaloniaProperty.Register<HeroAccessibilityDifficultyUserControl, double>(nameof(Number), 1d,
                defaultBindingMode: Avalonia.Data.BindingMode.TwoWay);

        public double Number
        {
            get => GetValue(NumberProperty);
            set => SetValue(NumberProperty, value);
        }

        protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
        {
            base.OnPropertyChanged(change);
            if (change.Property == NumberProperty)
                UpdateStars();
        }

        private void UpdateStars()
        {
            var stars = new[] { Star1, Star2, Star3, Star4, Star5 };
            if (stars[0] == null) return;

            double num = Number;
            for (int i = 0; i < 5; i++)
            {
                double threshold = i + 1;
                double halfThreshold = i + 0.5;

                if (num >= threshold)
                    SetStarImage(stars[i], "2.png"); // full star
                else if (num >= halfThreshold)
                    SetStarImage(stars[i], "3.png"); // half star
                else
                    SetStarImage(stars[i], "1.png"); // empty star
            }
        }

        private static void SetStarImage(Image? img, string fileName)
        {
            if (img == null) return;
            try
            {
                var uri = new Uri($"avares://NarakaBladepoint.Resources/Image/Hero/CustomControls/{fileName}");
                using var stream = AssetLoader.Open(uri);
                img.Source = new Bitmap(stream);
            }
            catch { }
        }
    }
}
