using System;
using System.Linq;
using System.Threading.Tasks;
using Mmu.LolTimer.Areas.Domain.Models;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models.Configurations;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models.Inputs;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Services;

namespace Mmu.LolTimer.Areas.WindowsNative.Receivers
{
    public class KeyboardInputReceiver : IKeyboardInputReceiver
    {
        private static readonly Lazy<KeyboardEventConfiguration> _config = new Lazy<KeyboardEventConfiguration>(KeyboardEventConfiguration.CreateForAllEvents);
        private readonly JungleCamp[] _jungleCamps;

        public KeyboardEventConfiguration Configuration => _config.Value;

        public KeyboardInputReceiver(JungleCamp[] jungleCamps)
        {
            _jungleCamps = jungleCamps;
        }

        public Task ReceiveAsync(KeyboardInput input)
        {
            _jungleCamps
                .Where(jc => jc.InputKey == input.InputKey)
                .ForEach(jc => jc.StartTimer());

            return Task.CompletedTask;
        }
    }
}