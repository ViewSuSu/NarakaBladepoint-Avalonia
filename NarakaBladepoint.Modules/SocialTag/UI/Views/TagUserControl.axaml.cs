using Avalonia;

namespace NarakaBladepoint.Modules.SocialTag.UI.Views
{
    public partial class TagUserControl : UserControlBase
    {
        public TagUserControl()
        {
            InitializeComponent();
        }

        public double ContentFontSize
        {
            get => GetValue(ContentFontSizeProperty);
            set => SetValue(ContentFontSizeProperty, value);
        }

        public static readonly StyledProperty<double> ContentFontSizeProperty =
            AvaloniaProperty.Register<TagUserControl, double>(nameof(ContentFontSize), 12.0);
    }
}
