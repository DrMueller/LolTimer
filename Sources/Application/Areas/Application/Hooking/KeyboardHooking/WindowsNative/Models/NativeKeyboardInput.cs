using System.Windows.Forms;
using Mmu.LolTimer.Areas.Application.Hooking.Common.Models.Inputs;

namespace Mmu.LolTimer.Areas.Application.Hooking.KeyboardHooking.WindowsNative.Models
{
    public class NativeKeyboardInput : INativeInput
    {
        public NativeKeyboardInputDirection Direction { get; }
        public Keys Key { get; }

        public NativeKeyboardInput(Keys key, NativeKeyboardInputDirection direction)
        {
            Key = key;
            Direction = direction;
        }
    }
}