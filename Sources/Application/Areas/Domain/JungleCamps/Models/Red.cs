using System;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models.Inputs;

namespace Mmu.LolTimer.Areas.Domain.JungleCamps.Models
{
    public class Red : JungleCamp
    {
        public override KeyboardInputKey InputKey => KeyboardInputKey.F2;

        public override int SortKey => 1;

        public Red() : base(TimeSpan.FromMinutes(5))
        {
        }

        protected override string GetCampName()
        {
            return "Red";
        }
    }
}