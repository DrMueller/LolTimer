using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models.Inputs;

namespace Mmu.LolTimer.Areas.Domain.JungleCamps.Models.Buffs
{
    public class Blue : BuffJungleCamp
    {
        public override KeyboardInputKey InputKey => Position == JungleCampPosition.Own ? KeyboardInputKey.F5 : KeyboardInputKey.F11;

        protected override string GetCampName()
        {
            return "Blue";
        }

        protected override int GetInitialSortKey()
        {
            return 4;
        }
    }
}