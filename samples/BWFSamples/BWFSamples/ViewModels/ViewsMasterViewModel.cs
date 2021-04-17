using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using BWFSamples.Models;
using BWFSamples.ViewModels;
using BWFSamples.Pages.Views;

namespace BWFSamples.ViewModels
{
    public class ViewsMasterViewModel : BaseGalleryViewModel
    {
        protected override IEnumerable<ViewDefinitionModel> CreateItems() => new[]
        {
            new ViewDefinitionModel(typeof(SymbolImageSourcePage), "Symbol Image Source", "Description Goes Here")
        };
    }
}
