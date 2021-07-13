using Mmu.LolTimer.Areas.Application.Hooking.KeyboardHooking.Domain.Models.Inputs;

namespace Mmu.LolTimer.Areas.Domain.Common.Models
{
    public interface ITimeableElement
    {
        KeyboardInputKey InputKey { get; }

        void StartTimer();
    }
}