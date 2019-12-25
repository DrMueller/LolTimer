using System.Collections.Generic;
using System.Windows;
using Mmu.LolTimer.Areas.Application.Common.Services;
using Mmu.LolTimer.Areas.Domain.SummonerSpells.Models;
using Mmu.LolTimer.Areas.WpfUI.FlashTimers;

namespace Mmu.LolTimer.Areas.Application.SummonerSpells.Services.Implementation
{
    public class SummonerSpellsDisplayService : ISummonerSpellsDisplayService
    {
        private readonly ISummonerSpellsConfigurator _configurator;
        private readonly FlashTimerView _flashTimerView;
        private readonly IHookService _hookService;

        public SummonerSpellsDisplayService(
            FlashTimerView flashTimerView,
            IHookService hookService,
            ISummonerSpellsConfigurator configurator)
        {
            _flashTimerView = flashTimerView;
            _hookService = hookService;
            _configurator = configurator;
        }

        public void Display(
            Window currentWindow,
            IReadOnlyCollection<SummonerSpell> summonerSpells)
        {
            _flashTimerView.Initialize(summonerSpells);

            _configurator.Initialize(summonerSpells);
            _hookService.Hook();
            currentWindow.Visibility = Visibility.Hidden;

            _flashTimerView.Topmost = true;
            _flashTimerView.Show();
        }
    }
}