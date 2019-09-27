using System;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models.Inputs;

namespace Mmu.LolTimer.Areas.Domain.Models
{
    public class Gromp : JungleCamp
    {
        public override KeyboardInputKey InputKey => KeyboardInputKey.F6;

        public Gromp() : base(TimeSpan.FromSeconds(90))
        {
        }

        protected override string GetCampName()
        {
            return "Gromp";
        }
    }
}