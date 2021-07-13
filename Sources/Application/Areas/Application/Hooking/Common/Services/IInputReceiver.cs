using System.Threading.Tasks;
using Mmu.LolTimer.Areas.Application.Hooking.Common.Models.Configurations;
using Mmu.LolTimer.Areas.Application.Hooking.Common.Models.Inputs;

namespace Mmu.LolTimer.Areas.Application.Hooking.Common.Services
{
    public interface IInputReceiver<TInput, TConfig>
        where TInput : IInput
        where TConfig : IEventConfiguration
    {
        TConfig Configuration { get; }

        Task ReceiveAsync(TInput input);
    }
}