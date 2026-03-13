using Avalonia;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using System.Windows.Input;

namespace NarakaBladepoint.Controls
{
    public class EscBackControl : TemplatedControl
    {
        public static readonly StyledProperty<ICommand?> CommandProperty =
            AvaloniaProperty.Register<EscBackControl, ICommand?>(nameof(Command));

        public ICommand? Command
        {
            get => GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public static readonly StyledProperty<object?> CommandParameterProperty =
            AvaloniaProperty.Register<EscBackControl, object?>(nameof(CommandParameter));

        public object? CommandParameter
        {
            get => GetValue(CommandParameterProperty);
            set => SetValue(CommandParameterProperty, value);
        }

        public static readonly StyledProperty<string> EscKeyTextProperty =
            AvaloniaProperty.Register<EscBackControl, string>(nameof(EscKeyText), "Esc");

        public string EscKeyText
        {
            get => GetValue(EscKeyTextProperty);
            set => SetValue(EscKeyTextProperty, value);
        }

        public static readonly StyledProperty<string> BackTextProperty =
            AvaloniaProperty.Register<EscBackControl, string>(nameof(BackText), "返回");

        public string BackText
        {
            get => GetValue(BackTextProperty);
            set => SetValue(BackTextProperty, value);
        }

        public EscBackControl()
        {
            Focusable = true;
        }

        protected override void OnPointerReleased(PointerReleasedEventArgs e)
        {
            base.OnPointerReleased(e);
            if (e.InitialPressMouseButton == MouseButton.Left)
            {
                if (Command?.CanExecute(CommandParameter) == true)
                    Command.Execute(CommandParameter);
            }
        }
    }
}
