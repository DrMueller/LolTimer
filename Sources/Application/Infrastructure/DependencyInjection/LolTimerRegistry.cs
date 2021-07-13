using Mmu.LolTimer.Areas.Application.Hooking.KeyboardHooking.Domain.Factories;
using Mmu.LolTimer.Areas.Application.Hooking.KeyboardHooking.Domain.Factories.Implementation;
using Mmu.LolTimer.Areas.Application.Hooking.KeyboardHooking.Domain.Factories.Servants;
using Mmu.LolTimer.Areas.Application.Hooking.KeyboardHooking.Domain.Factories.Servants.Implementation;
using Mmu.LolTimer.Areas.Application.Hooking.KeyboardHooking.Domain.Services;
using Mmu.LolTimer.Areas.Application.Hooking.KeyboardHooking.Domain.Services.Implementation;
using Mmu.LolTimer.Areas.Application.Hooking.KeyboardHooking.WindowsNative.Services;
using Mmu.LolTimer.Areas.Application.Hooking.KeyboardHooking.WindowsNative.Services.Implementation;
using Mmu.LolTimer.Areas.Application.Hooking.WindowsNative.Services;
using Mmu.LolTimer.Areas.Application.Hooking.WindowsNative.Services.Implementation;
using Mmu.LolTimer.Areas.Application.TimableElements.Services;
using Mmu.LolTimer.Areas.Domain.JungleCamps.Models;
using StructureMap;

namespace Mmu.LolTimer.Infrastructure.DependencyInjection
{
    public class LolTimerRegistry : Registry
    {
        public LolTimerRegistry()
        {
            Scan(
                scanner =>
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