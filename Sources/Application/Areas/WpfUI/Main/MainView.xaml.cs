using System.Windows;
using Mmu.LolTimer.Areas.WpfUI.FlashTimers;
using Mmu.LolTimer.Areas.WpfUI.JungleCamps;

namespace Mmu.LolTimer.Areas.WpfUI.Main
{
    /// <summary>
    ///     Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        private readonly ConfigureSummonersView _configureSummonersView;
        private readonly JungleCampTimerView _jungleCampTimerView;

        public MainView(JungleCampTimerView jungleCampTimerView, ConfigureSummonersView configureSummonersView)
        {
            _jungleCampTimerView = jungleCampTimerView;
            _configureSummonersView = configureSummonersView;
            InitializeComponent();
        }

        private void BtnJungleTimer_Click(object sender, RoutedEventArgs e)
        {
            HideThisAndShowWindow(_jungleCampTimerView);
        }

        private void BtnFlashTimer_Click(object sender, RoutedEventArgs e)
        {
            HideThisAndShowWindow(_configureSummonersView);
        }

        private void HideThisAndShowWindow(Window window)
        {
            Visibility = Visibility.Hidden;
            window.Show();
        }
    }
}