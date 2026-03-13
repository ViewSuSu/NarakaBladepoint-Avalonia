using System.Globalization;
using Avalonia;
using Avalonia.Data.Converters;
using Avalonia.Media;

namespace NarakaBladepoint.Controls.Converters
{
    internal class LTopLeftConverter : IValueConverter
    {
        public object Convert(object value, Type t, object p, CultureInfo c)
        {
            double l = System.Convert.ToDouble(value);

            var figure = new PathFigure
            {
                StartPoint = new Point(0, l),
                Segments = new PathSegments
                {
                    new LineSegment { Point = new Point(0, 0) },
                    new LineSegment { Point = new Point(l, 0) },
                },
            };

            return new PathGeometry { Figures = { figure } };
        }

        public object ConvertBack(object v, Type t, object p, CultureInfo c) => AvaloniaProperty.UnsetValue;
    }

    internal class LTopRightConverter : IValueConverter
    {
        public object Convert(object value, Type t, object p, CultureInfo c)
        {
            double l = System.Convert.ToDouble(value);

            var figure = new PathFigure
            {
                StartPoint = new Point(0, 0),
                Segments = new PathSegments
                {
                    new LineSegment { Point = new Point(l, 0) },
                    new LineSegment { Point = new Point(l, l) },
                },
            };

            return new PathGeometry { Figures = { figure } };
        }

        public object ConvertBack(object v, Type t, object p, CultureInfo c) => AvaloniaProperty.UnsetValue;
    }

    internal class LBottomLeftConverter : IValueConverter
    {
        public object Convert(object value, Type t, object p, CultureInfo c)
        {
            double l = System.Convert.ToDouble(value);

            var figure = new PathFigure
            {
                StartPoint = new Point(0, 0),
                Segments = new PathSegments
                {
                    new LineSegment { Point = new Point(0, l) },
                    new LineSegment { Point = new Point(l, l) },
                },
            };

            return new PathGeometry { Figures = { figure } };
        }

        public object ConvertBack(object v, Type t, object p, CultureInfo c) => AvaloniaProperty.UnsetValue;
    }

    internal class LBottomRightConverter : IValueConverter
    {
        public object Convert(object value, Type t, object p, CultureInfo c)
        {
            double l = System.Convert.ToDouble(value);

            var figure = new PathFigure
            {
                StartPoint = new Point(l, 0),
                Segments = new PathSegments
                {
                    new LineSegment { Point = new Point(l, l) },
                    new LineSegment { Point = new Point(0, l) },
                },
            };

            return new PathGeometry { Figures = { figure } };
        }

        public object ConvertBack(object v, Type t, object p, CultureInfo c) => AvaloniaProperty.UnsetValue;
    }
}

