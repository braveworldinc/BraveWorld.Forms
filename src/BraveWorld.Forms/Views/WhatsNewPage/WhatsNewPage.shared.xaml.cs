using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace BraveWorld.Forms.Views
{
    public partial class WhatsNewPage : ContentPage
    {
        #region Properties
        #region Singleton
        private static WhatsNewPage _instance = null;
        public static WhatsNewPage Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new WhatsNewPage();

                return _instance;
            }
        }

        private Xamarin.Forms.NavigationPage _navigation = null;
        internal Xamarin.Forms.NavigationPage Navigation
        {
            get
            {
                if (_navigation == null)
                {
                    _navigation = new Xamarin.Forms.NavigationPage(Instance);
                    _navigation.On<iOS>().SetModalPresentationStyle(UIModalPresentationStyle.FormSheet);
                    Console.WriteLine($"Creating new navigation instance.");
                }
                else
                {
                    Console.WriteLine($"Navigation Page already created. Returning instance.");
                }

                return _navigation;
            }
        }

        internal static INavigation ParentNavigation { get; set; }
        #endregion

        public WhatsNewInfo Info { get; private set; }

        private ObservableCollection<string> _changes = new ObservableCollection<string>();
        public ObservableCollection<string> Changes
        {
            get => _changes;
            set => _changes = value;
        }
        #endregion

        public WhatsNewPage()
        {
            InitializeComponent();
            Title = "What's New";
        }

        internal Xamarin.Forms.NavigationPage GetNavigationPage() => Instance.Navigation;

        public async void OnDismissButtonClicked(object sender, EventArgs args) => await DismissModal();


        internal void SetChanges(IEnumerable<string> changes)
        {
            Changes = new ObservableCollection<string>(changes);
            changesCollectionView.ItemsSource = Changes;
        }

        internal void SetInfo(string title, string version, IEnumerable<string> changes, string? icon, string? headerText, ImageSource? bannerSource)
        {
            Title = title;
            titleLabel.Text = Title;
            versionLabel.Text = $"Version {version}";
            appIcon.Source = icon ?? "AppIcon";
            changesCollectionView.Header = headerText ?? "What's New";
            bannerImage.Source = bannerSource ?? null;

            SetChanges(changes);
        }
        internal void SetInfo(WhatsNewInfo info)
        {
            SetInfo(info.Title, info.Version, info.Changes, info.Icon, info.Header, info.BannerSource);
        }



        public static async Task DismissModal() => await ParentNavigation.PopModalAsync();

        public static async Task ShowModal(INavigation navigation, WhatsNewInfo info)
        {
            Xamarin.Forms.NavigationPage navPage = Instance.GetNavigationPage();
            Instance.SetInfo(info);
            ParentNavigation = navigation;
            await ParentNavigation.PushModalAsync(navPage);
        }

        public static async Task ShowModal(INavigation navigation, IEnumerable<string> changes, string version = "4.2.0")
        {
            await ShowModal(navigation, new WhatsNewInfo("Title", version, changes: changes, null, "AppIcon"));
        }

        public static async Task ShowModal(INavigation navigation, IEnumerable<string> changes, string version = "4.2.0", string icon = "AppIcon")
        {
            await ShowModal(navigation, new WhatsNewInfo("Title", version, changes, null, icon));
        }
    }
}