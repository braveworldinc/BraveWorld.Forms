using System;
using BraveWorld.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BWFSamples
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            BraveLibrary.Init();

            MainPage = new MainPage();

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
