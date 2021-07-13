using Mmu.LolTimer.Areas.Application.Hooking.Common.Factories;
using Mmu.LolTimer.Areas.Application.Hooking.KeyboardHooking.Domain.Models.Inputs;
using Mmu.LolTimer.Areas.Application.Hooking.KeyboardHooking.WindowsNative.Models;

namespace Mmu.LolTimer.Areas.Application.Hooking.KeyboardHooking.Domain.Factories
{
    internal interface IKeyboardInputFactory : IInputFactory<KeyboardInput, NativeKeyboardInput>
    {
    }
}