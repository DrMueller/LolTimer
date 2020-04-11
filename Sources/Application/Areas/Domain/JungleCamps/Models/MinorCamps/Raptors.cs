using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models.Inputs;

namespace Mmu.LolTimer.Areas.Domain.JungleCamps.Models.MinorCamps
{
    public class Raptors : MinorJungleCamp
    {
        public override KeyboardInputKey InputKey => Position == JungleCampPosition.Own ? KeyboardInputKey.F3 : KeyboardInputKey.F9;

        protected override string GetCampName()
        {
            return "Raptors";
        }

        protected override int GetInitialSortKey()
        {
            return 2;
        }
    }
}