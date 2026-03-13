using System.Collections.ObjectModel;
using Avalonia.Media;
using NarakaBladepoint.Framework.Core.Bases.ViewModels;
using NarakaBladepoint.Resources;
using Prism.Commands;

namespace NarakaBladepoint.Modules.CommonFunction.UI.Store.ViewModels
{
    internal class StoreDailyPageViewModel : ViewModelBase
    {
        private ObservableCollection<IImage> _propImages;
        private ObservableCollection<IImage> _huanSiImages;
        private ObservableCollection<IImage> _giftImages;
        private ObservableCollection<IImage> _currentImages;
        private DelegateCommand _selectPropCommand;
        private DelegateCommand _selectHuanSiCommand;
        private DelegateCommand _selectGiftCommand;

        public ObservableCollection<IImage> PropImages
        {
            get
            {
                if (_propImages == null)
                {
                    _propImages = new ObservableCollection<IImage>(ResourceImageReader.GetAllStoreDailyPropImages());
                }
                return _propImages;
            }
        }

        public ObservableCollection<IImage> HuanSiImages
        {
            get
            {
                if (_huanSiImages == null)
                {
                    _huanSiImages = new ObservableCollection<IImage>(ResourceImageReader.GetAllStoreDailyHuanSiImages());
                }
                return _huanSiImages;
            }
        }

        public ObservableCollection<IImage> GiftImages
        {
            get
            {
                if (_giftImages == null)
                {
                    _giftImages = new ObservableCollection<IImage>(ResourceImageReader.GetAllStoreDailyGiftImages());
                }
                return _giftImages;
            }
        }

        public ObservableCollection<IImage> CurrentImages
        {
            get
            {
                if (_currentImages == null)
                {
                    _currentImages = PropImages;
                }
                return _currentImages;
            }
            set
            {
                SetProperty(ref _currentImages, value);
            }
        }

        public DelegateCommand SelectPropCommand =>
            _selectPropCommand ??= new DelegateCommand(SelectProp);

        public DelegateCommand SelectHuanSiCommand =>
            _selectHuanSiCommand ??= new DelegateCommand(SelectHuanSi);

        public DelegateCommand SelectGiftCommand =>
            _selectGiftCommand ??= new DelegateCommand(SelectGift);

        public void SelectProp()
        {
            CurrentImages = PropImages;
        }

        public void SelectHuanSi()
        {
            CurrentImages = HuanSiImages;
        }

        public void SelectGift()
        {
            CurrentImages = GiftImages;
        }
    }
}
