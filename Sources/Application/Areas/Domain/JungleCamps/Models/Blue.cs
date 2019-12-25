using System;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models.Inputs;

namespace Mmu.LolTimer.Areas.Domain.JungleCamps.Models
{
    public class Blue : JungleCamp
    {
        public override KeyboardInputKey InputKey => KeyboardInputKey.F5;

        public override int SortKey => 4;

        public Blue() : base(TimeSpan.FromMinutes(5))
        {
        }

        protected override string GetCampName()
        {
            return "Blue";
        }
    }
}