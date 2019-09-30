using System;
using System.ComponentModel;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models.Inputs;

namespace Mmu.LolTimer.Areas.Domain.Models
{
    public abstract class JungleCamp : INotifyPropertyChanged, IDisposable
    {
        private readonly CampTimer _campTimer;

        private bool _disposed;

        public string Description
        {
            get
            {
                return $"{GetCampName()} ({InputKey}): {_campTimer.TimerDescription}";
            }
        }

        public abstract KeyboardInputKey InputKey { get; }

        public abstract int SortKey { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public JungleCamp(TimeSpan spawnTime)
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

        public void StartTimer()
        {
            _campTimer.Start();
        }

        protected virtual void Dispose(bool disposedByCode)
        {
            if (!_disposed)
            {
                if (disposedByCode)
                {
                    _campTimer.Dispose();
                }

                _disposed = true;
            }
        }

        protected abstract string GetCampName();

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        ~JungleCamp()
        {
            Dispose(false);
        }
    }
}