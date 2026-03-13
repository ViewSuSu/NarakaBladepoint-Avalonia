using Avalonia.Controls;

namespace NarakaBladepoint.Framework.Core.Bases.Views
{
    public abstract class UserControlBase : UserControl
    {
        public UserControlBase()
        {
            ViewModelLocator.SetAutoWireViewModel(this, true);
        }
    }
}
