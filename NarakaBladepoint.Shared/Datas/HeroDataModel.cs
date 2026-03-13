using Avalonia.Media;
using NarakaBladepoint.Framework.Core.Extensions;
using NarakaBladepoint.Resources;
using NarakaBladepoint.Shared.Enums;

namespace NarakaBladepoint.Shared.Datas
{
    /// <summary>
    /// 鑻遍泟鏁版嵁妯″瀷
    /// </summary>
    public class HeroDataModel
    {
        /// <summary>
        /// 鑻遍泟绱㈠紩
        /// </summary>
        public int HeroIndex { get; set; } = -1;

        /// <summary>
        /// 鑻遍泟鍚嶇О
        /// </summary>
        public string HeroName => Avatar.GetFileName();

        /// <summary>
        /// 娓告垙妯″紡
        /// </summary>
        public GameMode GameMode { get; set; }

        /// <summary>
        /// 鎺掍綅妯″紡
        /// </summary>
        public TeamSize TeamSize { get; set; }

        /// <summary>
        /// 璧涘绫诲瀷
        /// </summary>
        public SeasonType SeasonType { get; set; }

        /// <summary>
        /// 娓告垙鏃堕棿锛堝皬鏃讹級
        /// </summary>
        public double GameTime { get; set; }

        /// <summary>
        /// 鑻遍泟绉垎
        /// </summary>
        public int HeroScore { get; set; }

        /// <summary>
        /// 鎺掑悕鎻忚堪
        /// </summary>
        public string RankDescription { get; set; }

        /// <summary>
        /// 鍘嗗彶鏈€楂樻帓鍚?
        /// </summary>
        public string HistoricalHighestRank { get; set; }

        /// <summary>
        /// 鏈€杩?2鍦烘暟鎹?
        /// </summary>
        public Recent12GamesData Recent12Games { get; set; }

        /// <summary>
        /// 鎵€鏈夊満娆℃暟鎹?
        /// </summary>
        public AllGamesData AllGames { get; set; }

        /// <summary>
        /// 鐗规畩鎶€鑳芥暟鎹?
        /// </summary>
        public SpecialSkillData SpecialSkill { get; set; }

        /// <summary>
        /// 澶村儚鍥剧墖婧?
        /// </summary>
        public IImage Avatar =>
            HeroIndex != -1 ? ResourceImageReader.GetHeroAvatarImage(HeroName) : null;
    }

    /// <summary>
    /// 鏈€杩?2鍦烘暟鎹?
    /// </summary>
    public class Recent12GamesData
    {
        /// <summary>
        /// 鍓嶄簲鐜?
        /// </summary>
        public double TopFiveRate { get; set; }

        /// <summary>
        /// 鍦哄潎浼ゅ
        /// </summary>
        public int AverageDamage { get; set; }

        /// <summary>
        /// 鍑昏触/琚嚮璐?
        /// </summary>
        public double KillDeathRatio { get; set; }

        /// <summary>
        /// 鏄惁澶勪簬鍚屾浣嶅墠1.5%
        /// </summary>
        public bool IsTop1_5Percent { get; set; }
    }

    /// <summary>
    /// 鎵€鏈夊満娆℃暟鎹?
    /// </summary>
    public class AllGamesData
    {
        /// <summary>
        /// 鍓嶄簲鐜?
        /// </summary>
        public double TopFiveRate { get; set; }

        /// <summary>
        /// 澶╅€夌巼
        /// </summary>
        public double ChampionRate { get; set; }

        /// <summary>
        /// 鑾疯儨鏁?
        /// </summary>
        public int WinCount { get; set; }

        /// <summary>
        /// 鍦哄潎浼ゅ
        /// </summary>
        public int AverageDamage { get; set; }

        /// <summary>
        /// 鍗曞眬鏈€楂樹激瀹?
        /// </summary>
        public int MaxDamagePerGame { get; set; }

        /// <summary>
        /// 鍦哄潎娌荤枟
        /// </summary>
        public int AverageHeal { get; set; }

        /// <summary>
        /// 鎬绘窐姹?
        /// </summary>
        public int TotalEliminations { get; set; }

        /// <summary>
        /// 鍑昏触/琚嚮璐?
        /// </summary>
        public double KillDeathRatio { get; set; }

        /// <summary>
        /// 鍗曞眬鏈€楂樺嚮璐?
        /// </summary>
        public int MaxKillsPerGame { get; set; }

        /// <summary>
        /// 鍦哄潎鍑昏触
        /// </summary>
        public double AverageKills { get; set; }

        /// <summary>
        /// 鎬诲嚮璐?
        /// </summary>
        public int TotalKills { get; set; }
    }

    /// <summary>
    /// 鐗规畩鎶€鑳芥暟鎹?
    /// </summary>
    public class SpecialSkillData
    {
        /// <summary>
        /// 鎶€鑳藉悕绉?
        /// </summary>
        public string SkillName { get; set; }

        /// <summary>
        /// 鎶€鑳芥晥鏋滄暟鎹?
        /// </summary>
        public int SkillEffectData { get; set; }

        /// <summary>
        /// 鍦哄潎鏁版嵁
        /// </summary>
        public double AverageData { get; set; }
    }
}
