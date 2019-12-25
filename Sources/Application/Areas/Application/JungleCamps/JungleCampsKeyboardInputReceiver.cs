////using System.Linq;
////using System.Threading.Tasks;
////using Mmu.LolTimer.Areas.Domain.JungleCamps.Models;
////using Mmu.Mlh.LanguageExtensions.Areas.Collections;
////using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models.Configurations;
////using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models.Inputs;
////using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Services;

////namespace Mmu.LolTimer.Areas.Application.JungleCamps
////{
////    public class JungleCampsKeyboardInputReceiver : IKeyboardInputReceiver
////    {
////        private readonly JungleCamp[] _jungleCamps;

////        public KeyboardEventConfiguration Configuration
////        {
////            get
////            {
////                var keys = _jungleCamps.Select(f => f.InputKey).ToArray();
////                var inputKeyConfig = new KeyboardInputKeyConfiguration(keys);
////                var config = new KeyboardEventConfiguration(
////                    inputKeyConfig,
////                    ModifierConfiguration.CreateNotApplicable(),
////                    LockConfiguration.CreateNotApplicable());

////                return config;
////            }
////        }

////        public JungleCampsKeyboardInputReceiver(JungleCamp[] jungleCamps)
////        {
////            _jungleCamps = jungleCamps;
////        }

////        public Task ReceiveAsync(KeyboardInput input)
////        {
////            _jungleCamps
////                .Where(jc => jc.InputKey == input.InputKey)
////                .ForEach(jc => jc.StartTimer());

////            return Task.CompletedTask;
////        }
////    }
////}