using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Mmu.LolTimer.Areas.Application.Hooking.KeyboardHooking.Domain.Factories;
using Mmu.LolTimer.Areas.Application.Hooking.KeyboardHooking.WindowsNative.Models;
using Mmu.LolTimer.Areas.Application.Hooking.KeyboardHooking.WindowsNative.Services;
using Mmu.LolTimer.Areas.Application.TimableElements.Services;

namespace Mmu.LolTimer.Areas.Application.Hooking.KeyboardHooking.Domain.Services.Implementation
{
    [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Instantiated by StrcutureMap")]
    internal class KeyboardHookService : IKeyboardHookService
    {
        private readonly ITimeableElementConfigurator _configurator;
        private readonly IKeyboardInputFactory _inputFactory;
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