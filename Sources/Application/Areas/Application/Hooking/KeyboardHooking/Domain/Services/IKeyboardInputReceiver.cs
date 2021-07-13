using Mmu.LolTimer.Areas.Application.Hooking.Common.Services;
using Mmu.LolTimer.Areas.Application.Hooking.KeyboardHooking.Domain.Models.Configurations;
using Mmu.LolTimer.Areas.Application.Hooking.KeyboardHooking.Domain.Models.Inputs;

namespace Mmu.LolTimer.Areas.Application.Hooking.KeyboardHooking.Domain.Services
{
    public interface IKeyboardInputReceiver : IInputReceiver<KeyboardInput, KeyboardEventConfiguration>
    {
    }
}