using Avalonia;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Media;
using System.Windows.Input;

namespace NarakaBladepoint.Controls
{
    public class ImageTextBlock : TemplatedControl
    {
        public static readonly StyledProperty<IImage?> SourceProperty =
            AvaloniaProperty.Register<ImageTextBlock, IImage?>(nameof(Source));

        public IImage? Source
        {
            get => GetValue(SourceProperty);
            set => SetValue(SourceProperty, value);
        }

        public static readonly StyledProperty<string> TextProperty =
            AvaloniaProperty.Register<ImageTextBlock, string>(nameof(Text), string.Empty);

        public string Text
        {
            get => GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public static readonly StyledProperty<ICommand?> CommandProperty =
            AvaloniaProperty.Register<ImageTextBlock, ICommand?>(nameof(Command));

        public ICommand? Command
        {
            get => GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        protected override void OnPointerReleased(PointerReleasedEventArgs e)
        {
            base.OnPointerReleased(e);
            if (e.InitialPressMouseButton == MouseButton.Left)
            {
                if (Command?.CanExecute(null) == true)
                    Command.Execute(null);
            }
        }
    }
}
