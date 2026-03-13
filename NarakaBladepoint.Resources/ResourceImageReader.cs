using System.Collections;
using System.Resources;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using NarakaBladepoint.Framework.Core.Extensions;

namespace NarakaBladepoint.Resources
{
    public static class ResourceImageReader
    {
        private static readonly List<IImage> _heroImages = new();
        private static readonly List<IImage> _heroShowImages = new();
        private static readonly List<IImage> _avatarImages = new();
        private static readonly List<IImage> _heroTagImages = new();
        private static readonly List<IImage> _weaponImages = new();
        private static readonly List<IImage> _inventoryPropImages = new();
        private static readonly Dictionary<string, (List<IImage> Skills, IImage Background)> _weaponFolderImages = new();
        private static readonly Dictionary<IImage, IImage> _mapImagePairs = new();
        private static readonly Dictionary<int, IImage> _historyMatchRecordImages = new();
        private static readonly List<IImage> _personalInfoAchievementImages = new();
        private static readonly List<IImage> _illustratedCollectionRootImages = new();
        private static readonly Dictionary<string, List<IImage>> _illustratedCollectionFolderImages = new();
        private static readonly List<IImage> _timeLimitedEventRewardImages = new();
        private static readonly List<IImage> _timeLimitedEventImages2 = new();
        private static readonly List<IImage> _timeLimitedEventImages3 = new();
        private static readonly List<IImage> _storeOverviewImages = new();
        private static readonly List<IImage> _storeDailyPropImages = new();
        private static readonly List<IImage> _storeDailyHuanSiImages = new();
        private static readonly List<IImage> _storeDailyGiftImages = new();
        private static readonly Dictionary<int, List<IImage>> _storeHeroTagImages = new();
        private static readonly List<IImage> _moonGazingPavilionImages = new();
        private static readonly List<IImage> _tournamentChampionImages = new();
        private static readonly string _assemblyName = typeof(ResourceImageReader).Assembly.GetName().Name!;

