using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;

namespace NarakaBladepoint.Controls
{
    public class HighlightBorder : Border
    {
        private Border? _highlightOverlay;
        private Border? _maskOverlay;

        public static readonly StyledProperty<Thickness> HighlightThicknessProperty =
            AvaloniaProperty.Register<HighlightBorder, Thickness>(nameof(HighlightThickness), new Thickness(1));

        public Thickness HighlightThickness
        {
            get => GetValue(HighlightThicknessProperty);
            set => SetValue(HighlightThicknessProperty, value);
        }

        public static readonly StyledProperty<IBrush> HighlightBrushProperty =
            AvaloniaProperty.Register<HighlightBorder, IBrush>(nameof(HighlightBrush), Brushes.White);

        public IBrush HighlightBrush
        {
            get => GetValue(HighlightBrushProperty);
            set => SetValue(HighlightBrushProperty, value);
        }

        public static readonly StyledProperty<bool> EnableMaskOnHoverProperty =
            AvaloniaProperty.Register<HighlightBorder, bool>(nameof(EnableMaskOnHover), false);

        public bool EnableMaskOnHover
        {
            get => GetValue(EnableMaskOnHoverProperty);
            set => SetValue(EnableMaskOnHoverProperty, value);
        }

        protected override void OnPointerEntered(PointerEventArgs e)
        {
            base.OnPointerEntered(e);
            ShowHighlight();
        }

        protected override void OnPointerExited(PointerEventArgs e)
        {
            base.OnPointerExited(e);
            HideHighlight();
        }

        private void ShowHighlight()
        {
            if (_highlightOverlay == null)
            {
                _highlightOverlay = new Border
                {
                    BorderBrush = HighlightBrush,
                    BorderThickness = HighlightThickness,
                    IsHitTestVisible = false,
                };
            }

            if (EnableMaskOnHover && _maskOverlay == null)
            {
                _maskOverlay = new Border
                {
                    Background = new SolidColorBrush(Color.FromArgb(60, 255, 255, 255)),
                    IsHitTestVisible = false,
                };
            }
        }

        private void HideHighlight()
        {
            _highlightOverlay = null;
            _maskOverlay = null;
        }
    }
}
