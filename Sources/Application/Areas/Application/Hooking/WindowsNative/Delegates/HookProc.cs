using System;

namespace Mmu.LolTimer.Areas.Application.Hooking.WindowsNative.Delegates
{
    internal delegate IntPtr HookProc(int code, IntPtr wordParam, IntPtr longParam);
}