using Mmu.LolTimer.Areas.Application.Services;
using Mmu.LolTimer.Areas.Domain.JungleCamps.Models;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Services;
using StructureMap;

namespace Mmu.LolTimer.Infrastructure.DependencyInjection
{
    public class LolTimerRegistry : Registry
    {
        public LolTimerRegistry()
        {
            Scan(scanner =>
            {
                scanner.AssemblyContainingType<LolTimerRegistry>();
                scanner.AddAllTypesOf<JungleCamp>();

                scanner.AddAllTypesOf<IKeyboardInputReceiver>();

                scanner.WithDefaultConventions();
            });

            For<ITimeableElementConfigurator>().Singleton();
            For<IKeyboardInputReceiver>().Singleton();
            For<JungleCamp>().AlwaysUnique();
        }
    }
}