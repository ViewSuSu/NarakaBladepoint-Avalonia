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
    public class QueueAnimationBehavior
    {
        public static readonly AttachedProperty<bool> IsEnabledProperty =
            AvaloniaProperty.RegisterAttached<QueueAnimationBehavior, Control, bool>("IsEnabled", false);

        public static readonly AttachedProperty<string> IsQueuingPropertyNameProperty =
            AvaloniaProperty.RegisterAttached<QueueAnimationBehavior, Control, string>("IsQueuingPropertyName", "IsQueuing");

        public static readonly AttachedProperty<string> QueueBorderNameProperty =
            AvaloniaProperty.RegisterAttached<QueueAnimationBehavior, Control, string>("QueueBorderName", "queueBorder");

        public static bool GetIsEnabled(Control obj) => obj.GetValue(IsEnabledProperty);
        public static void SetIsEnabled(Control obj, bool value) => obj.SetValue(IsEnabledProperty, value);
        public static string GetIsQueuingPropertyName(Control obj) => obj.GetValue(IsQueuingPropertyNameProperty);
        public static void SetIsQueuingPropertyName(Control obj, string value) => obj.SetValue(IsQueuingPropertyNameProperty, value);
        public static string GetQueueBorderName(Control obj) => obj.GetValue(QueueBorderNameProperty);
        public static void SetQueueBorderName(Control obj, string value) => obj.SetValue(QueueBorderNameProperty, value);

        private static System.Timers.Timer? _queueTimer;
        private static INotifyPropertyChanged? _viewModel;

        static QueueAnimationBehavior()
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
            _viewModel = vm;
            if (vm != null)
            {
                var propName = GetIsQueuingPropertyName(control);
                vm.PropertyChanged += (s, args) =>
                {
                    if (args.PropertyName == propName)
                        Dispatcher.UIThread.Post(() => TriggerAnimation(control));
                };
            }
        }

        private static async void TriggerAnimation(Control control)
        {
            var borderName = GetQueueBorderName(control);
            var window = control as Window ?? control.FindAncestorOfType<Window>();
            if (window == null) return;

            var queueGrid = window.FindControl<Control>("queue");
            var queueBorder = window.FindControl<Control>(borderName);
            if (queueBorder == null) return;

            var isQueuing = false;
            if (_viewModel != null)
            {
                var prop = _viewModel.GetType().GetProperty(GetIsQueuingPropertyName(control));
                if (prop != null)
                    isQueuing = (bool)(prop.GetValue(_viewModel) ?? false);
            }

            if (isQueuing)
            {
                if (queueGrid != null) queueGrid.IsVisible = true;
                queueBorder.Opacity = 0;
                queueBorder.RenderTransform = new TranslateTransform(0, 100);

                var showAnim = new Animation
                {
                    Duration = TimeSpan.FromSeconds(0.3),
                    Easing = new ExponentialEaseOut(),
                    Children =
                    {
                        new KeyFrame { Cue = new Cue(0), Setters = { new Setter(Visual.OpacityProperty, 0.0), new Setter(TranslateTransform.YProperty, 100.0) } },
                        new KeyFrame { Cue = new Cue(1), Setters = { new Setter(Visual.OpacityProperty, 1.0), new Setter(TranslateTransform.YProperty, 0.0) } }
                    }
                };
                await showAnim.RunAsync(queueBorder);
                StartQueueTimer();
            }
            else
            {
                var hideAnim = new Animation
                {
                    Duration = TimeSpan.FromSeconds(0.3),
                    Easing = new ExponentialEaseIn(),
                    Children =
                    {
                        new KeyFrame { Cue = new Cue(0), Setters = { new Setter(Visual.OpacityProperty, 1.0), new Setter(TranslateTransform.YProperty, 0.0) } },
                        new KeyFrame { Cue = new Cue(1), Setters = { new Setter(Visual.OpacityProperty, 0.0), new Setter(TranslateTransform.YProperty, 100.0) } }
                    }
                };
                await hideAnim.RunAsync(queueBorder);
                if (queueGrid != null) queueGrid.IsVisible = false;
                StopQueueTimer();
            }
        }

        private static void StartQueueTimer()
        {
            if (_viewModel == null) return;
            var queueTimeProperty = _viewModel.GetType().GetProperty("QueueTime");
            if (queueTimeProperty == null) return;
            queueTimeProperty.SetValue(_viewModel, 0);

            _queueTimer?.Stop();
            _queueTimer?.Dispose();
            _queueTimer = new System.Timers.Timer(1000);
            _queueTimer.Elapsed += (s, e) =>
            {
                if (_viewModel != null && queueTimeProperty != null)
                {
                    var currentValue = (int)(queueTimeProperty.GetValue(_viewModel) ?? 0);
                    queueTimeProperty.SetValue(_viewModel, currentValue + 1);
                }
            };
            _queueTimer.AutoReset = true;
            _queueTimer.Start();
        }

        private static void StopQueueTimer()
        {
            _queueTimer?.Stop();
            _queueTimer?.Dispose();
            _queueTimer = null;
            if (_viewModel != null)
            {
                var queueTimeProperty = _viewModel.GetType().GetProperty("QueueTime");
                queueTimeProperty?.SetValue(_viewModel, 0);
            }
        }
    }
}
