using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.VisualTree;

namespace NarakaBladepoint.Modules.CommonFunction.UI.SkillPoint.Controls
{
    /// <summary>
    /// 天赋/技能/奥义选择Grid控件
    /// </summary>
    public class TalentGrid : Grid
    {
        public event EventHandler IsSelectedChanged;

        public static readonly StyledProperty<bool> IsSelectedProperty =
            AvaloniaProperty.Register<TalentGrid, bool>(nameof(IsSelected), false);

        public bool IsSelected
        {
            get => GetValue(IsSelectedProperty);
            set => SetValue(IsSelectedProperty, value);
        }

        static TalentGrid()
        {
            IsSelectedProperty.Changed.AddClassHandler<TalentGrid>((grid, e) =>
            {
                if ((bool)e.NewValue!)
                {
                    grid.IsSelectedChanged?.Invoke(grid, EventArgs.Empty);
                }
            });
        }

        public TalentGrid()
        {
            this.PointerPressed += TalentGrid_PointerPressed;
        }

        private void TalentGrid_PointerPressed(object? sender, PointerPressedEventArgs e)
        {
            var parent = this.GetVisualParent();
            if (parent is Panel parentPanel)
            {
                foreach (var child in parentPanel.GetVisualChildren())
                {
                    if (child is TalentGrid talentGrid)
                    {
                        if (talentGrid == this)
                        {
                            if (talentGrid.IsSelected)
                            {
                                talentGrid.IsSelected = false;
                                talentGrid.IsSelected = true;
                            }
                            else
                            {
                                talentGrid.IsSelected = true;
                            }
                        }
                        else
                        {
                            talentGrid.IsSelected = false;
                        }
                    }
                }
            }

            e.Handled = true;
        }
    }
}
