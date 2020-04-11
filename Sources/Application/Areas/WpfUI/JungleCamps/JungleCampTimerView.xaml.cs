using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Mmu.LolTimer.Areas.Application.Services;
using Mmu.LolTimer.Areas.Domain.JungleCamps.Models;
using Mmu.LolTimer.Areas.Domain.JungleCamps.Services;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;

namespace Mmu.LolTimer.Areas.WpfUI.JungleCamps
{
    public partial class JungleCampTimerView : Window, IDisposable
    {
        private readonly IReadOnlyCollection<JungleCamp> _allCamps;
        private bool _disposed;
        public IReadOnlyCollection<JungleCamp> EnemyJungleCamps { get; }
        public IReadOnlyCollection<JungleCamp> OwnJungleCamps { get; }

        public JungleCampTimerView(
            IJungleCampFactory jungleCampFactory,
            ITimeableElementConfigurator configurator,
            IHookService hookService)
        {
            InitializeComponent();
            DataContext = this;

            OwnJungleCamps = jungleCampFactory.CreateAll(JungleCampPosition.Own);
            EnemyJungleCamps = jungleCampFactory.CreateAll(JungleCampPosition.Enemy);
            _allCamps = OwnJungleCamps.Concat(EnemyJungleCamps).ToList();

            Visibility = Visibility.Hidden;
            configurator.Initialize(_allCamps);
            hookService.Hook();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposedByCode)
        {
            if (_disposed)
            {
                return;
            }

            if (disposedByCode)
            {
                _allCamps.ForEach(jc => jc.Dispose());
            }

            _disposed = true;
        }

        ~JungleCampTimerView()
        {
            Dispose(false);
        }
    }
}