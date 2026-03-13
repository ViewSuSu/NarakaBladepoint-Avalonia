using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;

namespace NarakaBladepoint.Controls
{
    public partial class HeroRadarUserControl : UserControl
    {
        public HeroRadarUserControl()
        {
            InitializeComponent();
            UpdateRadar();
        }

        public static readonly StyledProperty<int> SurvivalProperty =
            AvaloniaProperty.Register<HeroRadarUserControl, int>(nameof(Survival), 1,
                defaultBindingMode: Avalonia.Data.BindingMode.TwoWay);

        public int Survival
        {
            get => GetValue(SurvivalProperty);
            set => SetValue(SurvivalProperty, value);
        }

        public static readonly StyledProperty<int> ControlProperty =
            AvaloniaProperty.Register<HeroRadarUserControl, int>(nameof(Control), 1,
                defaultBindingMode: Avalonia.Data.BindingMode.TwoWay);

        public int Control
        {
            get => GetValue(ControlProperty);
            set => SetValue(ControlProperty, value);
        }

        public static readonly StyledProperty<int> MobilityProperty =
            AvaloniaProperty.Register<HeroRadarUserControl, int>(nameof(Mobility), 1,
                defaultBindingMode: Avalonia.Data.BindingMode.TwoWay);

        public int Mobility
        {
            get => GetValue(MobilityProperty);
            set => SetValue(MobilityProperty, value);
        }

        public static readonly StyledProperty<int> DamageProperty =
            AvaloniaProperty.Register<HeroRadarUserControl, int>(nameof(Damage), 1,
                defaultBindingMode: Avalonia.Data.BindingMode.TwoWay);

        public int Damage
        {
            get => GetValue(DamageProperty);
            set => SetValue(DamageProperty, value);
        }

        public static readonly StyledProperty<int> SupportProperty =
            AvaloniaProperty.Register<HeroRadarUserControl, int>(nameof(Support), 1,
                defaultBindingMode: Avalonia.Data.BindingMode.TwoWay);

        public int Support
        {
            get => GetValue(SupportProperty);
            set => SetValue(SupportProperty, value);
        }

        protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
        {
            base.OnPropertyChanged(change);
            if (change.Property == SurvivalProperty || change.Property == ControlProperty ||
                change.Property == MobilityProperty || change.Property == DamageProperty ||
                change.Property == SupportProperty)
            {
                UpdateRadar();
            }
        }

        private readonly Point[] MaxPoints =
        {
            new(130, 30),
            new(215, 85),
            new(185, 190),
            new(75, 190),
            new(45, 85),
        };

        private const double CenterX = 130;
        private const double CenterY = 130;

        private void UpdateRadar()
        {
            if (DataPolygon == null) return;
            int[] values = { Survival, Control, Mobility, Damage, Support };
            var points = new Points();

            for (int i = 0; i < 5; i++)
            {
                double rate = Math.Clamp(values[i], 1, 4) / 4.0;
                var p = Lerp(MaxPoints[i], rate);
                points.Add(p);
                SetPoint(i, p);
                SetTextColor(i, values[i]);
            }

            DataPolygon.Points = points;
        }

        private Point Lerp(Point max, double rate)
        {
            return new Point(
                CenterX + (max.X - CenterX) * rate,
                CenterY + (max.Y - CenterY) * rate
            );
        }

        private void SetPoint(int i, Point p)
        {
            var elements = new Avalonia.Controls.Control?[] { P1, P2, P3, P4, P5 };
            if (i < elements.Length && elements[i] != null)
            {
                Canvas.SetLeft(elements[i]!, p.X - 4);
                Canvas.SetTop(elements[i]!, p.Y - 4);
            }
        }

        private void SetTextColor(int i, int value)
        {
            var texts = new TextBlock?[] { T1, T2, T3, T4, T5 };
            if (i < texts.Length && texts[i] != null)
            {
                texts[i]!.Foreground = value >= 3 ? Brushes.White : Brushes.Gray;
            }
        }
    }
}
