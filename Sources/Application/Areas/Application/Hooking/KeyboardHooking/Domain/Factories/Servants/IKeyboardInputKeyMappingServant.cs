using System.Windows.Forms;
using Mmu.LolTimer.Areas.Application.Hooking.KeyboardHooking.Domain.Models.Inputs;

namespace Mmu.LolTimer.Areas.Application.Hooking.KeyboardHooking.Domain.Factories.Servants
{
    internal interface IKeyboardInputKeyMappingServant
    {
        KeyboardInputKey MapFromNativeKey(Keys key);
    }
}