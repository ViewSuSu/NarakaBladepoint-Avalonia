using Avalonia.Media;
using NarakaBladepoint.Framework.Core.Extensions;
using NarakaBladepoint.Resources;
using Newtonsoft.Json;

namespace NarakaBladepoint.Shared.Datas
{
    public class MapItemData
    {
        public int Index { get; set; }

        [JsonIgnore]
        public IImage MapImage =>
            ResourceImageReader
                .GetAllMapImagePairs()
                .Keys.FirstOrDefault(x => x.GetFileName().Contains(Name));

        [JsonIgnore]
        public IImage MapGif =>
            ResourceImageReader
                .GetAllMapImagePairs()
                .Values.FirstOrDefault(x => x.GetFileName().Contains(Name));

        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsSelected { get; set; }
    }
}