        static ResourceImageReader()
        {
            var assembly = typeof(ResourceImageReader).Assembly;
            var resourceName = assembly.GetName().Name + ".g.resources";
            using var stream = assembly.GetManifestResourceStream(resourceName);
            if (stream == null) return;
            using var reader = new ResourceReader(stream);
            var mapStaticTemp = new Dictionary<string, IImage>();
            var mapGifTemp = new Dictionary<string, IImage>();
            var moonGazingPavilionTemp = new Dictionary<int, IImage>();

            foreach (DictionaryEntry entry in reader)
            {
                if (entry.Key is not string key) continue;
                key = key.ToLowerInvariant();

                if (key.StartsWith("image/hero/") && key.EndsWith(".png"))
                {
                    var relative = key["image/hero/".Length..];
                    if (!relative.Contains("/"))
                        try { _heroImages.Add(LoadBitmapFromResource(key)); } catch { }
                }
                if (key.StartsWith("image/heroshow/") && key.EndsWith(".png"))
                    try { _heroShowImages.Add(LoadBitmapFromResource(key)); } catch { }
                if (key.StartsWith("image/avatar/") && key.EndsWith(".png"))
                    try { _avatarImages.Add(LoadBitmapFromResource(key)); } catch { }
                if (key.StartsWith("image/herotag/") && key.EndsWith(".png"))
                {
                    var relative = key["image/herotag/".Length..];
                    if (!relative.Contains("/"))
                        try { _heroTagImages.Add(LoadBitmapFromResource(key)); } catch { }
                }
                if (key.StartsWith("image/weapon/") && key.EndsWith(".png"))
                {
                    var relative = key["image/weapon/".Length..];
                    if (!relative.Contains("/"))
                        try { _weaponImages.Add(LoadBitmapFromResource(key)); } catch { }
                    else
                    {
                        var parts = relative.Split('/');
                        if (parts.Length == 2)
                        {
                            var folderName = parts[0];
                            var fileName = parts[1];
                            try
                            {
                                var img = LoadBitmapFromResource(key);
                                if (!_weaponFolderImages.ContainsKey(folderName))
                                    _weaponFolderImages[folderName] = (new List<IImage>(), null!);
                                var data = _weaponFolderImages[folderName];
                                if (fileName.StartsWith("background", StringComparison.OrdinalIgnoreCase))
                                    _weaponFolderImages[folderName] = (data.Skills, img);
                                else
                                    data.Skills.Add(img);
                            }
                            catch { }
                        }
                    }
                }
                if (key.StartsWith("image/inventoryprops/") && key.EndsWith(".png"))
                    try { _inventoryPropImages.Add(LoadBitmapFromResource(key)); } catch { }
                if (key.StartsWith("image/map/") && (key.EndsWith(".png") || key.EndsWith(".gif")))
                {
                    var relative = key["image/map/".Length..];
                    var nameOnly = System.IO.Path.GetFileNameWithoutExtension(relative);
                    try
                    {
                        var img = LoadBitmapFromResource(key);
                        if (key.EndsWith(".gif")) mapGifTemp[nameOnly] = img;
                        else mapStaticTemp[nameOnly] = img;
                    }
                    catch { }
                }
                if (key.StartsWith("image/hisitorymatchrecord/") && key.EndsWith(".png"))
                    try { _historyMatchRecordImages[_historyMatchRecordImages.Count] = LoadBitmapFromResource(key); } catch { }
                if (key.StartsWith("image/personalinfodetails/achievements/images/") && key.EndsWith(".png"))
                    try { _personalInfoAchievementImages.Add(LoadBitmapFromResource(key)); } catch { }
                if (key.StartsWith("image/personalinfodetails/illustratedcollection/") && key.EndsWith(".png"))
                {
                    var relative = key["image/personalinfodetails/illustratedcollection/".Length..];
                    if (!relative.Contains("/"))
                        try { _illustratedCollectionRootImages.Add(LoadBitmapFromResource(key)); } catch { }
                    else
                    {
                        var parts = relative.Split('/');
                        if (parts.Length == 2)
                        {
                            var folder = parts[0];
                            try
                            {
                                if (!_illustratedCollectionFolderImages.ContainsKey(folder))
                                    _illustratedCollectionFolderImages[folder] = new List<IImage>();
                                _illustratedCollectionFolderImages[folder].Add(LoadBitmapFromResource(key));
                            }
                            catch { }
                        }
                    }
                }
                if (key.StartsWith("image/region/eventcenter/timelimitedevent/images/") && key.EndsWith(".png"))
                    try { _timeLimitedEventRewardImages.Add(LoadBitmapFromResource(key)); } catch { }
                if (key.StartsWith("image/region/eventcenter/timelimitedevent/images2/") && key.EndsWith(".png"))
                    try { _timeLimitedEventImages2.Add(LoadBitmapFromResource(key)); } catch { }
                if (key.StartsWith("image/region/eventcenter/timelimitedevent/images3/") && key.EndsWith(".png"))
                    try { _timeLimitedEventImages3.Add(LoadBitmapFromResource(key)); } catch { }
                if (key.StartsWith("image/store/overview/") && key.EndsWith(".png"))
                    try { _storeOverviewImages.Add(LoadBitmapFromResource(key)); } catch { }
                if (key.StartsWith("image/store/daily/prop/") && key.EndsWith(".png"))
                    try { _storeDailyPropImages.Add(LoadBitmapFromResource(key)); } catch { }
                if (key.StartsWith("image/store/daily/huansi/") && key.EndsWith(".png"))
                    try { _storeDailyHuanSiImages.Add(LoadBitmapFromResource(key)); } catch { }
                if (key.StartsWith("image/store/daily/gift/") && key.EndsWith(".png"))
                    try { _storeDailyGiftImages.Add(LoadBitmapFromResource(key)); } catch { }
                if (key.StartsWith("image/store/herotag/") && key.EndsWith(".png"))
                {
                    var relative = key["image/store/herotag/".Length..];
                    var parts = relative.Split('/');
                    if (parts.Length == 2 && int.TryParse(parts[0], out var tagIndex))
                    {
                        try
                        {
                            if (!_storeHeroTagImages.ContainsKey(tagIndex))
                                _storeHeroTagImages[tagIndex] = new List<IImage>();
                            _storeHeroTagImages[tagIndex].Add(LoadBitmapFromResource(key));
                        }
                        catch { }
                    }
                }
                if (key.StartsWith("image/region/eventcenter/lanyuege/images/") && key.EndsWith(".png"))
                {
                    var relative = key["image/region/eventcenter/lanyuege/images/".Length..];
                    var nameOnly = System.IO.Path.GetFileNameWithoutExtension(relative);
                    if (int.TryParse(nameOnly, out var idx))
                        try { moonGazingPavilionTemp[idx] = LoadBitmapFromResource(key); } catch { }
                }
                if (key.StartsWith("image/personalinfodetails/leaderboard/champions/") && key.EndsWith(".png"))
                    try { _tournamentChampionImages.Add(LoadBitmapFromResource(key)); } catch { }
            }
            foreach (var kvp in mapStaticTemp)
            {
                mapGifTemp.TryGetValue(kvp.Key, out var gif);
                _mapImagePairs[kvp.Value] = gif!;
            }
            foreach (var kvp in moonGazingPavilionTemp.OrderBy(x => x.Key))
                _moonGazingPavilionImages.Add(kvp.Value);
        }

