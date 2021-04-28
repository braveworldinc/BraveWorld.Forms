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
using BWFSamples.Models;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using BWFSamples.Pages;
using System.Windows.Input;
using System.Reflection;

namespace BWFSamples
{
    public partial class MainPage : MasterDetailView
    {
        private string[] changelog => new[]
        {
            new ChangeLogEntry(ChangeLogEntryType.Updated, $"{BraveLibrary.Name} to {BraveLibrary.Version}").ToString(),
            new ChangeLogEntry(ChangeLogEntryType.Updated, "Cards to use PancakeView").ToString()
        };


        public Color DetailColor { get; set; }

        public ICommand NavigateCommand { get; }


        public MainPage()
        {
            InitializeComponent();

            viewsMaster.ItemSelected += ViewsMaster_ItemSelected;


            ShowChangelogWindow();

            //if (VersionTracking.IsFirstLaunchForCurrentBuild)
            //    ShowChangelogWindow();
        }

        private async Task ViewsMaster_ItemSelected(ViewDefinitionModel viewDefinition)
        {
            OpenDetail(PreparePage(viewDefinition));
        }

        private async Task ShowChangelogWindow()
        {
            await WhatsNewPage.ShowModal(Navigation, new WhatsNewInfo(
                BraveLibrary.Name,
                AppInfo.VersionString,
                changelog,
                icon: "AppIconLarge",
                bannerSource: ImageSource.FromResource("BWFSamples.Resources.Images.pexels-photo-1323550.jpeg")
            ));
        }

        Xamarin.Forms.Page PreparePage(ViewDefinitionModel model)
        {
            var page = (BasePage)Activator.CreateInstance(model.Type);
            page.Title = model.Title;
            page.DetailColor = model.Color;
            return page;
        }
    }
}
