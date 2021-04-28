using System;
using System.Collections.Generic;

using Xamarin.Forms;
using BWFSamples.ViewModels;
using System.Threading.Tasks;
using BWFSamples.Models;

namespace BWFSamples.Pages.Views
{
    public partial class ViewsMasterPage : BasePage
    {
        public delegate Task ProjectSelectedDelegate(ViewDefinitionModel viewDefinition);
        public event ProjectSelectedDelegate ItemSelected;


        public ViewsMasterPage() => InitializeComponent();


        void OnItemSelected(object sender, EventArgs e)
        {
            var layout = (BindableObject)sender;
            var item = (ViewDefinitionModel)layout.BindingContext;
            ItemSelected?.Invoke(item);
        }
    }
}
