using System.Collections.Generic;
using System.Windows;
using Mmu.LolTimer.Areas.Application.Services;
using Mmu.LolTimer.Areas.Domain.SummonerSpells.Models;
using Mmu.LolTimer.Areas.Domain.SummonerSpells.Services;

namespace Mmu.LolTimer.Areas.WpfUI.FlashTimers
{
    public partial class ConfigureSummonersView : Window
    {
        private readonly ITimeableElementConfigurator _configurator;
        private readonly IHookService _hookService;
        private readonly ISummonerSpellFactory _summonerSpellFactory;

        public ConfigureSummonersView(
            ISummonerSpellFactory summonerSpellFactory,
            ITimeableElementConfigurator configurator,
            IHookService hookService)
        {
            _summonerSpellFactory = summonerSpellFactory;
            _configurator = configurator;
            _hookService = hookService;
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

            var timerView = new FlashTimerView();
            timerView.Initialize(summonerSpells);
            Visibility = Visibility.Hidden;
            _configurator.Initialize(summonerSpells);
            _hookService.Hook();

            timerView.Show();
        }
    }
}