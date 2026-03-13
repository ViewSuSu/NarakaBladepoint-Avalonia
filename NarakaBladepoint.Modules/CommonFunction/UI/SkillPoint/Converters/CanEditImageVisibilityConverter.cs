using System;
using System.Globalization;
using Avalonia;using Avalonia.Controls;
using Avalonia.Data;using Avalonia.Data.Converters;

namespace NarakaBladepoint.Modules.CommonFunction.UI.SkillPoint.Converters
{
    /// <summary>
    /// 用于判断技能点编辑图标的可见性
    /// 只有当技能点可学习且仍有剩余技能点时才显示
    /// </summary>
    public class CanEditImageVisibilityConverter : IMultiValueConverter
    {
        public object? Convert(IList<object?> values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Count < 2)
                return false;

            // values[0] 是 IsLearnable (bool)
            // values[1] 是 RemainingPoints (int)
            if (values[0] is bool isLearnable && values[1] is int remainingPoints)
            {
                return (isLearnable && remainingPoints > 0) ? true : false;
            }

            return false;
        }

        
    }
}
