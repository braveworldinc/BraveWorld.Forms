using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace BraveWorld.Forms.Views.Base
{
    public interface IModalPage<TPage> where TPage : ContentPage
    {
        //private static TPage _instance;
        //public static TPage Instance;

        //Xamarin.Forms.NavigationPage _navigation;
        //Xamarin.Forms.NavigationPage Navigation;
    }
}
