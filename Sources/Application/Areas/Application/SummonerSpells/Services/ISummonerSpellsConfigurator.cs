using System.Collections.Generic;
using Mmu.LolTimer.Areas.Domain.SummonerSpells.Models;

namespace Mmu.LolTimer.Areas.Application.SummonerSpells.Services
{
    public interface ISummonerSpellsConfigurator
    {
        IReadOnlyCollection<SummonerSpell> SummonerSpells { get; }

        void Initialize(IReadOnlyCollection<SummonerSpell> summonerSpells);
    }
}