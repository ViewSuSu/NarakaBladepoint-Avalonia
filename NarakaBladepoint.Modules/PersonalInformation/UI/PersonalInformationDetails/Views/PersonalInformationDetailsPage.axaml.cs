using Avalonia.Input;
namespace NarakaBladepoint.Modules.PersonalInformation.UI.PersonalInformationDetails.Views
{
    /// <summary>
    /// PersonalInformationDetailsPage.xaml 的交互逻辑
    /// </summary>
    public partial class PersonalInformationDetailsPage : UserControlBase
    {
        public PersonalInformationDetailsPage()
        {
            InitializeComponent();
        }

        private void ChangeGender_MouseLeftButtonUp(
            object? sender,
            PointerReleasedEventArgs e
        )
        {
            e.Handled = true;
            if (this.FindControl<Avalonia.Controls.Primitives.Popup>("EditMenuPopup") is { } popup)
            {
                popup.IsOpen = !popup.IsOpen;
            }
        }
    }
}
