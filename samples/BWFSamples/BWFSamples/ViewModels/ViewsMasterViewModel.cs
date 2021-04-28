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
            new ViewDefinitionModel(typeof(ButtonsPage), "Buttons", "It's a button...what more do you want from me?"),
            new ViewDefinitionModel(typeof(CardViewPage), "Cards", "More than a button!"),
            new ViewDefinitionModel(typeof(ColorsPage), "Colors", "All the colors a part of this library."),
            new ViewDefinitionModel(typeof(SymbolImageSourcePage), "Symbols", "Apple's SF Symbols as an ImageSource.",
                conditions:m => BraveWorld.Forms.BraveLibrary.PreviewFeatures.SymbolImageSource,
                platforms:new[] { Device.iOS, Device.Android }),
        };

        protected override IEnumerable<ViewDefinitionModel> CreateItems() => viewsList;
    }
}
