using System.ComponentModel;
using Avalonia;
using Avalonia.Animation;
using Avalonia.Animation.Easings;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Styling;
using Avalonia.Threading;
using Avalonia.VisualTree;

namespace NarakaBladepoint.App.Shell.Behaviors
{
    public class TipMessageAnimationBehavior
    {
        public static readonly AttachedProperty<string> TipMessagePropertyNameProperty =
            AvaloniaProperty.RegisterAttached<TipMessageAnimationBehavior, Control, string>("TipMessagePropertyName", "TipMessage");

        public static readonly AttachedProperty<string> TipBorderNameProperty =
            AvaloniaProperty.RegisterAttached<TipMessageAnimationBehavior, Control, string>("TipBorderName", "tipBorder");

        public static readonly AttachedProperty<string> TipTextblockNameProperty =
            AvaloniaProperty.RegisterAttached<TipMessageAnimationBehavior, Control, string>("TipTextblockName", "tipTextblock");

        public static readonly AttachedProperty<bool> IsEnabledProperty =
            AvaloniaProperty.RegisterAttached<TipMessageAnimationBehavior, Control, bool>("IsEnabled", false);

        public static string GetTipMessagePropertyName(Control obj) => obj.GetValue(TipMessagePropertyNameProperty);
        public static void SetTipMessagePropertyName(Control obj, string value) => obj.SetValue(TipMessagePropertyNameProperty, value);
        public static string GetTipBorderName(Control obj) => obj.GetValue(TipBorderNameProperty);
        public static void SetTipBorderName(Control obj, string value) => obj.SetValue(TipBorderNameProperty, value);
        public static string GetTipTextblockName(Control obj) => obj.GetValue(TipTextblockNameProperty);
        public static void SetTipTextblockName(Control obj, string value) => obj.SetValue(TipTextblockNameProperty, value);
        public static bool GetIsEnabled(Control obj) => obj.GetValue(IsEnabledProperty);
        public static void SetIsEnabled(Control obj, bool value) => obj.SetValue(IsEnabledProperty, value);

        static TipMessageAnimationBehavior()
        {
            IsEnabledProperty.Changed.AddClassHandler<Control>(OnIsEnabledChanged);
        }

        private static void OnIsEnabledChanged(Control control, AvaloniaPropertyChangedEventArgs e)
        {
            if (e.NewValue is true)
            {
                control.DataContextChanged += OnDataContextChanged;
                SubscribeViewModel(control, control.DataContext as INotifyPropertyChanged);
            }
            else
            {
                control.DataContextChanged -= OnDataContextChanged;
            }
        }

        private static void OnDataContextChanged(object? sender, EventArgs e)
        {
            if (sender is Control control)
                SubscribeViewModel(control, control.DataContext as INotifyPropertyChanged);
        }

        private static void SubscribeViewModel(Control control, INotifyPropertyChanged? vm)
        {
            if (vm != null)
            {
                var propName = GetTipMessagePropertyName(control);
                vm.PropertyChanged += (s, args) =>
                {
                    if (args.PropertyName == propName)
                        Dispatcher.UIThread.Post(() => TriggerAnimation(control));
                };
            }
        }

        private static async void TriggerAnimation(Control control)
        {
            var tipBorderName = GetTipBorderName(control);
            var window = control as Window ?? (control as Control)?.FindAncestorOfType<Window>();
            if (window == null) return;

            var tipGrid = window.FindControl<Control>("tipGrid");
            var tipBorder = window.FindControl<Control>(tipBorderName);
            if (tipBorder == null) return;

            if (tipGrid != null) tipGrid.IsVisible = true;
            tipBorder.Opacity = 0;
            tipBorder.RenderTransform = new TranslateTransform(0, 100);

            // Phase 1: Slide up + fade in
            var slideUp = new Animation
            {
                Duration = TimeSpan.FromSeconds(0.5),
                Easing = new ExponentialEaseOut(),
                Children =
                {
                    new KeyFrame { Cue = new Cue(0), Setters = { new Setter(Visual.OpacityProperty, 0.0), new Setter(TranslateTransform.YProperty, 100.0) } },
                    new KeyFrame { Cue = new Cue(1), Setters = { new Setter(Visual.OpacityProperty, 1.0), new Setter(TranslateTransform.YProperty, 0.0) } }
                }
            };
            await slideUp.RunAsync(tipBorder);

            // Phase 2: Display
            await Task.Delay(2000);

            // Phase 3: Slide away + fade out
            var slideAway = new Animation
            {
                Duration = TimeSpan.FromSeconds(0.5),
                Easing = new ExponentialEaseIn(),
                Children =
                {
                    new KeyFrame { Cue = new Cue(0), Setters = { new Setter(Visual.OpacityProperty, 1.0), new Setter(TranslateTransform.YProperty, 0.0) } },
                    new KeyFrame { Cue = new Cue(1), Setters = { new Setter(Visual.OpacityProperty, 0.0), new Setter(TranslateTransform.YProperty, -100.0) } }
                }
            };
            await slideAway.RunAsync(tipBorder);

            if (tipGrid != null) tipGrid.IsVisible = false;
        }
    }
}
