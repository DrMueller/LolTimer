using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models.Inputs;

namespace Mmu.LolTimer.Areas.Domain.Models
{
    public abstract class JungleCamp
    {
        public string Descripton
        {
            get
            {
                return $"{GetCampName()} {InputKey}";
            }
        }

        public void StartTimer()
        {
            CampTimer.Start();
        }

        public abstract KeyboardInputKey InputKey { get; }

        protected abstract string GetCampName();

        protected abstract CampTimer CampTimer { get; }
    }
}