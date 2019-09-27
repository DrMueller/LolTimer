using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Mmu.LolTimer.Areas.Domain.Models;
using Mmu.LolTimer.Areas.Domain.Services;

namespace Mmu.LolTimer.Areas.WpfUI.Views
{
    public partial class MainView : Window
    {
        public IReadOnlyCollection<JungleCamp> JungleCamps { get; }

        public MainView(IJungleCampFactory jungleCampFactory)
        {
            InitializeComponent();
            DataContext = this;
            JungleCamps = jungleCampFactory.CreateAll();
        }


        protected override void OnActivated(EventArgs e)
        {
            //Topmost = true;
        }
    }
}