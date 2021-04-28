using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BWFSamples.Pages.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CardViewPage : BasePage
    {
        public CardViewPage()
        {
            InitializeComponent();
            UpdateLayout();
        }

        protected override void OnAppearing()
        {
        }

        private void UpdateLayout()
        {
            switch (Device.Idiom)
            {
                default:
                case TargetIdiom.Phone:
                    collectionView.ItemsLayout = new GridItemsLayout(1, ItemsLayoutOrientation.Vertical);
                    break;
                case TargetIdiom.Tablet:
                    collectionView.ItemsLayout = new GridItemsLayout(2, ItemsLayoutOrientation.Vertical);
                    break;
            }
        }
    }
}