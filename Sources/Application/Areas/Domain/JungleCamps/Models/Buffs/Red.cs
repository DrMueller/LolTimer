using Mmu.LolTimer.Areas.Application.Hooking.KeyboardHooking.Domain.Models.Inputs;

namespace Mmu.LolTimer.Areas.Domain.JungleCamps.Models.Buffs
{
    public class Red : BuffJungleCamp
    {
        public override KeyboardInputKey InputKey => Position == JungleCampPosition.Own ? KeyboardInputKey.F2 : KeyboardInputKey.F8;

        protected override string GetCampName()
        {
            return "Red";
        }

        protected override int GetInitialSortKey()
        {
            return 1;
        }
    }
}