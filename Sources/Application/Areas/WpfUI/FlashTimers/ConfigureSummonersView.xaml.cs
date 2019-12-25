using System.Collections.Generic;
using System.Windows;
using Mmu.LolTimer.Areas.Application.SummonerSpells.Services;
using Mmu.LolTimer.Areas.Domain.SummonerSpells.Models;
using Mmu.LolTimer.Areas.Domain.SummonerSpells.Services;

namespace Mmu.LolTimer.Areas.WpfUI.FlashTimers
{
    public partial class ConfigureSummonersView : Window
    {
        private readonly ISummonerSpellsDisplayService _displayService;
        private readonly ISummonerSpellFactory _summonerSpellFactory;

        public ConfigureSummonersView(ISummonerSpellFactory summonerSpellFactory, ISummonerSpellsDisplayService displayService)
        {
            _summonerSpellFactory = summonerSpellFactory;
            _displayService = displayService;
            InitializeComponent();
        }

        private void StartTimers_Click(object sender, RoutedEventArgs e)
        {
            var summonerSpells = new List<SummonerSpell>
            {
                _summonerSpellFactory.CreateFlash(TxbSummoner1.Text, 0),
                _summonerSpellFactory.CreateFlash(TxbSummoner2.Text, 1),
                _summonerSpellFactory.CreateFlash(TxbSummoner3.Text, 2),
                _summonerSpellFactory.CreateFlash(TxbSummoner4.Text, 3),
                _summonerSpellFactory.CreateFlash(TxbSummoner5.Text, 4)
            };

            _displayService.Display(this, summonerSpells);
        }
    }
}