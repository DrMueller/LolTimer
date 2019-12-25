using Mmu.LolTimer.Areas.Domain.SummonerSpells.Models;

namespace Mmu.LolTimer.Areas.Domain.SummonerSpells.Services
{
    public interface ISummonerSpellFactory
    {
        SummonerSpell CreateFlash(string summonerName, int sortOrder);
    }
}