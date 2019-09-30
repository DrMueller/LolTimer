using System;
using System.Collections.Generic;
using System.Windows;
using Mmu.LolTimer.Areas.Domain.Models;
using Mmu.LolTimer.Areas.Domain.Services;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;

namespace Mmu.LolTimer.Areas.WpfUI
{
    public partial class MainView : Window, IDisposable
    {
        private bool _disposed;
        public IReadOnlyCollection<JungleCamp> JungleCamps { get; }

        public MainView(IJungleCampFactory jungleCampFactory)
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

        protected override void OnActivated(EventArgs e)
        {
            Topmost = true;
        }

        ~MainView()
        {
            Dispose(false);
        }
    }
}