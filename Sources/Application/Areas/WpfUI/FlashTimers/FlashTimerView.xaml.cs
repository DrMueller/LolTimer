using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using Mmu.LolTimer.Areas.Domain.SummonerSpells.Models;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;

namespace Mmu.LolTimer.Areas.WpfUI.FlashTimers
{
    public partial class FlashTimerView : Window, INotifyPropertyChanged, IDisposable
    {
        private bool _disposed;
        public IReadOnlyCollection<SummonerSpell> SummonerSpells { get; private set; }

        public FlashTimerView()
        {
            InitializeComponent();
            DataContext = this;
        }

        public void Display()
        {
            Topmost = true;
            Show();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Initialize(IReadOnlyCollection<SummonerSpell> summonerSpells)
        {
            SummonerSpells = summonerSpells;
            OnPropertyChanged(nameof(SummonerSpells));
        }

        protected virtual void Dispose(bool disposedByCode)
        {
            if (!_disposed)
            {
                if (disposedByCode)
                {
                    SummonerSpells.ForEach(jc => jc.Dispose());
                }

                _disposed = true;
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        ~FlashTimerView()
        {
            Dispose(false);
        }
    }
}