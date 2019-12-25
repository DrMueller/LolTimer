using System.Collections.Generic;
using System.Windows;
using Mmu.LolTimer.Areas.Domain.SummonerSpells.Models;

namespace Mmu.LolTimer.Areas.Application.SummonerSpells.Services
{
    public interface ISummonerSpellsDisplayService
    {
        void Display(Window currentWindow, IReadOnlyCollection<SummonerSpell> summonerSpells);
    }
}