using System;

namespace Mmu.LolTimer.Areas.Domain.JungleCamps.Models.Buffs
{
    public abstract class BuffJungleCamp : JungleCamp
    {
        protected BuffJungleCamp() : base(TimeSpan.FromMinutes(5))
        {
        }
    }
}