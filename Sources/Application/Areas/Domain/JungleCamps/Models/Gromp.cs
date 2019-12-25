using System;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models.Inputs;

namespace Mmu.LolTimer.Areas.Domain.JungleCamps.Models
{
    public class Gromp : JungleCamp
    {
        public override KeyboardInputKey InputKey => KeyboardInputKey.F6;

        public override int SortKey => 5;

        public Gromp() : base(TimeSpan.FromSeconds(150))
        {
        }

        protected override string GetCampName()
        {
            return "Gromp";
        }
    }
}