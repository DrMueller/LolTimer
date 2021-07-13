using Mmu.LolTimer.Areas.Application.Services;
using Mmu.LolTimer.Areas.Domain.JungleCamps.Models;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Factories;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Factories.Implementation;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Factories.Servants;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Factories.Servants.Implementation;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Services;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Services.Implementation;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.WindowsNative.Services;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.WindowsNative.Services.Implementation;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.WindowsNative.Services;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.WindowsNative.Services.Implementation;
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

            // Hooking - Keyboard
            For<INativeKeyboardHookService>().Use<NativeKeyboardHookService>().Transient();
            For<IKeyboardHookService>().Use<KeyboardHookService>().Transient();
            For<IKeyboardInputFactory>().Use<KeyboardInputFactory>().Singleton();
            For<IKeyboardInputKeyMappingServant>().Use<KeyboardInputKeyMappingServant>();
            For<IKeyboardInputModifiersFactory>().Use<KeyboardInputModifiersFactory>();
            For<IKeyboardInputLocksFactory>().Use<KeyboardInputLocksFactory>();

            // Hooking - WindowsNative
            For<IHookService>().Use<HookService>().AlwaysUnique();
        }
    }
}