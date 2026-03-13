using Avalonia;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using System.Windows.Input;

namespace NarakaBladepoint.Controls
{
    public class CommonFunctionButton : TemplatedControl
    {
        public static readonly StyledProperty<bool> IsSelectedProperty =
            AvaloniaProperty.Register<CommonFunctionButton, bool>(nameof(IsSelected), false,
                defaultBindingMode: Avalonia.Data.BindingMode.TwoWay);

        public bool IsSelected
        {
            get => GetValue(IsSelectedProperty);
            set => SetValue(IsSelectedProperty, value);
        }

        public static readonly StyledProperty<string> ContentProperty =
            AvaloniaProperty.Register<CommonFunctionButton, string>(nameof(Content), string.Empty);

        public string Content
        {
            get => GetValue(ContentProperty);
            set => SetValue(ContentProperty, value);
        }

        public static readonly StyledProperty<ICommand?> CommandProperty =
            AvaloniaProperty.Register<CommonFunctionButton, ICommand?>(nameof(Command));

        public ICommand? Command
        {
            get => GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public static readonly StyledProperty<object?> CommandParameterProperty =
            AvaloniaProperty.Register<CommonFunctionButton, object?>(nameof(CommandParameter));

        public object? CommandParameter
        {
            get => GetValue(CommandParameterProperty);
            set => SetValue(CommandParameterProperty, value);
        }

        protected override void OnPointerReleased(PointerReleasedEventArgs e)
        {
            base.OnPointerReleased(e);
            if (!IsEnabled) return;
            if (e.InitialPressMouseButton == MouseButton.Left)
            {
                if (Command?.CanExecute(CommandParameter) == true)
                    Command.Execute(CommandParameter);
                e.Handled = true;
            }
        }
    }
}
