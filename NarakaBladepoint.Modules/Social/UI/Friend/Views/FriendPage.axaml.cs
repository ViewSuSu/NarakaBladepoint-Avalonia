using Avalonia.Input;
namespace NarakaBladepoint.Modules.Social.UI.Friend.Views
{
    /// <summary>
    /// FriendPage.xaml 的交互逻辑
    /// </summary>
    internal partial class FriendPage : UserControlBase
    {
        public FriendPage()
        {
            InitializeComponent();
        }

        private void Image_MouseLeftButtonDown(
            object sender,
            PointerPressedEventArgs e
        )
        {
            this.SearchBox.Focus();
            this.SearchBox.Text = null;
        }
    }
}
