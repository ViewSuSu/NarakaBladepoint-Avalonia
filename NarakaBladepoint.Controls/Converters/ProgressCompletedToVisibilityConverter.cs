using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Avalonia.Data.Converters;

namespace NarakaBladepoint.Controls.Converters
{
    internal class ProgressCompletedToVisibilityConverter : IMultiValueConverter
    {
        public bool Invert { get; set; }

        public object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
        {
            double progress1 = 0.0;
            double progress2 = 1.0;
            object? currentItem = null;
            IEnumerable? itemsCollection = null;

            if (values.Count > 0 && values[0] != null)
                double.TryParse(values[0]!.ToString(), NumberStyles.Any, culture, out progress1);
            if (values.Count > 1 && values[1] != null)
                double.TryParse(values[1]!.ToString(), NumberStyles.Any, culture, out progress2);
            if (values.Count > 2)
                currentItem = values[2];
            if (values.Count > 3 && values[3] is IEnumerable col)
                itemsCollection = col;

            if (progress2 == 0) progress2 = 1.0;

            int itemsCount = 1;
            int alternationIndex = 0;
            if (itemsCollection != null)
            {
                if (itemsCollection is IList list)
                {
                    itemsCount = list.Count;
                    if (currentItem != null)
                    {
                        alternationIndex = list.IndexOf(currentItem);
                        if (alternationIndex < 0) alternationIndex = 0;
                    }
                }
                else
                {
                    int idx = 0;
                    int found = -1;
                    int cnt = 0;
                    foreach (var it in itemsCollection)
                    {
                        if (object.Equals(it, currentItem) && found == -1)
                            found = idx;
                        idx++;
                        cnt++;
                    }
                    itemsCount = cnt > 0 ? cnt : 1;
                    alternationIndex = found >= 0 ? found : 0;
                }
            }

            double overallPercent = (progress1 / progress2) * 100.0;
            double filledAmount = overallPercent * itemsCount;
            double segmentStart = alternationIndex * 100.0;
            double segmentValue = Math.Max(0.0, Math.Min(100.0, filledAmount - segmentStart));

            bool completed = segmentValue >= 100.0 - 1e-6;
            if (Invert) completed = !completed;

            return completed;
        }
    }
}
