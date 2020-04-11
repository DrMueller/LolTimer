using System.Linq;
using System.Threading.Tasks;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models.Configurations;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models.Inputs;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Services;

namespace Mmu.LolTimer.Areas.Application.Services.Implementation
{
    public class KeyboardInputReceiver : IKeyboardInputReceiver
    {
        private readonly ITimeableElementConfigurator _configurator;

        public KeyboardEventConfiguration Configuration
        {
            get
            {
                var keys = _configurator.Elements.Select(f => f.InputKey).ToArray();
                var inputKeyConfig = new KeyboardInputKeyConfiguration(keys);
                var config = new KeyboardEventConfiguration(
                    inputKeyConfig,
                    ModifierConfiguration.CreateNotApplibable(),
                    LockConfiguration.CreateNotApplicable());

                return config;
            }
        }

        public KeyboardInputReceiver(ITimeableElementConfigurator configurator)
        {
            _configurator = configurator;
        }

        public Task ReceiveAsync(KeyboardInput input)
        {
            _configurator
                .Elements
                .Where(jc => jc.InputKey == input.InputKey)
                .ForEach(jc => jc.StartTimer());

            return Task.CompletedTask;
        }
    }
}