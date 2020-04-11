using System.Collections.Generic;
using System.Linq;
using Mmu.LolTimer.Areas.Domain.JungleCamps.Models;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;
using Mmu.Mlh.ServiceProvisioning.Areas.Provisioning.Services;

namespace Mmu.LolTimer.Areas.Domain.JungleCamps.Services.Implementation
{
    public class JungleCampFactory : IJungleCampFactory
    {
        private readonly IServiceLocator _serviceLocator;

        public JungleCampFactory(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        public IReadOnlyCollection<JungleCamp> CreateAll(JungleCampPosition position)
        {
            var camps = _serviceLocator.GetAllServices<JungleCamp>();
            camps.ForEach(f => f.InitializePosition(position));

            camps = camps.OrderBy(f => f.SortKey).ToList();
            return camps;
        }
    }
}