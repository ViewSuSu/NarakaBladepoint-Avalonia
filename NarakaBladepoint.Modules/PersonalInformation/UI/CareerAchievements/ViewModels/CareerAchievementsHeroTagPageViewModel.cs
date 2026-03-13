using System.Collections.ObjectModel;
using System.Windows.Input;
using Avalonia.Input;
using Avalonia.Media;
using NarakaBladepoint.Framework.Core.Bases.ViewModels;
using NarakaBladepoint.Resources;

namespace NarakaBladepoint.Modules.PersonalInformation.UI.CareerAchievements.ViewModels
{
    internal class CareerAchievementsHeroTagPageViewModel : ViewModelBase
    {
        private readonly Random _rnd = new();

        public ObservableCollection<IImage> AllItems { get; } = new();
        public ObservableCollection<IImage> PersonalItems { get; } = new();
        public ObservableCollection<IImage> CombatItems { get; } = new();
        public ObservableCollection<IImage> ExplorationItems { get; } = new();
        public ObservableCollection<IImage> DivineRoadItems { get; } = new();
        public ObservableCollection<IImage> EntertainmentItems { get; } = new();
        public ObservableCollection<IImage> LimitedItems { get; } = new();

        public ICommand SelectItemCommand { get; }

        public CareerAchievementsHeroTagPageViewModel()
        {
            // load all achievement images
            var list = ResourceImageReader.GetAllPersonalInfoAchievementImages();
            foreach (var img in list)
            {
                AllItems.Add(img);
            }

            // generate fake categorized lists by randomly selecting from AllItems
            PopulateRandomCategory(PersonalItems);
            PopulateRandomCategory(CombatItems);
            PopulateRandomCategory(ExplorationItems);
            PopulateRandomCategory(DivineRoadItems);
            PopulateRandomCategory(EntertainmentItems);
            PopulateRandomCategory(LimitedItems);

            SelectItemCommand = new DelegateCommand<object>(ExecuteSelectItem);
        }

        private void PopulateRandomCategory(ObservableCollection<IImage> target)
        {
            target.Clear();
            var count = _rnd.Next(4, Math.Max(4, AllItems.Count / 2));
            for (int i = 0; i < count; i++)
            {
                var idx = _rnd.Next(0, AllItems.Count);
                target.Add(AllItems[idx]);
            }
        }

        private void ExecuteSelectItem(object obj)
        {
            // placeholder for selection handling
        }
    }
}
