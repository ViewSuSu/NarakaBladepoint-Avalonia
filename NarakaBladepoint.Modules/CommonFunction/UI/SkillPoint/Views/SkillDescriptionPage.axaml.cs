using System;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace NarakaBladepoint.Modules.CommonFunction.UI.SkillPoint.Views
{
    public partial class SkillDescriptionPage : UserControl
    {
        public SkillDescriptionPage()
        {
            InitializeComponent();
        }

        public string Title
        {
            get => GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }
        public static readonly StyledProperty<string> TitleProperty =
            AvaloniaProperty.Register<SkillDescriptionPage, string>(nameof(Title), string.Empty);

        public object Tags
        {
            get => GetValue(TagsProperty);
            set => SetValue(TagsProperty, value);
        }
        public static readonly StyledProperty<object> TagsProperty =
            AvaloniaProperty.Register<SkillDescriptionPage, object>(nameof(Tags));

        public IEnumerable<string> GetTagsList()
        {
            var tags = Tags;
            if (tags is IEnumerable<string> list) return list;
            if (tags is string s) return s.Split(',', StringSplitOptions.RemoveEmptyEntries);
            return Array.Empty<string>();
        }

        public double TagWidth
        {
            get => GetValue(TagWidthProperty);
            set => SetValue(TagWidthProperty, value);
        }
        public static readonly StyledProperty<double> TagWidthProperty =
            AvaloniaProperty.Register<SkillDescriptionPage, double>(nameof(TagWidth), double.NaN);

        public double TagHeight
        {
            get => GetValue(TagHeightProperty);
            set => SetValue(TagHeightProperty, value);
        }
        public static readonly StyledProperty<double> TagHeightProperty =
            AvaloniaProperty.Register<SkillDescriptionPage, double>(nameof(TagHeight), double.NaN);

        public object Description
        {
            get => GetValue(DescriptionProperty);
            set => SetValue(DescriptionProperty, value);
        }
        public static readonly StyledProperty<object> DescriptionProperty =
            AvaloniaProperty.Register<SkillDescriptionPage, object>(nameof(Description));

        public string HighlightText
        {
            get => GetValue(HighlightTextProperty);
            set => SetValue(HighlightTextProperty, value);
        }
        public static readonly StyledProperty<string> HighlightTextProperty =
            AvaloniaProperty.Register<SkillDescriptionPage, string>(nameof(HighlightText), string.Empty);

        public GridLength DescriptionHeight
        {
            get => GetValue(DescriptionHeightProperty);
            set => SetValue(DescriptionHeightProperty, value);
        }
        public static readonly StyledProperty<GridLength> DescriptionHeightProperty =
            AvaloniaProperty.Register<SkillDescriptionPage, GridLength>(nameof(DescriptionHeight), GridLength.Auto);

        public Uri VideoSource
        {
            get => GetValue(VideoSourceProperty);
            set => SetValue(VideoSourceProperty, value);
        }
        public static readonly StyledProperty<Uri> VideoSourceProperty =
            AvaloniaProperty.Register<SkillDescriptionPage, Uri>(nameof(VideoSource));

        // TODO: Video playback not available in Avalonia - requires LibVLCSharp or similar
        private void PlayPauseButton_Click(object? sender, RoutedEventArgs e) { }
    }
}
