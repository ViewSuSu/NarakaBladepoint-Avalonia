using System;
using System.Globalization;
using Avalonia;using Avalonia.Controls;
using Avalonia.Data;using Avalonia.Data.Converters;

namespace NarakaBladepoint.Modules.CommonFunction.UI.SkillPoint.Converters
{
    /// <summary>
    /// 技能选中互斥显示转换器
    /// 根据选中的技能类型决定控件的显示/隐藏
    /// </summary>
    public class SelectedSkillVisibilityConverter : IMultiValueConverter
    {
        public object? Convert(IList<object?> values, Type targetType, object parameter, CultureInfo culture)
        {
            // values: [currentSelectedSkillType (string)]
            if (values == null || values.Count < 1 || parameter == null)
                return false;

            string currentSelectedSkillType = values[0] as string ?? "";
            string skillType = parameter.ToString().ToLower();

            return skillType switch
            {
                "f1" => currentSelectedSkillType == "f1" ? true : false,
                "f2" => currentSelectedSkillType == "f2" ? true : false,
                "v1" => currentSelectedSkillType == "v1" ? true : false,
                "v2" => currentSelectedSkillType == "v2" ? true : false,
                // canvas 在没有选中任何技能（F/V）或选中天赋时显示
                "canvas" => (string.IsNullOrEmpty(currentSelectedSkillType) || currentSelectedSkillType == "tianfu") ? true : false,
                _ => false
            };
        }

        
    }
}
