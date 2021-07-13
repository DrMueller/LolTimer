using System.Collections.Generic;
using Mmu.LolTimer.Areas.Domain.Common.Models;

namespace Mmu.LolTimer.Areas.Application.TimableElements.Services.Implementation
{
    public class TimeableElementConfigurator : ITimeableElementConfigurator
    {
        public IReadOnlyCollection<ITimeableElement> Elements { get; private set; }

        public void Initialize(IReadOnlyCollection<ITimeableElement> elements)
        {
            Elements = elements;
        }
    }
}