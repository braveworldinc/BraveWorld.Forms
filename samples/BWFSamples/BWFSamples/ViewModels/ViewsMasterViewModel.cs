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
        private const string PLACEHOLDER_DESCRIPTION = "{Description goes here}";

        private readonly static IEnumerable<ViewDefinitionModel> viewsList = new[]
        {
            new ViewDefinitionModel(typeof(ButtonsPage), "Buttons", PLACEHOLDER_DESCRIPTION),
            new ViewDefinitionModel(typeof(CardViewPage), "Cards", PLACEHOLDER_DESCRIPTION),
            new ViewDefinitionModel(typeof(ColorsPage), "Colors", PLACEHOLDER_DESCRIPTION),
            new ViewDefinitionModel(typeof(SymbolImageSourcePage), "SF Symbols", PLACEHOLDER_DESCRIPTION,
                conditions:m => BraveWorld.Forms.BraveLibrary.PreviewFeatures.SymbolImageSource,
                platforms:new[] { Device.iOS, Device.Android }),
        };

        protected override IEnumerable<ViewDefinitionModel> CreateItems() => viewsList;
    }
}
