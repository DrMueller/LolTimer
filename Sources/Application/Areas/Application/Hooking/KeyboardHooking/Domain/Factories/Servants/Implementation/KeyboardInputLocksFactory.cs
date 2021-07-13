using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using Mmu.LolTimer.Areas.Application.Hooking.KeyboardHooking.Domain.Models.Inputs;
using Mmu.LolTimer.Areas.Application.Hooking.WindowsNative.Imports;

namespace Mmu.LolTimer.Areas.Application.Hooking.KeyboardHooking.Domain.Factories.Servants.Implementation
{
    [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Instantiated by StrcutureMap")]
    internal class KeyboardInputLocksFactory : IKeyboardInputLocksFactory
    {
        public KeyboardInputLocks Create()
        {
            var isCapsLockActive = Convert.ToBoolean(NativeMethods.GetKeyState(Keys.CapsLock)) & true;
            var isNumLockActive = Convert.ToBoolean(NativeMethods.GetKeyState(Keys.NumLock)) & true;
            var isScrolLLockActivate = Convert.ToBoolean(NativeMethods.GetKeyState(Keys.Scroll)) & true;

            return new KeyboardInputLocks(
                isScrolLLockActivate,
                isNumLockActive,
                isCapsLockActive);
        }
    }
}