using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BWFSamples
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            libraryVersion.Text = BraveWorld.Forms.BraveLibrary.Version.ToString();
            appVersion.Text = Xamarin.Essentials.VersionTracking.CurrentVersion;
        }
    }
}
