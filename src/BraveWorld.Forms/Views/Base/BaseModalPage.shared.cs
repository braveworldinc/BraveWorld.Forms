using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace BraveWorld.Forms.Views.Base
{
    public partial class BaseModalPage<TPage> : ContentPage where TPage : ContentPage, new()
    {
        #region Properties
        #region Singleton
        private static TPage _instance = null;
        public static TPage Instance
        {
            get
            {
                if (_instance == null)
                    _instance = default(TPage);

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
        #endregion

        //public BaseModalPage()
        //{
        //    Content = new StackLayout
        //    {
        //        Children = {
        //            new Label { Text = "Hello ContentPage" }
        //        }
        //    };
        //}




        internal static Xamarin.Forms.NavigationPage GetNavigationPage() => (Xamarin.Forms.NavigationPage)Instance.Navigation;

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
    }
}

