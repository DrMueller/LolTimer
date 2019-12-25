using System.Windows;
using Mmu.LolTimer.Areas.WpfUI.FlashTimers;
using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Models;
using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Services;
using StructureMap;

namespace Mmu.LolTimer
{
    public partial class App : Application
    {
        private Container _container;

        protected override void OnExit(ExitEventArgs e)
        {
            _container.Dispose();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var containerConfig = ContainerConfiguration.CreateFromAssembly(typeof(App).Assembly);
            _container = ContainerInitializationService.CreateInitializedContainer(containerConfig);

            var wn = _container.GetInstance<ConfigureSummonersView>();
            wn.Show();
        }
    }
}