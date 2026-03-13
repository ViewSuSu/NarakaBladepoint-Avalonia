using Avalonia;using Avalonia.Controls;
using NarakaBladepoint.Modules.SocialTag.UI.Views;
using NarakaBladepoint.Resources;
using NarakaBladepoint.Shared.Datas;

namespace NarakaBladepoint.Modules.Social.UI.Friend.ViewModels
{
    internal class FriendPageViewModel : CanRemoveHomePageRegionViewModelBase
    {
        private readonly ICurrentUserInfoProvider currentUserInformationProvider;
        private readonly ITipMessageService tipMessageService;

        private List<FriendDataItem> _friends = [];

        public List<FriendDataItem> Friends
        {
            get { return _friends; }
            set
            {
                _friends = value;
                RaisePropertyChanged();
            }
        }

        private List<TeammateDataItem> _teammates = [];

        public List<TeammateDataItem> Teammates
        {
            get { return _teammates; }
            set
            {
                _teammates = value;
                RaisePropertyChanged();
            }
        }

        private bool _isHaveVilidTag;

        public bool IsHaveVilidTag
        {
            get { return _isHaveVilidTag; }
            set
            {
                _isHaveVilidTag = value;
                RaisePropertyChanged();
            }
        }

        public FriendPageViewModel(
            ICurrentUserInfoProvider currentUserInformationProvider,
            ITipMessageService tipMessageService
        )
        {
            this.currentUserInformationProvider = currentUserInformationProvider;
            this.tipMessageService = tipMessageService;
            Init();
        }

        private void Init()
        {
            Friends = currentUserInformationProvider.GetFriendsAsync().Result;
            this.CurrentUserInfoModel = currentUserInformationProvider
                .GetCurrentUserInfoAsync()
                .Result;
            this.IsHaveVilidTag = CurrentUserInfoModel.IsExsitAnyValidSocialTag;
            InitTeammates();
        }

        private void InitTeammates()
        {
            var random = new Random();
            int avatarCount = ResourceImageReader.AvatarCount;

            Teammates = new List<TeammateDataItem>
            {
                new()
                {
                    AvatarIndex = random.Next(0, avatarCount),
                    Name = "��ī��Ȫ",
                    Description = "��λ������",
                    Tags = new() { "��λ������", "��ͨ���", "���ڹ�ͨ" }
                },
                new()
                {
                    AvatarIndex = random.Next(0, avatarCount),
                    Name = "�^���",
                    Description = "��ͨ���",
                    Tags = new() { "��ͨ���", "���ڹ�ͨ" }
                },
                new()
                {
                    AvatarIndex = random.Next(0, avatarCount),
                    Name = "����oxo",
                    Description = "���ڹ�ͨ",
                    Tags = new() { "���ڹ�ͨ", "��ͨ����", "�ƿ�ȫ��" }
                },
                new()
                {
                    AvatarIndex = random.Next(0, avatarCount),
                    Name = "������������",
                    Description = "��Ԯ����",
                    Tags = new() { "��Ԯ����", "���ڹ�ͨ", "�罻����" }
                },
                new()
                {
                    AvatarIndex = random.Next(0, avatarCount),
                    Name = ".Diva.",
                    Description = "�罻����",
                    Tags = new() { "�罻����", "�ó�Ӣ�ۻ���", "��λ���" }
                },
                new()
                {
                    AvatarIndex = random.Next(0, avatarCount),
                    Name = "����",
                    Description = "��Ծ���",
                    Tags = new() { "��Ծ���", "�ó�Ӣ�ۻ���", "���ڹ�ͨ" }
                }
            };
        }

        protected override void OnNavigatedToExecute(NavigationContext navigationContext)
        {
            Init();
        }

        public UserInformationData CurrentUserInfoModel { get; private set; }

        private DelegateCommand _closeCommand;

        public DelegateCommand CloseCommand =>
            _closeCommand ??= new DelegateCommand(() =>
            {
                eventAggregator.GetEvent<RemoveHomePageRegionEvent>().Publish();
            });

        private DelegateCommand _settingTagCommand;

        public DelegateCommand SettingTagCommand =>
            _settingTagCommand ??= new DelegateCommand(() =>
            {
                ReturnCommand.Execute();
                eventAggregator
                    .GetEvent<LoadHomePageRegionEvent>()
                    .Publish(new NavigationArgs(nameof(SocialTagPage)));
            });

        private DelegateCommand<FriendDataItem> _sayHelloCommand;

        public DelegateCommand<FriendDataItem> SayHelloCommand =>
            _sayHelloCommand ??= new DelegateCommand<FriendDataItem>(
                async (selectedItem) =>
                {
                    await tipMessageService.ShowTipMessageAsync(
                        new TipMessageWithHighlightArgs(
                            $"�����ʺ�:{selectedItem.Name},���ܶ�+10",
                            [selectedItem.Name, "+10"]
                        )
                    );
                }
            );

        private DelegateCommand<string> _searchCommand;

        public DelegateCommand<string> SearchCommand =>
            _searchCommand ??= new DelegateCommand<string>(async keyword =>
            {
                Friends = await currentUserInformationProvider.GetFriendsAsync(keyword);
            });

        private DelegateCommand _copyIdCommand;

        public DelegateCommand CopyIdCommand =>
            _copyIdCommand ??= new DelegateCommand(async () =>
            {
                try
                {
                    var topLevel = Avalonia.Controls.TopLevel.GetTopLevel(Avalonia.Application.Current?.ApplicationLifetime is Avalonia.Controls.ApplicationLifetimes.IClassicDesktopStyleApplicationLifetime desktop ? desktop.MainWindow : null);
                    var clipboard = topLevel?.Clipboard;
                    if (clipboard != null)
                        await clipboard.SetTextAsync(CurrentUserInfoModel.Id.ToString());
                    await tipMessageService.ShowTipMessageAsync(
                        new TipMessageWithHighlightArgs("���Ƴɹ�")
                    );
                }
                catch
                {
                    await tipMessageService.ShowTipMessageAsync(
                        new TipMessageWithHighlightArgs("����ʧ��")
                    );
                }
            });

        private DelegateCommand<TeammateDataItem> _blockCommand;

        public DelegateCommand<TeammateDataItem> BlockCommand =>
            _blockCommand ??= new DelegateCommand<TeammateDataItem>(
                async (teammate) =>
                {
                    await tipMessageService.ShowTipMessageAsync(
                        new TipMessageWithHighlightArgs($"������ {teammate.Name}")
                    );
                }
            );

        private DelegateCommand<TeammateDataItem> _recruitCommand;

        public DelegateCommand<TeammateDataItem> RecruitCommand =>
            _recruitCommand ??= new DelegateCommand<TeammateDataItem>(
                async (teammate) =>
                {
                    await tipMessageService.ShowTipMessageAsync(
                        new TipMessageWithHighlightArgs($"���� {teammate.Name} ������ļ����")
                    );
                }
            );
    }
}
