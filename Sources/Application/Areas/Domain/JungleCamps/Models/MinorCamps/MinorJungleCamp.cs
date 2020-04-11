using System;

namespace Mmu.LolTimer.Areas.Domain.JungleCamps.Models.MinorCamps
{
    public abstract class MinorJungleCamp : JungleCamp
    {
        protected MinorJungleCamp() : base(TimeSpan.FromMinutes(2))
        {
        }
    }
}