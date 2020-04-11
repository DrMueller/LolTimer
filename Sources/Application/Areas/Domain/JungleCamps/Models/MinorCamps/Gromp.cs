using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models.Inputs;

namespace Mmu.LolTimer.Areas.Domain.JungleCamps.Models.MinorCamps
{
    public class Gromp : MinorJungleCamp
    {
        public override KeyboardInputKey InputKey => Position == JungleCampPosition.Own ? KeyboardInputKey.F6 : KeyboardInputKey.F12;

        protected override string GetCampName()
        {
            return "Gromp";
        }

        protected override int GetInitialSortKey()
        {
            return 5;
        }
    }
}