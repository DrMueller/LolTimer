using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Mmu.LolTimer.Areas.Application.Services;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Factories;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.WindowsNative.Models;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.WindowsNative.Services;

namespace Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Services.Implementation
{
    [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Instantiated by StrcutureMap")]
    internal class KeyboardHookService : IKeyboardHookService
    {
        private readonly IKeyboardInputFactory _inputFactory;
        private readonly ITimeableElementConfigurator _configurator;
        private readonly INativeKeyboardHookService _nativeKeyboardHookService;

        public KeyboardHookService(
            INativeKeyboardHookService nativeKeyboardHookService,
            IKeyboardInputFactory inputFactory,
            ITimeableElementConfigurator configurator)
        {
            _nativeKeyboardHookService = nativeKeyboardHookService;
            _inputFactory = inputFactory;
            _configurator = configurator;
        }

        public void HookKeyboard()
        {
            _nativeKeyboardHookService.Hook(OnNativeKeyboardInput);
        }

        private void OnNativeKeyboardInput(NativeKeyboardInput nativeKeyboardInput)
        {
            var keyboardInput = _inputFactory.Create(nativeKeyboardInput);
            _configurator.Elements.SingleOrDefault(f => f.InputKey == keyboardInput.InputKey)?.StartTimer();
        }
    }
}