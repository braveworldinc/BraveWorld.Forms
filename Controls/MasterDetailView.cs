using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace BraveWorld.Forms.Controls
{
    [ContentProperty("Master")]
    public class MasterDetailView : NavigationPage
    {
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



        private NavigationPage _masterNavigation;
        private NavigationPage _detailNavigation;

        private NavigationPage _mainNavigationPage => (ShouldUseTabletLayout) ? _masterNavigation : this;

        private FlyoutPage flyout;


        public MasterDetailView()
        {
            //Content = new StackLayout
            //{
            //    Children = {
            //        new Label { Text = "Hello ContentPage" }
            //    }
            //};
            this.Title = "Meh";
            NavigationPage.SetHasNavigationBar(this, false);
            GeneratePages();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            NavigationPage.SetHasNavigationBar(this, false);
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

                ReplaceRoot(this, flyout);
            }
            else
            {

            }
        }


        private async Task ReplaceRoot(NavigationPage navigationPage, Page page)
        {
            var stack = navigationPage.Navigation.NavigationStack;
            if (stack.Count > 0)
            {
                var root = navigationPage.Navigation.NavigationStack[0];
                navigationPage.Navigation.InsertPageBefore(page, root);
                await navigationPage.PopToRootAsync();
            }
            else
            {
                await navigationPage.Navigation.PushAsync(page, false);
            }
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

        public void OpenDetail(Page page)
        {
            if (ShouldUseTabletLayout)
                _detailNavigation.PushAsync(page);
            else
                this.PushAsync(page);

        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == MasterProperty.PropertyName)
                ReplaceRoot(_mainNavigationPage, Master);

            if (propertyName == DetailProperty.PropertyName)
                ReplaceRoot(_detailNavigation, Detail);
        }
    }
}

