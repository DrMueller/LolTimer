using System;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models.Inputs;

namespace Mmu.LolTimer.Areas.Domain.Models
{
    public class Raptors : JungleCamp
    {
        private readonly Lazy<CampTimer> _lazyCamptimer = new Lazy<CampTimer>(
            () => new CampTimer(TimeSpan.FromSeconds(90)));

        public override KeyboardInputKey InputKey => KeyboardInputKey.F1;
        protected override CampTimer CampTimer => _lazyCamptimer.Value;

        protected override string GetCampName()
        {
            return "Raptors";
        }
    }
}