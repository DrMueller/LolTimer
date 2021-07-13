using System;
using Mmu.LolTimer.Areas.Application.Hooking.WindowsNative.Delegates;
using Mmu.LolTimer.Areas.Application.Hooking.WindowsNative.Enums;

namespace Mmu.LolTimer.Areas.Application.Hooking.WindowsNative.Services
{
    internal interface IHookService : IDisposable
    {
        void Hook(HookType hookType, HookReceived hookReceivedCallback);
    }
}