        private static string ExtractFileName(string key)
        {
            var fileName = System.IO.Path.GetFileNameWithoutExtension(key);
            if (fileName.EndsWith(".bakedui", StringComparison.OrdinalIgnoreCase))
                fileName = fileName[..^8];
            if (fileName.EndsWith(".bitmap", StringComparison.OrdinalIgnoreCase))
                fileName = fileName[..^7];
            return fileName;
        }

        private static Bitmap LoadBitmapFromResource(string key)
        {
            var uri = new Uri($"avares://{_assemblyName}/{key}");
            using var stream = AssetLoader.Open(uri);
            var bitmap = new Bitmap(stream);
            ImageSourceExtensions.RegisterImageName(bitmap, ExtractFileName(key));
            return bitmap;
        }

        public static IImage GetHeroAvatarImage(string name) =>
            _heroImages.Find(img => string.Equals(img.GetFileName(), name, StringComparison.OrdinalIgnoreCase))!;
        public static IImage GetHeroAvatarImage(int index)
        {
            var name = _heroShowImages[index].GetFileName();
            return _heroImages.FirstOrDefault(x => x.GetFileName() == name)!;
        }
        public static IImage GetHeroShowImage(string name) =>
            _heroShowImages.Find(img => string.Equals(img.GetFileName(), name, StringComparison.OrdinalIgnoreCase))!;
        public static IImage GetSocialAvatarImage(int index) =>
            index >= 0 && index < _avatarImages.Count ? _avatarImages[index] : null!;
        public static IImage GetHeroTagImage(int index) =>
            index >= 0 && index < _heroTagImages.Count ? _heroTagImages[index] : null!;
        public static IReadOnlyList<IImage> GetAllHeroAvatarImageSouces() => _heroImages.AsReadOnly();
        public static IReadOnlyList<IImage> GetAllHeroShowImages() => _heroShowImages.AsReadOnly();
        public static IReadOnlyList<IImage> GetAllAvatarImages() => _avatarImages.AsReadOnly();
        public static IReadOnlyList<IImage> GetAllHeroTagImages() => _heroTagImages.AsReadOnly();
        public static int HeroCount => _heroImages.Count;
        public static int HeroShowCount => _heroShowImages.Count;
        public static int AvatarCount => _avatarImages.Count;
        public static int HeroTagCount => _heroTagImages.Count;

        public static IImage GetInventoryPropImage(int index) =>
            index >= 0 && index < _inventoryPropImages.Count ? _inventoryPropImages[index] : null!;
        public static IReadOnlyList<IImage> GetAllInventoryPropImages() => _inventoryPropImages.AsReadOnly();
        public static int InventoryPropCount => _inventoryPropImages.Count;

