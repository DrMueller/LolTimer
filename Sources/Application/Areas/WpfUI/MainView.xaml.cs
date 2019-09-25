using System;
using System.Timers;
using System.Windows;

namespace Mmu.LolTimer.Areas.WpfUI
{
    public partial class MainView : Window, IDisposable
    {
        private readonly Timer _timer;
        private bool _disposed;

        public MainView()
        {
            InitializeComponent();

            _timer = new Timer(1000);
            _timer.Elapsed += Timer_Elapsed;
            _timer.Start();
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
                    _timer.Dispose();
                }

                _disposed = true;
            }
        }

        protected override void OnActivated(EventArgs e)
        {
            Topmost = true;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                Lbl.Content = DateTime.Now.ToLongTimeString();
            });
        }

        ~MainView()
        {
            Dispose(false);
        }
    }
}