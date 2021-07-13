using Mmu.LolTimer.Areas.Application.Hooking.Common.Models.Inputs;

namespace Mmu.LolTimer.Areas.Application.Hooking.Common.Factories
{
    public interface IInputFactory<TInput, TNativeInput>
        where TInput : IInput
        where TNativeInput : INativeInput
    {
        TInput Create(TNativeInput nativeInput);
    }
}