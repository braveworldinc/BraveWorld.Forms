using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
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

        public ICommand DismissCommand { get; }

        #endregion

        public WhatsNewPage()
        {
            InitializeComponent();
            Title = "What's New";
        }

        internal static Xamarin.Forms.NavigationPage GetNavigationPage() => Instance.Navigation;

        public static async Task DismissModal()
        {
            await ParentNavigation.PopModalAsync();
        }

        public static async Task ShowModal(INavigation navigation)
        {
            Xamarin.Forms.NavigationPage navPage = GetNavigationPage();
            ParentNavigation = navigation;
            await ParentNavigation.PushModalAsync(navPage);
        }


        public async void OnDismissButtonClicked(object sender, EventArgs args) => await DismissModal();
    }
}
