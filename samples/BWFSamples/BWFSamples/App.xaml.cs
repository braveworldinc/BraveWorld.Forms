using System;
using BraveWorld.Forms;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BWFSamples
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            BraveLibrary.RegisterAssembly();
            BraveLibrary.PreviewFeatures.EnableFeatures(new[] { "SymbolImageSource" });

            VersionTracking.Track();

            MainPage = new MainPage();
        }
    }
}
