﻿using System;
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

        private string[] changelog => new[]
        {
            "Created sample app.",
            "Created a \"What's New\" popup."
        };

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ShowChangelogWindow();
        }

        private async Task ShowChangelogWindow()
        {
            await WhatsNewPage.ShowModal(Navigation, changes: changelog, Xamarin.Essentials.AppInfo.VersionString);
        }
    }
}
