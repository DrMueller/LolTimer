using System.Collections.Generic;
using System.Linq;
using Mmu.LolTimer.Areas.Domain.Models;

namespace Mmu.LolTimer.Areas.Domain.Services.Implementation
{
    public class JungleCampFactory : IJungleCampFactory
    {
        private readonly JungleCamp[] _jungleCamps;

        public JungleCampFactory(JungleCamp[] jungleCamps)
        {
            _jungleCamps = jungleCamps;
        }

        public IReadOnlyCollection<JungleCamp> CreateAll()
        {
            return _jungleCamps.OrderBy(f => f.SortKey).ToList();
        }
    }
}