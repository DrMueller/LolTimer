using System;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models.Inputs;

namespace Mmu.LolTimer.Areas.Domain.Models
{
    public class Krugs : JungleCamp
    {
        public override KeyboardInputKey InputKey => KeyboardInputKey.F1;

        public override int SortKey => 0;

        public Krugs() : base(TimeSpan.FromSeconds(90))
        {
        }

        protected override string GetCampName()
        {
            return "Krugs";
        }
    }
}