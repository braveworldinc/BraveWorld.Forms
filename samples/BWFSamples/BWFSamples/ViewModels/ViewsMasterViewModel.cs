using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using BWFSamples.Models;
using BWFSamples.ViewModels;
using BWFSamples.Pages.Views;

namespace BWFSamples.ViewModels
{
    public class ViewsMasterViewModel : BaseGalleryViewModel
    {
        private readonly static IEnumerable<ViewDefinitionModel> viewsList = new[]
        {
            new ViewDefinitionModel(typeof(SymbolImageSourcePage), "Symbol Image Source", "Description Goes Here", new[] { Device.iOS, Device.Android })
        };

        protected override IEnumerable<ViewDefinitionModel> CreateItems()
            => viewsList.Where(p => p.Platforms.Contains(Device.RuntimePlatform));
    }
}
