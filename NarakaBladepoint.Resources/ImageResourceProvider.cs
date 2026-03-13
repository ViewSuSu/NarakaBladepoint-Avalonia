using System;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace NarakaBladepoint.Resources;

/// <summary>
/// Provides image resources as Bitmap objects for StaticResource usage in AXAML.
/// Replaces the WPF BitmapImage resource dictionary entries that were defined in ImageSourceStyle.xaml.
/// </summary>
public static class ImageResourceProvider
{
    private const string BaseUri = "avares://NarakaBladepoint.Resources/Image/";

    private static readonly Dictionary<string, string> ResourceMap = new()
    {
        // Root images
        ["AncientCoinsImage"] = "Button/古币.png",
        ["AppIconImage"] = "Icon.png",
        ["BattlePassBackgroundImage"] = "BattlePassBackground.png",
        ["BlockImage"] = "屏蔽.png",
        ["CanEditImage"] = "CanEdit.png",
        ["ClearSearchImage"] = "×.png",
        ["ClickSettingTagImage"] = "点击设置标签.png",
        ["CopyImage"] = "复制.png",
        ["DailyTaskBackground1Image"] = "每日任务背景1.png",
        ["DailyTaskFlowerImage"] = "每日任务花.png",
        ["DailyTaskRewardImage"] = "每日任务奖励.png",
        ["EventCenterLogoImage"] = "活动中心logo.png",
        ["FilterImage"] = "筛选.png",
        ["FriendInvImage"] = "friendInv.png",
        ["GoldBrickImage"] = "Button/金砖.png",
        ["HuanSiImage"] = "Button/幻丝.png",
        ["LogoImage"] = "logo.png",
        ["MouseLeftButtonImage"] = "MouseLeftButton.png",
        ["MouseRightButtonImage"] = "MouseRightButton.png",
        ["OnlineImage"] = "在线.png",
        ["RecruitmentImage"] = "招募.png",
        ["RefreshImage"] = "刷新.png",
        ["SayHelloImage"] = "sayhello.png",
        ["SearchMagnifierImage"] = "搜索放大镜.png",
        ["StarImage"] = "星.png",
        ["TaskDetailsImage"] = "任务详情.png",
        ["TreasurePavilionImage"] = "聚宝阁.png",
        ["WeaponLevelImage"] = "Button/武器等级.png",

        // Avatar
        ["Avatar1Image"] = "Avatar/1.png",

        // Baize
        ["Baize1Image"] = "Baize/1.png",
        ["Baize2Image"] = "Baize/2.png",
        ["Baize3Image"] = "Baize/3.png",
        ["Baize4Image"] = "Baize/4.png",
        ["Baize5Image"] = "Baize/5.png",
        ["Baize6Image"] = "Baize/6.png",
        ["Baize8Image"] = "Baize/8.png",
        ["Baize9Image"] = "Baize/9.png",
        ["Baize11Image"] = "Baize/11.png",
        ["Baize12Image"] = "Baize/12.png",
        ["Baize13Image"] = "Baize/13.png",
        ["Baize14Image"] = "Baize/14.png",
        ["Baize15Image"] = "Baize/15.png",
        ["Baize16Image"] = "Baize/16.png",
        ["Baize17Image"] = "Baize/17.png",
        ["Baize18Image"] = "Baize/18.png",
        ["Baize19Image"] = "Baize/19.png",
        ["Baize20Image"] = "Baize/20.png",
        ["BaizeBackgroundImage"] = "Baize/background.png",
        ["BaizeTextblockBackgroundImage"] = "Baize/textblockBackground.png",
        ["BaizeTipImage"] = "Baize/tip.png",

        // Button
        ["ButtonBaiZeBaiKeImage"] = "Button/白泽百科.png",
        ["ButtonBaiZeYueKaImage"] = "Button/白泽月卡.png",
        ["ButtonLuHuaJiShiImage"] = "Button/露华集市.png",
        ["ButtonRuJieMenImage"] = "Button/入劫门.png",
        ["ButtonSaiShiImage"] = "Button/赛事.png",
        ["ButtonTuoZhanBaoImage"] = "Button/拓展包.png",
        ["ButtonXiuXingImage"] = "Button/修行.png",
        ["ButtonZhaiXingGeImage"] = "Button/摘星阁.png",
        ["ButtonZhaoDuiYouImage"] = "Button/找队友.png",
        ["FriendTabItemBackgroundImage"] = "Button/FriendTabItemBackground.png",

        // CustomMatch
        ["CustomMatchLockImage"] = "CustomMatch/1.png",
        ["CustomMatchRefreshImage"] = "CustomMatch/2.png",
        ["CustomMatchSearchImage"] = "CustomMatch/3.png",

        // Email
        ["Email1Image"] = "Email/1.png",
        ["Email2Image"] = "Email/2.png",
        ["Email3Image"] = "Email/3.png",
        ["Email4Image"] = "Email/4.png",
        ["Email5Image"] = "Email/5.png",
        ["EmailIconImage"] = "Email/Icon.png",

        // GuildHall
        ["GuildHallImage0"] = "GuildHall/1.png",
        ["GuildHallImage1"] = "GuildHall/2.png",
        ["GuildHallImage2"] = "GuildHall/3.png",
        ["GuildHallImageIcon1"] = "GuildHall/Icon1.png",
        ["GuildHallStoreImage2"] = "GuildHall/Image2.png",

        // Hero
        ["HeroCuiSanNiangImage"] = "Hero/崔三娘.png",
        ["HeroGuQingHanImage"] = "Hero/顾清寒.png",
        ["HeroHaDiImage"] = "Hero/哈迪.png",
        ["HeroImage"] = "Hero/张起灵.png",
        ["HeroShowImage"] = "Hero/Show/张起灵.png",
        ["ZhangQiLingHeroImage"] = "Hero/张起灵.png",

        // HeroData
        ["HeroData1Image"] = "HeroData/1.png",
        ["HeroData2Image"] = "HeroData/2.png",
        ["HeroData3Image"] = "HeroData/3.png",

        // Hero Skill
        ["HeroSkillF1Image"] = "Hero/Skill/F1.png",
        ["HeroSkillIconImage"] = "Hero/Skill/Icon.png",
        ["HeroSkillV1Image"] = "Hero/Skill/V1.png",

        // HistoryMatchDetailsRecord
        ["HistoryMatchDetailsRecord1Image"] = "HisitoryMatchDetailsRecord/1.png",
        ["HistoryMatchDetailsRecord2Image"] = "HisitoryMatchDetailsRecord/2.png",
        ["HistoryMatchDetailsRecord3Image"] = "HisitoryMatchDetailsRecord/3.png",
        ["HistoryMatchDetailsRecord4Image"] = "HisitoryMatchDetailsRecord/4.png",

        // InventoryProps
        ["InventoryProps1Image"] = "InventoryProps/1.png",
        ["InventoryPropsGaoQingImage"] = "InventoryProps/gaoqing.png",
        ["InventoryPropsLogo1Image"] = "InventoryProps/logo1.png",
        ["InventoryPropsLogo2Image"] = "InventoryProps/logo2.png",
        ["InventoryPropsLogo3Image"] = "InventoryProps/logo3.png",
        ["InventoryPropsLogo4Image"] = "InventoryProps/logo4.png",
        ["InventoryPropsLogo5Image"] = "InventoryProps/logo5.png",

        // IllustratedCollection
        ["IllustratedCollectionBuFanImage"] = "PersonalInfoDetails/IllustratedCollection/Images/1.png",

        // LatestNews
        ["LatestNews1Image"] = "Region/EventCenter/LatestNews/1.png",
        ["LatestNews2Image"] = "Region/EventCenter/LatestNews/2.png",
        ["LatestNews3Image"] = "Region/EventCenter/LatestNews/3.png",
        ["LatestNews4Image"] = "Region/EventCenter/LatestNews/4.png",
        ["LatestNews5Image"] = "Region/EventCenter/LatestNews/5.png",

        // Leaderboard
        ["LeaderboardBrotherhoodRealmImage"] = "PersonalInfoDetails/Leaderboard/聚义榜段位.png",
        ["LeaderboardBrotherhoodScoreImage"] = "PersonalInfoDetails/Leaderboard/积分按钮.png",
        ["LeaderboardCollectionScoreImage"] = "PersonalInfoDetails/Leaderboard/总收藏值.png",
        ["LeaderboardCollectionScoreTabItemImage"] = "PersonalInfoDetails/Leaderboard/Icon.png",
        ["LeaderboardHeroTabItem1Image"] = "PersonalInfoDetails/Leaderboard/Icon1.png",
        ["LeaderboardHeroTabItem2Image"] = "PersonalInfoDetails/Leaderboard/Icon2.png",
        ["LeaderboardHeroTabItem3Image"] = "PersonalInfoDetails/Leaderboard/Icon3.png",
        ["LeaderboardHeroTabItem4Image"] = "PersonalInfoDetails/Leaderboard/Icon4.png",
        ["LeaderboardTournamentChampionArrowImage"] = "PersonalInfoDetails/Leaderboard/箭头.png",
        ["LeaderboardTournamentChampionBackgroundImage"] = "PersonalInfoDetails/Leaderboard/穹苍魁首.png",
        ["LeaderboardTournamentChampionDesignImage"] = "PersonalInfoDetails/Leaderboard/日曜名宿.png",
        ["LeaderboardUniversityTabItemImage"] = "PersonalInfoDetails/Leaderboard/高校榜.png",

        // ModeSelection
        ["ModeSelectionIcon1Image"] = "Region/ModeSelection/Icon1.png",
        ["ModeSelectionIcon2Image"] = "Region/ModeSelection/Icon2.png",
        ["ModeSelectionIcon4Image"] = "Region/ModeSelection/Icon4.png",
        ["ModeSelectionIcon5Image"] = "Region/ModeSelection/Icon5.png",
        ["ModeSelectionIcon6Image"] = "Region/ModeSelection/Icon6.png",
        ["ModeSelectionIcon7Image"] = "Region/ModeSelection/Icon7.png",
        ["ModeSelectionTabItem1Image"] = "Region/ModeSelection/TabItem1.png",
        ["ModeSelectionTabItem2Image"] = "Region/ModeSelection/TabItem2.png",
        ["ModeSelectionTabItem3Image"] = "Region/ModeSelection/TabItem3.png",
        ["ModeSelectionTabItem4Image"] = "Region/ModeSelection/TabItem4.png",
        ["ModeSelectionTabItem5Image"] = "Region/ModeSelection/TabItem5.png",

        // MoonGazingPavilion (LanYueGe)
        ["MoonGazingPavilionBackground1Image"] = "Region/EventCenter/LanYueGe/Background1.png",
        ["MoonGazingPavilionIcon1Image"] = "Region/EventCenter/LanYueGe/Icon1.png",
        ["MoonGazingPavilionIcon2Image"] = "Region/EventCenter/LanYueGe/Icon2.png",
        ["MoonGazingPavilionIcon3Image"] = "Region/EventCenter/LanYueGe/Icon3.png",
        ["MoonGazingPavilionIcon4Image"] = "Region/EventCenter/LanYueGe/Icon4.png",
        ["MoonGazingPavilionIcon5Image"] = "Region/EventCenter/LanYueGe/Icon5.png",
        ["MoonGazingPavilionIcon6Image"] = "Region/EventCenter/LanYueGe/Icon6.png",
        ["MoonGazingPavilionIcon7Image"] = "Region/EventCenter/LanYueGe/Icon7.png",

        // Music
        ["MusicEmptyStateBackgroundImage"] = "Music/background.png",

        // PersonalInfoDetails
        ["PersonalInfoDetails1Image"] = "PersonalInfoDetails/1.png",
        ["PersonalInfoDetails2Image"] = "PersonalInfoDetails/2.png",
        ["PersonalInfoDetails3Image"] = "PersonalInfoDetails/3.png",
        ["PersonalInfoDetails4Image"] = "PersonalInfoDetails/4.png",
        ["PersonalInfoDetails5Image"] = "PersonalInfoDetails/5.png",
        ["PersonalInfoDetails6Image"] = "PersonalInfoDetails/6.png",
        ["PersonalInfoDetails7Image"] = "PersonalInfoDetails/7.png",
        ["PersonalInfoDetails8Image"] = "PersonalInfoDetails/8.png",
        ["PersonalInfoDetails9Image"] = "PersonalInfoDetails/9.png",
        ["PersonalInfoDetails10Image"] = "PersonalInfoDetails/10.png",
        ["PersonalInfoDetails12Image"] = "PersonalInfoDetails/12.png",
        ["PersonalInfoDetails13Image"] = "PersonalInfoDetails/13.png",
        ["PersonalInfoDetails14Image"] = "PersonalInfoDetails/14.png",
        ["PersonalInfoDetails15Image"] = "PersonalInfoDetails/15.png",
        ["PersonalInfoDetails16Image"] = "PersonalInfoDetails/16.png",
        ["PersonalInfoDetails18Image"] = "PersonalInfoDetails/18.png",
        ["PersonalInfoDetails19Image"] = "PersonalInfoDetails/19.png",
        ["PersonalInfoDetails20Image"] = "PersonalInfoDetails/20.png",
        ["PersonalInfoDetailsHero1Image"] = "PersonalInfoDetails/hero1.png",
        ["PersonalInfoDetailsHero2Image"] = "PersonalInfoDetails/hero2.png",
        ["PersonalInfoDetailsHero3Image"] = "PersonalInfoDetails/hero3.png",
        ["PersonalInfoDetailsListBoxItemBackgroundImage"] = "PersonalInfoDetails/listboxitembackground.png",
        ["PersonalInfoDetailsTouZiImage"] = "PersonalInfoDetails/TouZi.png",

        // PersonalInfoDetails Achievements
        ["PersonalInfoDetailsAchievementIcon2Image"] = "PersonalInfoDetails/Achievements/icon2.png",
        ["PersonalInfoDetailsAchievementIcon3Image"] = "PersonalInfoDetails/Achievements/icon3.png",
        ["PersonalInfoDetailsAchievementIcon4Image"] = "PersonalInfoDetails/Achievements/icon4.png",
        ["PersonalInfoDetailsAchievementIcon5Image"] = "PersonalInfoDetails/Achievements/icon5.png",
        ["PersonalInfoDetailsAchievementIcon6Image"] = "PersonalInfoDetails/Achievements/icon6.png",
        ["PersonalInfoDetailsAchievementIcon7Image"] = "PersonalInfoDetails/Achievements/icon7.png",
        ["PersonalInfoDetailsAchievements2Image"] = "PersonalInfoDetails/Achievements/2.png",
        ["PersonalInfoDetailsAchievements3Image"] = "PersonalInfoDetails/Achievements/3.png",
        ["PersonalInfoDetailsAchievements4Image"] = "PersonalInfoDetails/Achievements/4.png",
        ["PersonalInfoDetailsAchievementsImages2_1Image"] = "PersonalInfoDetails/Achievements/Images2/1.png",
        ["PersonalInfoDetailsAchievementsImages2_2Image"] = "PersonalInfoDetails/Achievements/Images2/2.png",
        ["PersonalInfoDetailsAchievementsImages2_3Image"] = "PersonalInfoDetails/Achievements/Images2/3.png",
        ["PersonalInfoDetailsAchievementsImages2_4Image"] = "PersonalInfoDetails/Achievements/Images2/4.png",
        ["PersonalInfoDetailsAchievementsImages2_5Image"] = "PersonalInfoDetails/Achievements/Images2/5.png",
        ["PersonalInfoDetailsAchievementsImages3_1Image"] = "PersonalInfoDetails/Achievements/Images3/1.png",
        ["PersonalInfoDetailsAchievementsImages3_2Image"] = "PersonalInfoDetails/Achievements/Images3/2.png",
        ["PersonalInfoDetailsAchievementsImages3_3Image"] = "PersonalInfoDetails/Achievements/Images3/3.png",
        ["PersonalInfoDetailsAchievementsImages3_4Image"] = "PersonalInfoDetails/Achievements/Images3/4.png",
        ["PersonalInfoDetailsAchievementsImages3_5Image"] = "PersonalInfoDetails/Achievements/Images3/5.png",

        // EditGender
        ["EditGenderPage1Image"] = "PersonalInfoDetails/EditGender/1.png",
        ["EditGenderPage2Image"] = "PersonalInfoDetails/EditGender/2.png",

        // BindReward
        ["BindRewardRewardImage1"] = "Region/EventCenter/BindReward/Background1.png",
        ["BindRewardRewardImage2"] = "Region/EventCenter/BindReward/Background2.png",
        ["BindRewardRewardImage2_1"] = "Region/EventCenter/BindReward/Images2/1.png",
        ["BindRewardRewardImage2_2"] = "Region/EventCenter/BindReward/Images2/2.png",
        ["BindRewardRewardImage2_3"] = "Region/EventCenter/BindReward/Images2/3.png",
        ["BindRewardRewardImage3"] = "Region/EventCenter/BindReward/Background3.png",
        ["BindRewardRewardImage3_1"] = "Region/EventCenter/BindReward/Images3/1.png",
        ["BindRewardRewardImage3_2"] = "Region/EventCenter/BindReward/Images3/2.png",
        ["BindRewardRewardImage3_3"] = "Region/EventCenter/BindReward/Images3/3.png",
        ["BindRewardRewardImage4_1"] = "Region/EventCenter/BindReward/Images4/1.png",
        ["BindRewardRewardImage4_2"] = "Region/EventCenter/BindReward/Images4/2.png",
        ["BindRewardRewardImage5_1"] = "Region/EventCenter/BindReward/Images5/1.png",
        ["BindRewardRewardImage5_2"] = "Region/EventCenter/BindReward/Images5/2.png",
        ["BindRewardRewardImage5_3"] = "Region/EventCenter/BindReward/Images5/3.png",
        ["BindRewardRewardImage5_4"] = "Region/EventCenter/BindReward/Images5/4.png",

        // SkillPoints
        ["F1Image"] = "SkillPoints/F1.png",
        ["F2Image"] = "SkillPoints/F2.png",
        ["V1Image"] = "SkillPoints/V1.png",
        ["V2Image"] = "SkillPoints/V2.png",
        ["TianFu1Image"] = "SkillPoints/TianFu1.png",
        ["TianFu2Image"] = "SkillPoints/TianFu2.png",
        ["SkillPointBackgroundImage"] = "SkillPoints/Background.png",
        ["SkillPointFKeyImage"] = "SkillPoints/F1.png",
        ["SkillPointLeftDownFirstCircle1Image"] = "SkillPoints/LeftDown/OneCircel1.png",
        ["SkillPointLeftDownFirstCircle2Image"] = "SkillPoints/LeftDown/OneCircel2.png",
        ["SkillPointLeftDownSecondCircle2Image"] = "SkillPoints/LeftDown/TwoCircel2.png",
        ["SkillPointLeftDownThirdCircle1Image"] = "SkillPoints/LeftDown/ThreeCircel1.png",
        ["SkillPointLeftDownThirdCircle2Image"] = "SkillPoints/LeftDown/ThreeCircel2.png",
        ["SkillPointLeftUpFirstCircle1Image"] = "SkillPoints/LeftUp/OneCircel1.png",
        ["SkillPointLeftUpFirstCircle2Image"] = "SkillPoints/LeftUp/OneCircel2.png",
        ["SkillPointLeftUpSecondCircle1Image"] = "SkillPoints/LeftUp/TwoCircel1.png",
        ["SkillPointLeftUpSecondCircle2Image"] = "SkillPoints/LeftUp/TwoCircel2.png",
        ["SkillPointLeftUpThirdCircle1Image"] = "SkillPoints/LeftUp/ThreeCircel1.png",
        ["SkillPointLeftUpThirdCircle2Image"] = "SkillPoints/LeftUp/ThreeCircel2.png",
        ["SkillPointRightDownFirstCircle1Image"] = "SkillPoints/RightDown/OneCircel1.png",
        ["SkillPointRightDownFirstCircle2Image"] = "SkillPoints/RightDown/OneCircel2.png",
        ["SkillPointRightDownSecondCircle1Image"] = "SkillPoints/RightDown/TwoCircel1.png",
        ["SkillPointRightDownSecondCircle2Image"] = "SkillPoints/RightDown/TwoCircel2.png",
        ["SkillPointRightDownThirdCircle1Image"] = "SkillPoints/RightDown/ThreeCircel1.png",
        ["SkillPointRightDownThirdCircle2Image"] = "SkillPoints/RightDown/ThreeCircel2.png",
        ["SkillPointRightUpFirstCircle1Image"] = "SkillPoints/RightUp/OneCircel1.png",
        ["SkillPointRightUpFirstCircle2Image"] = "SkillPoints/RightUp/OneCircel2.png",
        ["SkillPointRightUpSecondCircle1Image"] = "SkillPoints/RightUp/TwoCircel1.png",
        ["SkillPointRightUpSecondCircle2Image"] = "SkillPoints/RightUp/TwoCircel2.png",
        ["SkillPointRightUpThirdCircle1Image"] = "SkillPoints/RightUp/ThreeCircel1.png",
        ["SkillPointRightUpThirdCircle2Image"] = "SkillPoints/RightUp/ThreeCircel2.png",

        // SocialTag
        ["SocialTagBackgroundImage"] = "SocialTag/background.png",
        ["SocialTagIcon1Image"] = "SocialTag/Icon1.png",
        ["SocialTagIcon2Image"] = "SocialTag/Icon2.png",
        ["SocialTagTabItemIcon1Image"] = "SocialTag/tabItemIcon1.png",
        ["SocialTagTabItemIcon2Image"] = "SocialTag/tabItemIcon2.png",
        ["SocialTagTabItemIcon3Image"] = "SocialTag/tabItemIcon3.png",
        ["SocialTagTabItemIcon4Image"] = "SocialTag/tabItemIcon4.png",
        ["SocialTagTabItemIcon5Image"] = "SocialTag/tabItemIcon5.png",

        // StartGame
        ["StartGameStartImage"] = "Region/StartGame/开始游戏.png",
        ["StartGameModeSelectionImage"] = "Region/StartGame/模式选择.png",
        ["StartGameRankImage"] = "Region/StartGame/段位.png",
        ["StartGameEventCenterImage"] = "Region/StartGame/活动中心.png",
        ["StartGameQuickMatchImage"] = "Region/StartGame/Survival/快速比赛.png",
        ["StartGameRankingMatchImage"] = "Region/StartGame/Survival/排位赛.png",
        ["StartGameHeavenlyBattleImage"] = "Region/StartGame/Survival/天人之战.png",
        ["StartGameAIPracticeImage"] = "Region/StartGame/Survival/人机演练.png",
        ["StartGameEntertainmentDarkTidImage"] = "Region/StartGame/Entertainment/1.png",
        ["StartGameEntertainmentEndlessTrialImage"] = "Region/StartGame/Entertainment/2.png",
        ["StartGameEntertainmentHexagonalRaidImage"] = "Region/StartGame/Entertainment/3.png",
        ["StartGameEntertainmentMartialArtsPeakImage"] = "Region/StartGame/Entertainment/4.png",
        ["StartGameEntertainmentTerrainWarImage"] = "Region/StartGame/Entertainment/5.png",
        ["StartGameLeisureComingSoon1Image"] = "Region/StartGame/Leisure/1.png",
        ["StartGameLeisureComingSoon2Image"] = "Region/StartGame/Leisure/2.png",
        ["StartGameLeisureDiceGameImage"] = "Region/StartGame/1.png",
        ["StartGameTrainingAdvancedTeachingImage"] = "Region/StartGame/Training/1.png",
        ["StartGameTrainingFreelyPracticeImage"] = "Region/StartGame/Training/2.png",
        ["StartGameTrainingOperationTeachingImage"] = "Region/StartGame/Training/3.png",

        // Store
        ["StoreHeroTagIcon1Image"] = "Store/HeroTag/Icon1.png",

        // TimeLimitedEvent
        ["TimeLimitedEventIcon1Image"] = "Region/EventCenter/TimeLimitedEvent/Icon1.png",
        ["TimeLimitedEventIcon2Image"] = "Region/EventCenter/TimeLimitedEvent/Icon2.png",
        ["TimeLimitedEventIcon3Image"] = "Region/EventCenter/TimeLimitedEvent/Icon3.png",
        ["TimeLimitedEventTipImage"] = "Button/提示Tip.png",

        // TopUp
        ["TopUp1Image"] = "Region/TopUp/1.png",
        ["TopUp2Image"] = "Region/TopUp/2.png",
        ["TopUp3Image"] = "Region/TopUp/3.png",
        ["TopUp4Image"] = "Region/TopUp/4.png",
        ["TopUp5Image"] = "Region/TopUp/5.png",

        // Wealth
        ["Wealth1Image"] = "Region/Wealth/1.png",

        // WelcomeBack
        ["WelcomeBackBackgroundImage"] = "WelcomeBack/Background.png",
    };

    /// <summary>
    /// Registers all image resources into the application's resource dictionary.
    /// Call this during App initialization after AvaloniaXamlLoader.Load(this).
    /// </summary>
    public static void RegisterAll(Application app)
    {
        foreach (var (key, path) in ResourceMap)
        {
            try
            {
                var uri = new Uri(BaseUri + path);
                var bitmap = new Bitmap(AssetLoader.Open(uri));
                app.Resources[key] = bitmap;
            }
            catch
            {
                // Skip resources whose image files don't exist
            }
        }
    }
}
