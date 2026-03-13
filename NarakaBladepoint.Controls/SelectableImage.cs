using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace NarakaBladepoint.Controls
{
    public class HeroTagSelectableImage : Image
    {
        public static readonly StyledProperty<bool> IsSelectedProperty =
            AvaloniaProperty.Register<HeroTagSelectableImage, bool>(nameof(IsSelected), false);

        public bool IsSelected
        {
            get => GetValue(IsSelectedProperty);
            set => SetValue(IsSelectedProperty, value);
        }

        public HeroTagSelectableImage()
        {
            UpdateSource();
        }

        protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
        {
            base.OnPropertyChanged(change);
            if (change.Property == IsSelectedProperty)
                UpdateSource();
        }

        private void UpdateSource()
        {
            try
            {
                string resourcePath = IsSelected
                    ? "avares://NarakaBladepoint.Resources/Image/CustomControls/2.png"
                    : "avares://NarakaBladepoint.Resources/Image/CustomControls/1.png";
                using var stream = AssetLoader.Open(new Uri(resourcePath));
                Source = new Bitmap(stream);
            }
            catch { }
        }
    }
}
