using Mmu.LolTimer.Areas.Application.Hooking.KeyboardHooking.Domain.Models.Inputs;

namespace Mmu.LolTimer.Areas.Application.Hooking.KeyboardHooking.Domain.Factories.Servants
{
    internal interface IKeyboardInputLocksFactory
    {
        KeyboardInputLocks Create();
    }
}