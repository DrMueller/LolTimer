using System;
using System.Timers;

namespace Mmu.LolTimer.Areas.Domain.SummonerSpells.Models
{
    public sealed class SummonerSpellTimer : IDisposable
    {
        private const int IntervalInSeconds = 1;
        private readonly TimeSpan _cooldown;
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

                if (_elapsedSeconds >= _cooldown.TotalSeconds)
                {
                    return "Up";
                }

                var ts = _cooldown.Subtract(new TimeSpan(0, 0, _elapsedSeconds));
                return ts.ToString(@"mm\:ss");
            }
        }

        public SummonerSpellTimer(TimeSpan cooldown, Action timerElapsedCallback)
        {
            _elapsedSeconds = 0;
            _cooldown = cooldown;
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

        private void Dispose(bool disposedByCode)
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

        ~SummonerSpellTimer()
        {
            Dispose(false);
        }
    }
}