using System.Collections.Generic;
using Mmu.LolTimer.Areas.Domain.Common.Models;

namespace Mmu.LolTimer.Areas.Application.Services
{
    public interface ITimeableElementConfigurator
    {
        IReadOnlyCollection<ITimeableElement> Elements { get; }

        void Initialize(IReadOnlyCollection<ITimeableElement> elements);
    }
}