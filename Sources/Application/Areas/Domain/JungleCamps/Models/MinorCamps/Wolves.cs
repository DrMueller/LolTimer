using Mmu.LolTimer.Areas.Application.Hooking.KeyboardHooking.Domain.Models.Inputs;

namespace Mmu.LolTimer.Areas.Domain.JungleCamps.Models.MinorCamps
{
    public class Wolves : MinorJungleCamp
    {
        public override KeyboardInputKey InputKey => Position == JungleCampPosition.Own ? KeyboardInputKey.F4 : KeyboardInputKey.F10;

        protected override string GetCampName()
        {
            return "Wolves";
        }

        protected override int GetInitialSortKey()
        {
            return 3;
        }
    }
}