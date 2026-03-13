using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Threading;
using System.Windows.Input;

namespace NarakaBladepoint.App.Shell.Behaviors
{
    public class EscCommandBehavior
    {
        public static readonly AttachedProperty<ICommand?> CommandProperty =
            AvaloniaProperty.RegisterAttached<EscCommandBehavior, Window, ICommand?>("Command");

        public static readonly AttachedProperty<object?> CommandParameterProperty =
            AvaloniaProperty.RegisterAttached<EscCommandBehavior, Window, object?>("CommandParameter");

        public static ICommand? GetCommand(Window obj) => obj.GetValue(CommandProperty);
        public static void SetCommand(Window obj, ICommand? value) => obj.SetValue(CommandProperty, value);
        public static object? GetCommandParameter(Window obj) => obj.GetValue(CommandParameterProperty);
        public static void SetCommandParameter(Window obj, object? value) => obj.SetValue(CommandParameterProperty, value);

        static EscCommandBehavior()
        {
            CommandProperty.Changed.AddClassHandler<Window>(OnCommandChanged);
        }

        private static void OnCommandChanged(Window window, AvaloniaPropertyChangedEventArgs e)
        {
            if (e.NewValue != null)
            {
                window.KeyDown -= OnKeyDown;
                window.KeyDown += OnKeyDown;
            }
            else
            {
                window.KeyDown -= OnKeyDown;
            }
        }

        private static void OnKeyDown(object? sender, KeyEventArgs e)
        {
            if (sender is Window window && e.Key == Key.Escape)
            {
                var command = GetCommand(window);
                var parameter = GetCommandParameter(window);
                if (command?.CanExecute(parameter) == true)
                {
                    command.Execute(parameter);
                    e.Handled = true;
                }
            }
        }
    }
}
