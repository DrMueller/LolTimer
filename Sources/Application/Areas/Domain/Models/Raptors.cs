using System;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models.Inputs;

namespace Mmu.LolTimer.Areas.Domain.Models
{
    public class Raptors : JungleCamp
    {
        public override KeyboardInputKey InputKey => KeyboardInputKey.F3;

        public override int SortKey => 2;

        public Raptors() : base(TimeSpan.FromSeconds(150))
        {
        }

        protected override string GetCampName()
        {
            return "Raptors";
        }
    }
}