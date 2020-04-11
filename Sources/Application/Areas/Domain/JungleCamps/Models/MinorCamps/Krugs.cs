using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models.Inputs;

namespace Mmu.LolTimer.Areas.Domain.JungleCamps.Models.MinorCamps
{
    public class Krugs : MinorJungleCamp
    {
        public override KeyboardInputKey InputKey => Position == JungleCampPosition.Own ? KeyboardInputKey.F1 : KeyboardInputKey.F7;

        protected override string GetCampName()
        {
            return "Krugs";
        }

        protected override int GetInitialSortKey()
        {
            return 0;
        }
    }
}