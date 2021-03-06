﻿using System;
using System.ComponentModel;
using Mmu.LolTimer.Areas.Application.Hooking.KeyboardHooking.Domain.Models.Inputs;
using Mmu.LolTimer.Areas.Domain.Common.Models;

namespace Mmu.LolTimer.Areas.Domain.SummonerSpells.Models
{
    public sealed class SummonerSpell : ITimeableElement, IDisposable, INotifyPropertyChanged
    {
        private readonly SummonerSpellTimer _spellTimer;
        private readonly string _summonerName;
        private bool _disposed;
        public string Description => $"{_summonerName} ({InputKey}): {_spellTimer.TimerDescription}";
        public KeyboardInputKey InputKey { get; }

        public SummonerSpell(string summonerName, KeyboardInputKey inputKey, TimeSpan cooldown)
        {
            InputKey = inputKey;
            _summonerName = summonerName;

            _spellTimer = new SummonerSpellTimer(
                cooldown,
                () => OnPropertyChanged(nameof(Description)));
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void StartTimer()
        {
            _spellTimer.Start();
        }

        private void Dispose(bool disposedByCode)
        {
            if (!_disposed)
            {
                if (disposedByCode)
                {
                    _spellTimer.Dispose();
                }

                _disposed = true;
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}