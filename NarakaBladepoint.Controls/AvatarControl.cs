using Avalonia;
using Avalonia.Controls.Primitives;
using Avalonia.Media;

namespace NarakaBladepoint.Controls
{
    public class AvatarControl : TemplatedControl
    {
        public static readonly StyledProperty<IImage?> BackgroundImageProperty =
            AvaloniaProperty.Register<AvatarControl, IImage?>(nameof(BackgroundImage));

        public IImage? BackgroundImage
        {
            get => GetValue(BackgroundImageProperty);
            set => SetValue(BackgroundImageProperty, value);
        }

        public static readonly StyledProperty<int> ValueProperty =
            AvaloniaProperty.Register<AvatarControl, int>(nameof(Value), 0, defaultBindingMode: Avalonia.Data.BindingMode.TwoWay);

        public int Value
        {
            get => GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public static readonly StyledProperty<Stretch> ImageStretchProperty =
            AvaloniaProperty.Register<AvatarControl, Stretch>(nameof(ImageStretch), Stretch.UniformToFill);

        public Stretch ImageStretch
        {
            get => GetValue(ImageStretchProperty);
            set => SetValue(ImageStretchProperty, value);
        }

        public static readonly StyledProperty<double> CornerLengthProperty =
            AvaloniaProperty.Register<AvatarControl, double>(nameof(CornerLength), 18.0);

        public double CornerLength
        {
            get => GetValue(CornerLengthProperty);
            set => SetValue(CornerLengthProperty, value);
        }

        public static readonly StyledProperty<double> CornerThicknessProperty =
            AvaloniaProperty.Register<AvatarControl, double>(nameof(CornerThickness), 3.0);

        public double CornerThickness
        {
            get => GetValue(CornerThicknessProperty);
            set => SetValue(CornerThicknessProperty, value);
        }
    }
}
