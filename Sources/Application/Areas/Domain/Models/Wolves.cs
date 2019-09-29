using System;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models.Inputs;

namespace Mmu.LolTimer.Areas.Domain.Models
{
    public class Wolves : JungleCamp
    {
        public override KeyboardInputKey InputKey => KeyboardInputKey.F4;

        public override int SortKey => 3;

        public Wolves() : base(TimeSpan.FromSeconds(150))
        {
        }

        protected override string GetCampName()
        {
            return "Wolves";
        }
    }
}