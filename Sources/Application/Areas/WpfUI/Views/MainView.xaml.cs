using System;
using System.Windows;
using Mmu.LolTimer.Areas.Domain.Models;

namespace Mmu.LolTimer.Areas.WpfUI.Views
{
    public partial class MainView : Window
    {
        public JungleCamp[] JungleCamps { get; }

        public MainView(JungleCamp[] jungleCamps)
        {
            InitializeComponent();
            DataContext = this;
            JungleCamps = jungleCamps;
        }

        protected override void OnActivated(EventArgs e)
        {
            //Topmost = true;
        }
    }
}