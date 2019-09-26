using System;
using System.Diagnostics;
using System.Timers;

namespace Mmu.LolTimer.Areas.Domain.Models
{
    public class CampTimer
    {
        private readonly TimeSpan _spawnTime;
        private readonly Timer _timer;
        private short _elapsedSeconds;

        public string TimerDescription
        {
            get
            {
                if (_elapsedSeconds == 0)
                {
                    return "N/A";
                }

                if (_elapsedSeconds >= _spawnTime.Seconds)
                {
                    return "R";
                }

                var ts = _spawnTime.Subtract(new TimeSpan(0, 0, _elapsedSeconds));
                return ts.ToString(@"mm\:ss");
            }
        }

        public CampTimer(TimeSpan spawnTime)
        {
            _elapsedSeconds = 0;
            _spawnTime = spawnTime;
            _timer = new Timer(1000);
            _timer.Elapsed += Timer_Elapsed;
        }

        public void Start()
        {
            _elapsedSeconds = 0;
            _timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _elapsedSeconds += 1;
        }
    }
}