using Avalonia.Media;
using NarakaBladepoint.Resources;

namespace NarakaBladepoint.Shared.Datas
{
    /// <summary>
    /// 姝﹀櫒鏁版嵁锛堣繎鎴樺拰杩滅▼閫氱敤锛?
    /// </summary>
    public class WeaponData
    {
        /// <summary>
        /// 姝﹀櫒鍚嶇О
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 姝﹀櫒绛夌骇
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// 姝﹀櫒鍥炬爣
        /// </summary>
        public IImage Icon => ResourceImageReader.GetWeaponImage(Name);

        /// <summary>
        /// 姝﹀櫒鑳屾櫙鍥?
        /// </summary>
        public IImage Background => ResourceImageReader.GetWeaponBackground(Name);

        /// <summary>
        /// 姝﹀櫒鎶€鑳藉浘鐗囧垪琛?
        /// </summary>
        public List<IImage> SkillImages => ResourceImageReader.GetWeaponSkillImages(Name);

        /// <summary>
        /// 鎬讳激瀹?
        /// </summary>
        public int TotalDamage { get; set; }

        /// <summary>
        /// 鎬诲嚮璐?
        /// </summary>
        public int TotalEliminations { get; set; }

        /// <summary>
        /// 鎬诲姪鏀?
        /// </summary>
        public int TotalAssists { get; set; }

        /// <summary>
        /// 鍗曞満鏈€楂樹激瀹?
        /// </summary>
        public int MaxDamagePerGame { get; set; }

        /// <summary>
        /// 鍗曞満鏈€楂樺嚮璐?
        /// </summary>
        public int MaxEliminationsPerGame { get; set; }

        /// <summary>
        /// 缁勶紙杩戞垬姝﹀櫒鍒嗙粍鐢級
        /// </summary>
        public string Group { get; set; }

        /// <summary>
        /// 鎬绘尟鍒€锛堣繎鎴樻鍣ㄤ笓鐢級
        /// </summary>
        public int TotalParries { get; set; }

        /// <summary>
        /// 鍛戒腑澶撮儴娆℃暟锛堣繙绋嬫鍣ㄤ笓鐢級
        /// </summary>
        public int Headshots { get; set; }

        /// <summary>
        /// 鏈€杩滃嚮璐ヨ窛绂伙紙杩滅▼姝﹀櫒涓撶敤锛?
        /// </summary>
        public int FarthestEliminationDistance { get; set; }
    }
}
