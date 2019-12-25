using System.Collections.Generic;
using Mmu.LolTimer.Areas.Domain.SummonerSpells.Models;

namespace Mmu.LolTimer.Areas.Application.SummonerSpells.Services.Implementation
{
    public class SummonerSpellsConfigurator : ISummonerSpellsConfigurator
    {
        public IReadOnlyCollection<SummonerSpell> SummonerSpells { get; private set; }

        public void Initialize(IReadOnlyCollection<SummonerSpell> summonerSpells)
        {
            SummonerSpells = summonerSpells;
        }
    }
}