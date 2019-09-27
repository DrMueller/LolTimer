using System;
using System.ComponentModel;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models.Inputs;

namespace Mmu.LolTimer.Areas.Domain.Models
{
    public abstract class JungleCamp : INotifyPropertyChanged
    {
        private readonly CampTimer _campTimer;

        public string Description
        {
            get
            {
                return $"{GetCampName()} ({InputKey}): {_campTimer.TimerDescription}";
            }
        }

        public abstract KeyboardInputKey InputKey { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public JungleCamp(TimeSpan spawnTime)
        {
            _campTimer = new CampTimer(
                spawnTime,
                () => OnPropertyChanged(nameof(Description)));
        }

        public void StartTimer()
        {
            _campTimer.Start();
        }

        protected abstract string GetCampName();

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}