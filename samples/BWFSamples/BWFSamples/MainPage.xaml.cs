using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using BraveWorld.Forms;
using BraveWorld.Forms.Views;

namespace BWFSamples
{
    public partial class MainPage : BraveWorld.Forms.Views.MasterDetailView
    {
        public MainPage() => InitializeComponent();

        private string[] changelog => new[]
        {
            $"Updated: {BraveLibrary.Name} to {BraveLibrary.Version}",
            "Added: System Colors Viewer"
        };

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ShowChangelogWindow();
        }

        private async Task ShowChangelogWindow()
        {
            await WhatsNewPage.ShowModal(Navigation, new WhatsNewInfo(BraveLibrary.Name, AppInfo.VersionString, changelog, icon: "AppIconLarge"));
        }
    }
}
