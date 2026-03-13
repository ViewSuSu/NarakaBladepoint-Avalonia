using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using NarakaBladepoint.App.Shell;
using NarakaBladepoint.Modules;
using NarakaBladepoint.Resources;
using NarakaBladepoint.Shared.Services;

namespace NarakaBladepoint.App
{
    public partial class App : Framework.Core.Bases.PrismApplicationBase
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
            ImageResourceProvider.RegisterAll(this);
            base.Initialize();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<MainWindow>();
            containerRegistry.Register<MainWindowViewModel>();
            containerRegistry.RegisterAppLayer();
            containerRegistry.RegisterSharedLayer();
            containerRegistry.RegisterModuleLayer();
        }

        protected override Window CreateShellExecute()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return ModuleCatalogConfigManager.ConfigAll();
        }
    }
}
