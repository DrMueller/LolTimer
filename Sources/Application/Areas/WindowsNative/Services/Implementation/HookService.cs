using System;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Services;

namespace Mmu.LolTimer.Areas.WindowsNative.Services.Implementation
{
    public class HookService : IHookService
    {
        private readonly IKeyboardHookService _keyBoardHookService;

        public HookService(IKeyboardHookService keyBoardHookService)
        {
            _keyBoardHookService = keyBoardHookService;
        }

        public void Hook()
        {
            _keyBoardHookService.HookKeyboard();
        }
    }
}