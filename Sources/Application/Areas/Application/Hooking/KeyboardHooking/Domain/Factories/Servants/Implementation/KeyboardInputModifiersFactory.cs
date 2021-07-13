using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using Mmu.LolTimer.Areas.Application.Hooking.KeyboardHooking.Domain.Models.Inputs;
using Mmu.LolTimer.Areas.Application.Hooking.WindowsNative.Imports;

namespace Mmu.LolTimer.Areas.Application.Hooking.KeyboardHooking.Domain.Factories.Servants.Implementation
{
    [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Instantiated by StrcutureMap")]
    internal class KeyboardInputModifiersFactory : IKeyboardInputModifiersFactory
    {
        public KeyboardInputModifiers Create()
        {
            var isShiftPressed = CheckIfActive(NativeMethods.GetKeyState(Keys.ShiftKey));
            var isCtrlpressed = CheckIfActive(NativeMethods.GetKeyState(Keys.ControlKey));
            var isAltpressed = CheckIfActive(NativeMethods.GetKeyState(Keys.Menu));

            return new KeyboardInputModifiers(
                isCtrlpressed,
                isAltpressed,
                isShiftPressed);
        }

        private static bool CheckIfActive(short state)
        {
            return state > 1 || state < -1;
        }
    }
}