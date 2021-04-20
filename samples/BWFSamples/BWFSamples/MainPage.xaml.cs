using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using BraveWorld.Forms.Views;

namespace BWFSamples
{
    public partial class MainPage : BraveWorld.Forms.Views.MasterDetailView
    {
        public MainPage() => InitializeComponent();



        protected override void OnAppearing()
        {
            base.OnAppearing();
            ShowChangelogWindow();
        }

        private async Task ShowChangelogWindow()
        {
            await WhatsNewPage.ShowModal(Navigation);
            await Task.Delay(1000);
            await WhatsNewPage.ShowModal(Navigation);
        }
    }
}
