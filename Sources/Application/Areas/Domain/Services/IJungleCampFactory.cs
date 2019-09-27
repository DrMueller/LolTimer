using System.Collections.Generic;
using Mmu.LolTimer.Areas.Domain.Models;

namespace Mmu.LolTimer.Areas.Domain.Services
{
    public interface IJungleCampFactory
    {
        IReadOnlyCollection<JungleCamp> CreateAll();
    }
}