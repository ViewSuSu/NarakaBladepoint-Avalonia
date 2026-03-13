using System.Collections.Concurrent;
using Avalonia.Media;
using Avalonia.Media.Imaging;

namespace NarakaBladepoint.Framework.Core.Extensions
{
    public static class ImageSourceExtensions
    {
        private static readonly ConcurrentDictionary<IImage, string> _imageNames = new();

        public static void RegisterImageName(IImage image, string name)
        {
            if (image != null && name != null)
                _imageNames[image] = name;
        }

        public static string? GetFileName(this IImage? imageSource)
        {
            if (imageSource == null)
                return null;
            if (_imageNames.TryGetValue(imageSource, out var name))
                return name;
            return imageSource.ToString();
        }

        public static string? GetFileNameWithExtension(this IImage? imageSource)
        {
            return imageSource?.GetFileName();
        }

        public static string? GetFileExtension(this IImage? imageSource)
        {
            var name = imageSource?.GetFileName();
            if (name == null) return null;
            var dot = name.LastIndexOf('.');
            return dot >= 0 ? name[dot..] : null;
        }
    }
}
