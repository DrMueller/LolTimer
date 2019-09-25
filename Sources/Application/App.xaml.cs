using System.Windows;
using Mmu.LolTimer.Areas.WpfUI;
using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Models;
using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Services;

namespace Mmu.LolTimer
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var containerConfig = ContainerConfiguration.CreateFromAssembly(typeof(App).Assembly);
            var container = ContainerInitializationService.CreateInitializedContainer(containerConfig);

            var wn = container.GetInstance<MainView>();
            wn.Show();
        }
    }
}