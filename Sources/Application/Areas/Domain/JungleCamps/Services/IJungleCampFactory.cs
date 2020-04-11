using System.Collections.Generic;
using Mmu.LolTimer.Areas.Domain.JungleCamps.Models;

namespace Mmu.LolTimer.Areas.Domain.JungleCamps.Services
{
    public interface IJungleCampFactory
    {
        IReadOnlyCollection<JungleCamp> CreateAll(JungleCampPosition position);
    }
}