using System;
using System.Timers;

namespace Mmu.LolTimer.Areas.Domain.JungleCamps.Models
{
    public class CampTimer : IDisposable
    {
        private const int IntervalInSeconds = 1;
        private readonly TimeSpan _spawnTime;
        private readonly Timer _timer;
        private readonly Action _timerElapsedCallback;
        private bool _disposed;
        private short _elapsedSeconds;

        public string TimerDescription
        {
            get
            {
                if (_elapsedSeconds == 0)
                {
                    return "N/A";
                }

                if (_elapsedSeconds >= _spawnTime.TotalSeconds)
                {
                    return "Spawned";
                }

                var ts = _spawnTime.Subtract(new TimeSpan(0, 0, _elapsedSeconds));
                return ts.ToString(@"mm\:ss");
            }
        }

        public CampTimer(TimeSpan spawnTime, Action timerElapsedCallback)
        {
            _elapsedSeconds = 0;
            _spawnTime = spawnTime;
            _timerElapsedCallback = timerElapsedCallback;
            _timer = new Timer(IntervalInSeconds * 1000);
            _timer.Elapsed += Timer_Elapsed;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Start()
        {
            _elapsedSeconds = 0;
            _timer.Start();
        }

        protected virtual void Dispose(bool disposedByCode)
        {
            if (!_disposed)
            {
                if (disposedByCode)
                {
                    _timer.Dispose();
                }

                _disposed = true;
            }
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _elapsedSeconds += IntervalInSeconds;
            _timerElapsedCallback();
        }

        ~CampTimer()
        {
            Dispose(false);
        }
    }
}