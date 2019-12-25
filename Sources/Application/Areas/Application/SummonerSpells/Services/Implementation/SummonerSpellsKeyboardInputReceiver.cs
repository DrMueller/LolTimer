using System.Linq;
using System.Threading.Tasks;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models.Configurations;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models.Inputs;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Services;

namespace Mmu.LolTimer.Areas.Application.SummonerSpells.Services.Implementation
{
    public class SummonerSpellsKeyboardInputReceiver : IKeyboardInputReceiver
    {
        private readonly ISummonerSpellsConfigurator _configurator;

        public KeyboardEventConfiguration Configuration
        {
            get
            {
                var keys = _configurator.SummonerSpells.Select(f => f.InputKey).ToArray();
                var inputKeyConfig = new KeyboardInputKeyConfiguration(keys);
                var config = new KeyboardEventConfiguration(
                    inputKeyConfig,
                    ModifierConfiguration.CreateNotApplibable(),
                    LockConfiguration.CreateNotApplicable());

                return config;
            }
        }

        public SummonerSpellsKeyboardInputReceiver(ISummonerSpellsConfigurator configurator)
        {
            _configurator = configurator;
        }

        public Task ReceiveAsync(KeyboardInput input)
        {
            _configurator
                .SummonerSpells
                .Where(jc => jc.InputKey == input.InputKey)
                .ForEach(jc => jc.StartTimer());

            return Task.CompletedTask;
        }
    }
}