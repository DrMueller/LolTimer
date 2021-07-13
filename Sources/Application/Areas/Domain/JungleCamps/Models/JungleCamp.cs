using System;
using System.ComponentModel;
using Mmu.LolTimer.Areas.Application.Hooking.KeyboardHooking.Domain.Models.Inputs;
using Mmu.LolTimer.Areas.Domain.Common.Models;

namespace Mmu.LolTimer.Areas.Domain.JungleCamps.Models
{
    public abstract class JungleCamp : INotifyPropertyChanged, IDisposable, ITimeableElement
    {
        private readonly CampTimer _campTimer;
        private bool _disposed;
        public string Description => $"{GetCampName()} ({InputKey}): {_campTimer.TimerDescription}";
        public abstract KeyboardInputKey InputKey { get; }

        public int SortKey
        {
            get
            {
                var initialKey = GetInitialSortKey();
                return Position == JungleCampPosition.Own ? initialKey : initialKey + 6;
            }
        }

        protected JungleCampPosition Position { get; private set; }

        protected JungleCamp(TimeSpan spawnTime)
        {
            _campTimer = new CampTimer(
                spawnTime,
                () => OnPropertyChanged(nameof(Description)));
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void InitializePosition(JungleCampPosition position)
        {
            Position = position;
        }

        public void StartTimer()
        {
            _campTimer.Start();
        }

        protected virtual void Dispose(bool disposedByCode)
        {
            if (_disposed)
            {
                return;
            }

            if (disposedByCode)
            {
                _campTimer.Dispose();
            }

            _disposed = true;
        }

        protected abstract string GetCampName();

        protected abstract int GetInitialSortKey();

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        ~JungleCamp()
        {
            Dispose(false);
        }
    }
}