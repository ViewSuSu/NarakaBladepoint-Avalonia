using Avalonia.Media;
using NarakaBladepoint.Resources;

namespace NarakaBladepoint.Shared.Jsons
{
    public class MatchData
    {
        public List<MatchDataItem> List { get; set; }
    }

    public class MatchDataItem
    {
        /// <summary>
        /// 鏁版嵁绱㈠紩
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// 鑻遍泟澶村儚
        /// </summary>
        public int AvatarIndex { get; set; }

        /// <summary>
        /// 鑻遍泟澶村儚
        /// </summary>
        public IImage Avatar => ResourceImageReader.GetHeroAvatarImage(AvatarIndex);

        /// <summary>
        /// 褰撳墠鎺掑悕
        /// </summary>
        public int CurrentRank { get; set; }

        public bool IsNo1 => CurrentRank == 1;
        public bool IsNo2 => CurrentRank == 2;
        public bool IsNo3To4 => CurrentRank >= 3 && CurrentRank <= 4;

        /// <summary>
        /// 鎵€鏈夐槦浼?
        /// </summary>
        public int AllTeams { get; set; }

        /// <summary>
        /// 鍑绘潃鏁?
        /// </summary>
        public int KillNumber { get; set; }

        /// <summary>
        /// 浼ゅ
        /// </summary>
        public int Damage { get; set; }

        /// <summary>
        /// 褰撳墠娈典綅
        /// </summary>
        public string CurrentLevel { get; set; }

        /// <summary>
        /// 姣旇禌妯″紡
        /// </summary>
        public string GameMode { get; set; }

        /// <summary>
        /// 姣旇禌鏃堕棿
        /// </summary>
        public DateTime GameTime { get; set; }

        /// <summary>
        /// 鍒嗘暟
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// 鍒嗘暟鍙樺寲
        /// </summary>
        public int ChangeScore { get; set; }

        /// <summary>
        /// 鏄惁鏄豹鏉板灞€
        /// </summary>
        public bool IsHightLevel => Score >= 4500;

        /// <summary>
        /// 鏄惁鍔犲垎
        /// </summary>
        public bool IsAdd { get; set; }

        /// <summary>
        /// 鏄惁棰濆鍔犲垎400+
        /// </summary>
        public bool IsEasy { get; set; }

        /// <summary>
        /// 瀵瑰眬鎴愬氨鍥剧墖绱㈠紩鍒楄〃 (绱㈠紩浠?寮€濮?
        /// </summary>
        public List<int> AchievementIndexes { get; set; } = new();

        /// <summary>
        /// 瀵瑰眬鎴愬氨鍥剧墖鍒楄〃
        /// </summary>
        public List<IImage> Achievements =>
            AchievementIndexes
                .Select(index => ResourceImageReader.GetHistoryMatchRecordImage(index))
                .Where(img => img != null)
                .ToList();
    }
}
