using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using BraveWorld.Forms;

namespace BraveWorld.Forms.Controls
{
    [ContentProperty("Master")]
    public class MasterDetailView : NavigationPage
    {
        #region Properties
        public static readonly BindableProperty MasterProperty = BindableProperty.Create(
            propertyName: nameof(Master),
            returnType: typeof(ContentPage),
            declaringType: typeof(MasterDetailView),
            defaultBindingMode: BindingMode.TwoWay
        );

        public ContentPage Master
        {
            get => (ContentPage)GetValue(MasterProperty);
            set => SetValue(MasterProperty, value);
        }

        public static readonly BindableProperty DetailProperty = BindableProperty.Create(
            propertyName: nameof(Detail),
            returnType: typeof(ContentPage),
            declaringType: typeof(MasterDetailView),
            defaultBindingMode: BindingMode.TwoWay
        );

        public ContentPage Detail
        {
            get => (ContentPage)GetValue(DetailProperty);
            set => SetValue(DetailProperty, value);
        }


        public static readonly BindableProperty DefaultDetailsViewProperty = BindableProperty.Create(
            propertyName: nameof(DefaultDetailsView),
            returnType: typeof(ContentView),
            declaringType: typeof(MasterDetailView)
        );

        public ContentView DefaultDetailsView
        {
            get => (ContentView)GetValue(DefaultDetailsViewProperty);
            set => SetValue(DefaultDetailsViewProperty, value);
        }




        public bool ShouldUseTabletLayout => Device.Idiom == TargetIdiom.Tablet;



        //public static readonly BindableProperty CurrentPageProperty = BindableProperty.Create(
        //    propertyName: nameof(CurrentPage),
        //    returnType: typeof(Page),
        //    declaringType: typeof(MasterDetailView)
        //);

        //public Page CurrentPage
        //{
        //    get => (Page)GetValue(CurrentPageProperty);
        //    set => SetValue(CurrentPageProperty, value);
        //}


        public static readonly BindableProperty SeparatorColorProperty = BindableProperty.Create(
            propertyName: nameof(SeparatorColor),
            returnType: typeof(Color),
            declaringType: typeof(MasterDetailView),
            defaultValue: Color.DarkGray,
            defaultBindingMode:BindingMode.TwoWay
        );

        public Color SeparatorColor
        {
            get => (Color)GetValue(SeparatorColorProperty);
            set => SetValue(SeparatorColorProperty, value);
        }
        #endregion


        private NavigationPage _masterNavigation;
        private NavigationPage _detailNavigation;

        private NavigationPage _mainNavigationPage => (ShouldUseTabletLayout) ? _masterNavigation : this;

        private FlyoutPage flyout;


        public MasterDetailView()
        {
            Application.Current.RequestedThemeChanged += Current_RequestedThemeChanged;

            GeneratePages();
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            NavigationPage.SetHasNavigationBar(this, false);
            Xamarin.Forms.PlatformConfiguration.iOSSpecific.NavigationPage.SetPrefersLargeTitles(Master, true);
        }

        private void GeneratePages()
        {
            if (ShouldUseTabletLayout)
            {
                _masterNavigation = new NavigationPage();
                _detailNavigation = new NavigationPage();

                _masterNavigation.Title = "Master";
                _detailNavigation.Title = "Detail";

                flyout = new FlyoutPage();
                NavigationPage.SetHasNavigationBar(flyout, false);

                flyout.Flyout = _masterNavigation;
                flyout.Detail = _detailNavigation;
                //flyout.BackgroundColor = SeparatorColor;

                UpdateAppearance();

                ReplaceRoot(this, flyout);
            }
            else
            {
                // TBD
            }
        }


        private void Current_RequestedThemeChanged(object sender, AppThemeChangedEventArgs e)
        {
            UpdateAppearance();
        }


        private void UpdateAppearance()
        {
            if(flyout != null)
            {
                //flyout.SetAppThemeColor(FlyoutPage.BackgroundColorProperty, SystemColors.Gray.DarkColor, SeparatorColorDark);
                flyout.SetAppThemeColor(FlyoutPage.BackgroundColorProperty, SystemColors.Gray4);
            }
        }


        private async Task ReplaceRoot(NavigationPage navigationPage, Page page)
        {
            var stack = navigationPage.Navigation.NavigationStack;
            if (stack.Count > 0)
            {
                var root = navigationPage.Navigation.NavigationStack[0];
                navigationPage.Navigation.InsertPageBefore(page, root);
                await navigationPage.PopToRootAsync(animated:false);
            }
            else
            {
                await navigationPage.Navigation.PushAsync(page, false);
            }
            navigationPage.Title = page.Title;
        }

        private ContentPage CreateDefaultPage()
        {
            ContentPage defaultPage = new ContentPage();
            defaultPage.Content = DefaultDetailsView;

            Xamarin.Forms.PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea(defaultPage, true);

            return defaultPage;
        }


        //public new async Task PopToRootAsync()
        //{
        //    while (Navigation.ModalStack.Count > 0)
        //    {
        //        await Navigation.PopModalAsync(false);
        //    }
        //    //while (CurrentPage != Navigation.NavigationStack[0])
        //    //{
        //    //    await Navigation.PushModalAsync(page, false);
        //    //}
        //}

        public void OpenDetail<T>(T page, bool animated = false) where T : Page
        {
            if (ShouldUseTabletLayout)
            {
                if (animated == false)
                    ReplaceRoot(_detailNavigation, page);
                else
                    this.PushAsync(page, true);

                flyout.IsPresented = false;
            }
            else
                this.PushAsync(page, true);

        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == MasterProperty.PropertyName)
                ReplaceRoot(_mainNavigationPage, Master);


            //if (propertyName == DetailProperty.PropertyName)
            //    ReplaceRoot(_detailNavigation, Detail);


            if (propertyName == DefaultDetailsViewProperty.PropertyName)
                ReplaceRoot(_detailNavigation, CreateDefaultPage());
        }
    }
}

