using System;
using System.Collections.Generic;
using System.Windows;
using Mmu.LolTimer.Areas.Domain.JungleCamps.Models;
using Mmu.LolTimer.Areas.Domain.JungleCamps.Services;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;

namespace Mmu.LolTimer.Areas.WpfUI.JungleCamps
{
    public partial class JungleCampTimerView : Window, IDisposable
    {
        private bool _disposed;
        public IReadOnlyCollection<JungleCamp> JungleCamps { get; }

        public JungleCampTimerView(IJungleCampFactory jungleCampFactory)
        {
            InitializeComponent();
            DataContext = this;
            JungleCamps = jungleCampFactory.CreateAll();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposedByCode)
        {
            if (!_disposed)
            {
                if (disposedByCode)
                {
                    JungleCamps.ForEach(jc => jc.Dispose());
                }

                _disposed = true;
            }
        }

        ~JungleCampTimerView()
        {
            Dispose(false);
        }
    }
}