        public static IImage GetWeaponImage(string name) =>
            _weaponImages.Find(img => string.Equals(img.GetFileName(), name, StringComparison.OrdinalIgnoreCase))!;
        public static IReadOnlyList<IImage> GetAllWeaponImages() => _weaponImages.AsReadOnly();
        public static int WeaponCount => _weaponImages.Count;

        public static IImage GetWeaponBackground(string weaponName)
        {
            var key = _weaponFolderImages.Keys.FirstOrDefault(k => string.Equals(k, weaponName, StringComparison.OrdinalIgnoreCase));
            return key != null && _weaponFolderImages.TryGetValue(key, out var data) ? data.Background : null!;
        }
        public static List<IImage> GetWeaponSkillImages(string weaponName)
        {
            var key = _weaponFolderImages.Keys.FirstOrDefault(k => string.Equals(k, weaponName, StringComparison.OrdinalIgnoreCase));
            return key != null && _weaponFolderImages.TryGetValue(key, out var data) ? data.Skills : new List<IImage>();
        }

        public static IReadOnlyDictionary<IImage, IImage> GetAllMapImagePairs() => _mapImagePairs;
        public static IImage GetMapGif(IImage mapImage) =>
            mapImage != null && _mapImagePairs.TryGetValue(mapImage, out var gif) ? gif : null!;
        public static int MapCount => _mapImagePairs.Count;

        public static IImage GetHistoryMatchRecordImage(int index) =>
            _historyMatchRecordImages.TryGetValue(index, out var image) ? image : null!;
        public static IReadOnlyDictionary<int, IImage> GetAllHistoryMatchRecordImages() => _historyMatchRecordImages;
        public static int HistoryMatchRecordCount => _historyMatchRecordImages.Count;

        public static IImage GetPersonalInfoAchievementImage(int index) =>
            index >= 0 && index < _personalInfoAchievementImages.Count ? _personalInfoAchievementImages[index] : null!;
        public static IReadOnlyList<IImage> GetAllPersonalInfoAchievementImages() => _personalInfoAchievementImages.AsReadOnly();
        public static int PersonalInfoAchievementCount => _personalInfoAchievementImages.Count;

        public static IImage GetIllustratedCollectionRootImage(int index) =>
            index >= 0 && index < _illustratedCollectionRootImages.Count ? _illustratedCollectionRootImages[index] : null!;
        public static IReadOnlyList<IImage> GetAllIllustratedCollectionRootImages() => _illustratedCollectionRootImages.AsReadOnly();
        public static IReadOnlyDictionary<string, List<IImage>> GetAllIllustratedCollectionFolderImages() => _illustratedCollectionFolderImages;

        private static IImage TryLoadImageByResourceKey(string resourceKey)
        {
            if (string.IsNullOrWhiteSpace(resourceKey)) return null!;
            try { return LoadBitmapFromResource(resourceKey); } catch { return null!; }
        }

        public static IImage IllustratedCollectionImage_3 => TryLoadImageByResourceKey("image/personalinfodetails/illustratedcollection/3.png");
        public static IImage IllustratedCollectionImage_4 => TryLoadImageByResourceKey("image/personalinfodetails/illustratedcollection/4.png");
        public static IImage IllustratedCollectionImage_5 => TryLoadImageByResourceKey("image/personalinfodetails/illustratedcollection/5.png");
        public static IImage IllustratedCollectionRootImage3 => IllustratedCollectionImage_3;
        public static IImage IllustratedCollectionRootImage4 => IllustratedCollectionImage_4;
        public static IImage IllustratedCollectionRootImage5 => IllustratedCollectionImage_5;

        public static List<IImage> GetIllustratedCollectionImagesByFolder(string folderName)
        {
            if (string.IsNullOrWhiteSpace(folderName)) return new List<IImage>();
            var key = _illustratedCollectionFolderImages.Keys.FirstOrDefault(k => string.Equals(k, folderName, StringComparison.OrdinalIgnoreCase));
            return key != null && _illustratedCollectionFolderImages.TryGetValue(key, out var list) ? list : new List<IImage>();
        }

