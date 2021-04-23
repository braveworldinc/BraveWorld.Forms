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
            new ViewDefinitionModel(typeof(SymbolImageSourcePage), "Symbol Image Source", "Description Goes Here",
                conditions:m => BraveWorld.Forms.BraveLibrary.PreviewFeatures.SymbolImageSource,
                platforms:new[] { Device.iOS, Device.Android }),
            new ViewDefinitionModel(typeof(ButtonsPage), "Buttons", "Description Goes Here"),
            new ViewDefinitionModel(typeof(ColorsPage), "Colors", "Description Goes Here")
        };

        protected override IEnumerable<ViewDefinitionModel> CreateItems()
        {
            return viewsList;
            //return viewsList.Where(p => p.IsVisibleWithConditions(p) && p.Platforms.Contains(Device.RuntimePlatform));
        }
    }
}
