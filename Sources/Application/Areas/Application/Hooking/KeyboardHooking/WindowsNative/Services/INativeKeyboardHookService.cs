using System;
using Mmu.LolTimer.Areas.Application.Hooking.KeyboardHooking.WindowsNative.Models;

namespace Mmu.LolTimer.Areas.Application.Hooking.KeyboardHooking.WindowsNative.Services
{
    internal interface INativeKeyboardHookService
    {
        void Hook(Action<NativeKeyboardInput> onKeyboardInput);
    }
}