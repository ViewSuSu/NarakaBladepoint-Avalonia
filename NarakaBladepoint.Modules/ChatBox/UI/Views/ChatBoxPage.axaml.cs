using Avalonia;
using Avalonia.Animation;
using Avalonia.Animation.Easings;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Styling;
using Avalonia.Threading;

namespace NarakaBladepoint.Modules.ChatBox.UI.Views
{
    public partial class ChatBoxPage : UserControlBase
    {
        private CancellationTokenSource _activityCts;
        private Task _activityMonitorTask;
        private DateTime _lastActivityTime;
        private bool _isFadingOut = false;
        private readonly object _activityLock = new object();

        private const double FadeOutDuration = 1.5;
        private const double InactivityTimeout = 3.0;
        private const int CheckInterval = 100;

        public ChatBoxPage()
        {
            InitializeComponent();
            SetupEventHandlers();
        }

        protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
        {
            base.OnPropertyChanged(change);

            if (change.Property == IsVisibleProperty)
            {
                if (change.NewValue is bool isVisible)
                {
                    if (isVisible)
                    {
                        inputTextBox?.Focus();
                        RecordActivity();
                        StartActivityMonitor();
                    }
                    else
                    {
                        StopActivityMonitor();
                    }
                }
            }
        }

        private void SetupEventHandlers()
        {
            if (inputTextBox != null)
            {
                inputTextBox.GotFocus += OnAnyActivity;
                inputTextBox.LostFocus += OnAnyActivity;
                inputTextBox.KeyDown += OnAnyActivity;
                inputTextBox.PointerPressed += OnAnyActivity;
                inputTextBox.PointerEntered += OnAnyActivity;
                inputTextBox.PointerExited += OnAnyActivity;
            }

            if (listbox != null)
            {
                listbox.PointerEntered += OnAnyActivity;
                listbox.PointerExited += OnAnyActivity;
                listbox.PointerWheelChanged += OnAnyActivity;
                listbox.PointerPressed += OnAnyActivity;
            }
        }

        #region Activity Monitor

        private void StartActivityMonitor()
        {
            StopActivityMonitor();

            _activityCts = new CancellationTokenSource();
            _activityMonitorTask = Task.Run(
                async () =>
                {
                    try
                    {
                        while (!_activityCts.Token.IsCancellationRequested)
                        {
                            await Task.Delay(CheckInterval, _activityCts.Token);
                            CheckForInactivity();
                        }
                    }
                    catch (TaskCanceledException)
                    {
                    }
                },
                _activityCts.Token
            );
        }

        private void StopActivityMonitor()
        {
            _activityCts?.Cancel();
            _activityMonitorTask = null;
            _activityCts = null;
        }

        private void RecordActivity()
        {
            lock (_activityLock)
            {
                _lastActivityTime = DateTime.Now;
            }

            CheckForRecovery();
        }

        private void CheckForInactivity()
        {
            Dispatcher.UIThread.Post(CheckForInactivityCore);
        }

        private void CheckForInactivityCore()
        {
            if (!this.IsVisible
                || (inputTextBox != null && inputTextBox.IsFocused)
                || (inputTextBox != null && inputTextBox.IsPointerOver)
                || (listbox != null && listbox.IsPointerOver))
                return;

            double inactiveSeconds;
            lock (_activityLock)
            {
                inactiveSeconds = (DateTime.Now - _lastActivityTime).TotalSeconds;
            }

            if (inactiveSeconds >= InactivityTimeout && !_isFadingOut)
            {
                StartFadeOutAnimation();
            }
        }

        private void CheckForRecovery()
        {
            Dispatcher.UIThread.Post(CheckForRecoveryCore);
        }

        private void CheckForRecoveryCore()
        {
            if (_isFadingOut || (listbox != null && listbox.Opacity < 1.0))
            {
                StopFadeOut();
            }
        }

        #endregion

        #region Animations

        private void OnAnyActivity(object? sender, EventArgs e)
        {
            RecordActivity();
        }

        private async void StartFadeOutAnimation()
        {
            if (_isFadingOut || listbox == null)
                return;

            _isFadingOut = true;

            var animation = new Avalonia.Animation.Animation
            {
                Duration = TimeSpan.FromSeconds(FadeOutDuration),
                Easing = new CubicEaseOut(),
                FillMode = FillMode.Forward,
                Children =
                {
                    new KeyFrame { Cue = new Cue(0.0), Setters = { new Setter(OpacityProperty, 1.0) } },
                    new KeyFrame { Cue = new Cue(1.0), Setters = { new Setter(OpacityProperty, 0.3) } }
                }
            };

            await animation.RunAsync(listbox);
            _isFadingOut = false;
        }

        private async void StopFadeOut()
        {
            _isFadingOut = false;
            if (listbox == null) return;

            var animation = new Avalonia.Animation.Animation
            {
                Duration = TimeSpan.FromSeconds(0.3),
                Easing = new CubicEaseOut(),
                FillMode = FillMode.Forward,
                Children =
                {
                    new KeyFrame { Cue = new Cue(0.0), Setters = { new Setter(OpacityProperty, listbox.Opacity) } },
                    new KeyFrame { Cue = new Cue(1.0), Setters = { new Setter(OpacityProperty, 1.0) } }
                }
            };

            await animation.RunAsync(listbox);
        }

        public void ActivateChatBox()
        {
            RecordActivity();
            StopFadeOut();
        }

        #endregion

        private void CleanupResources()
        {
            StopActivityMonitor();
        }

        private void OnUserControlUnloaded(object? sender, RoutedEventArgs e)
        {
            CleanupResources();
        }
    }
}
