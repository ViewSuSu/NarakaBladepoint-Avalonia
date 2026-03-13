using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.VisualTree;

namespace NarakaBladepoint.Modules.CommonFunction.UI.SkillPoint.Controls
{
    /// <summary>
    /// 自定义Border控件，支持选中时显示内偏移白色边框。
    /// 由于 Avalonia 的 Border.Render 是 sealed 的，高亮效果通过
    /// 直接设置 Border 的 BorderBrush / BorderThickness 来实现。
    /// </summary>
    public class SelectiveBorder : Border
    {
        public static readonly StyledProperty<bool> IsHighlightedProperty =
            AvaloniaProperty.Register<SelectiveBorder, bool>(nameof(IsHighlighted), false);

        public bool IsHighlighted
        {
            get => GetValue(IsHighlightedProperty);
            set => SetValue(IsHighlightedProperty, value);
        }

        public static readonly StyledProperty<double> HighlightBorderThicknessProperty =
            AvaloniaProperty.Register<SelectiveBorder, double>(nameof(HighlightBorderThickness), 1.0);

        public double HighlightBorderThickness
        {
            get => GetValue(HighlightBorderThicknessProperty);
            set => SetValue(HighlightBorderThicknessProperty, value);
        }

        public static readonly StyledProperty<IBrush> HighlightBorderBrushProperty =
            AvaloniaProperty.Register<SelectiveBorder, IBrush>(nameof(HighlightBorderBrush), Brushes.White);

        public IBrush HighlightBorderBrush
        {
            get => GetValue(HighlightBorderBrushProperty);
            set => SetValue(HighlightBorderBrushProperty, value);
        }

        static SelectiveBorder()
        {
            IsHighlightedProperty.Changed.AddClassHandler<SelectiveBorder>((sb, _) => sb.ApplyHighlightVisual());
            HighlightBorderThicknessProperty.Changed.AddClassHandler<SelectiveBorder>((sb, _) => sb.ApplyHighlightVisual());
            HighlightBorderBrushProperty.Changed.AddClassHandler<SelectiveBorder>((sb, _) => sb.ApplyHighlightVisual());
        }

        public SelectiveBorder()
        {
            this.Loaded += SelectiveBorder_Loaded;
        }

        private void SelectiveBorder_Loaded(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            AttachPropertyChangeListeners();
            UpdateHighlightState();
        }

        private void AttachPropertyChangeListeners()
        {
            var talentGrids = FindAllTalentGrids(this);
            foreach (var grid in talentGrids)
            {
                grid.PropertyChanged += (s, e) =>
                {
                    if (e.Property == TalentGrid.IsSelectedProperty)
                    {
                        UpdateHighlightState();
                    }
                };
            }
        }

        private void UpdateHighlightState()
        {
            var talentGrids = FindAllTalentGrids(this);
            bool anySelected = false;

            foreach (var grid in talentGrids)
            {
                if (grid.IsSelected)
                {
                    anySelected = true;
                    break;
                }
            }

            if (anySelected)
            {
                this.IsHighlighted = true;
                CancelSiblingHighlight();
            }
            else
            {
                this.IsHighlighted = false;
            }
        }

        /// <summary>
        /// 根据 IsHighlighted 状态设置 Border 自身的 BorderBrush / BorderThickness
        /// </summary>
        private void ApplyHighlightVisual()
        {
            if (IsHighlighted)
            {
                BorderBrush = HighlightBorderBrush;
                BorderThickness = new Thickness(HighlightBorderThickness);
            }
            else
            {
                BorderBrush = null;
                BorderThickness = new Thickness(0);
            }
        }

        private void CancelSiblingHighlight()
        {
            var parent = this.GetVisualParent();
            if (parent is Visual visualParent)
            {
                foreach (var child in visualParent.GetVisualChildren())
                {
                    if (child is SelectiveBorder sibling && sibling != this)
                    {
                        sibling.IsHighlighted = false;
                    }
                }
            }
        }

        private static List<TalentGrid> FindAllTalentGrids(Visual parent)
        {
            var talentGrids = new List<TalentGrid>();
            FindTalentGridsRecursive(parent, talentGrids);
            return talentGrids;
        }

        private static void FindTalentGridsRecursive(Visual parent, List<TalentGrid> list)
        {
            foreach (var child in parent.GetVisualChildren())
            {
                if (child is TalentGrid talentGrid)
                {
                    list.Add(talentGrid);
                }
                FindTalentGridsRecursive(child, list);
            }
        }
    }
}