        public static IImage GetStoreOverviewImage(int index) =>
            index >= 0 && index < _storeOverviewImages.Count ? _storeOverviewImages[index] : null!;
        public static IReadOnlyList<IImage> GetAllStoreOverviewImages() => _storeOverviewImages.AsReadOnly();
        public static int StoreOverviewCount => _storeOverviewImages.Count;

        public static IImage GetStoreDailyPropImage(int index) =>
            index >= 0 && index < _storeDailyPropImages.Count ? _storeDailyPropImages[index] : null!;
        public static IReadOnlyList<IImage> GetAllStoreDailyPropImages() => _storeDailyPropImages.AsReadOnly();
        public static int StoreDailyPropCount => _storeDailyPropImages.Count;

        public static IImage GetStoreDailyHuanSiImage(int index) =>
            index >= 0 && index < _storeDailyHuanSiImages.Count ? _storeDailyHuanSiImages[index] : null!;
        public static IReadOnlyList<IImage> GetAllStoreDailyHuanSiImages() => _storeDailyHuanSiImages.AsReadOnly();
        public static int StoreDailyHuanSiCount => _storeDailyHuanSiImages.Count;

        public static IImage GetStoreDailyGiftImage(int index) =>
            index >= 0 && index < _storeDailyGiftImages.Count ? _storeDailyGiftImages[index] : null!;
        public static IReadOnlyList<IImage> GetAllStoreDailyGiftImages() => _storeDailyGiftImages.AsReadOnly();
        public static int StoreDailyGiftCount => _storeDailyGiftImages.Count;

        public static IReadOnlyList<IImage> GetStoreHeroTagImages(int tagIndex) =>
            _storeHeroTagImages.TryGetValue(tagIndex, out var images) ? images.AsReadOnly() : new List<IImage>().AsReadOnly();
        public static IReadOnlyDictionary<int, List<IImage>> GetAllStoreHeroTagImages() => _storeHeroTagImages;
        public static int StoreHeroTagCount => _storeHeroTagImages.Count;

        public static IReadOnlyList<IImage> GetAllTournamentChampionImages() => _tournamentChampionImages.AsReadOnly();
        public static int TournamentChampionCount => _tournamentChampionImages.Count;

        public static IImage GetTimeLimitedEventRewardImage(int index) =>
            index >= 0 && index < _timeLimitedEventRewardImages.Count ? _timeLimitedEventRewardImages[index] : null!;
        public static IReadOnlyList<IImage> GetAllTimeLimitedEventRewardImages() => _timeLimitedEventRewardImages.AsReadOnly();
        public static int TimeLimitedEventRewardCount => _timeLimitedEventRewardImages.Count;

        public static IImage GetTimeLimitedEventImages2(int index) =>
            index >= 0 && index < _timeLimitedEventImages2.Count ? _timeLimitedEventImages2[index] : null!;
        public static IReadOnlyList<IImage> GetAllTimeLimitedEventImages2() => _timeLimitedEventImages2.AsReadOnly();
        public static int TimeLimitedEventImages2Count => _timeLimitedEventImages2.Count;

        public static IImage GetTimeLimitedEventImages3(int index) =>
            index >= 0 && index < _timeLimitedEventImages3.Count ? _timeLimitedEventImages3[index] : null!;
        public static IReadOnlyList<IImage> GetAllTimeLimitedEventImages3() => _timeLimitedEventImages3.AsReadOnly();
        public static int TimeLimitedEventImages3Count => _timeLimitedEventImages3.Count;

        public static IImage GetMoonGazingPavilionImage(int index) =>
            index >= 0 && index < _moonGazingPavilionImages.Count ? _moonGazingPavilionImages[index] : null!;
        public static IReadOnlyList<IImage> GetAllMoonGazingPavilionImages() => _moonGazingPavilionImages.AsReadOnly();
        public static int MoonGazingPavilionCount => _moonGazingPavilionImages.Count;
    }
}
