using System.Windows.Input;
using Avalonia;
using Avalonia.Controls;

namespace NarakaBladepoint.Framework.UI.AttachedProperties
{
    public static class MouseLeftClickBehavior
    {
        public static readonly Avalonia.AttachedProperty<ICommand?> CommandProperty =
            AvaloniaProperty.RegisterAttached<Control, ICommand?>("Command", typeof(MouseLeftClickBehavior));

        public static ICommand? GetCommand(Control element) => element.GetValue(CommandProperty);
        public static void SetCommand(Control element, ICommand? value) => element.SetValue(CommandProperty, value);

        public static readonly Avalonia.AttachedProperty<object?> CommandParameterProperty =
            AvaloniaProperty.RegisterAttached<Control, object?>("CommandParameter", typeof(MouseLeftClickBehavior));

        public static object? GetCommandParameter(Control element) => element.GetValue(CommandParameterProperty);
        public static void SetCommandParameter(Control element, object? value) => element.SetValue(CommandParameterProperty, value);
    }
}
