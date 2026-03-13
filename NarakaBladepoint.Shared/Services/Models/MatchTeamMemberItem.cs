using Avalonia.Media;

namespace NarakaBladepoint.Shared.Services.Models
{
    /// <summary>
    /// 瀵瑰眬闃熶紞鎴愬憳淇℃伅
    /// </summary>
    public class MatchTeamMemberItem
    {
        /// <summary>
        /// 鐜╁鏄电О
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 鐜╁澶村儚
        /// </summary>
        public IImage Avatar { get; set; }

        /// <summary>
        /// 鐜╁鎴愬氨/绉板彿鍥剧墖鍒楄〃
        /// </summary>
        public List<IImage> Titles { get; set; } = new();

        /// <summary>
        /// 鐢熷瓨鏃堕棿
        /// </summary>
        public string SurvivalTime { get; set; }

        /// <summary>
        /// 鍑昏触鏁?
        /// </summary>
        public int TeamKills { get; set; }

        /// <summary>
        /// 鎬讳激瀹?
        /// </summary>
        public int TotalDamage { get; set; }

        /// <summary>
        /// 鎬绘不鐤楅噺
        /// </summary>
        public int TotalHealing { get; set; }

        /// <summary>
        /// 鏁戞彺娆℃暟
        /// </summary>
        public int AwardedTeams { get; set; }

        /// <summary>
        /// 浜插瘑搴︼紙缁忛獙锛?
        /// </summary>
        public int Experience { get; set; }

        /// <summary>
        /// 鏄惁鏄綋鍓嶇敤鎴凤紙鐢ㄤ簬绐佸嚭鏄剧ず锛?
        /// </summary>
        public bool IsCurrentUser { get; set; }
    }
}
