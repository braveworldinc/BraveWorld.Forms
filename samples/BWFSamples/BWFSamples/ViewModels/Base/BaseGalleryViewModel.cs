using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using BraveWorld.Forms.Classes;
using BWFSamples.Models;
using Xamarin.CommunityToolkit.ObjectModel;

namespace BWFSamples.ViewModels
{
	public abstract class BaseGalleryViewModel : BaseViewModel
	{
		public BaseGalleryViewModel()
		{
			Items = CreateItems().OrderBy(x => x.Title).ToList();
			Filter();
			FilterCommand = CommandFactory.Create(Filter);
		}

		public IReadOnlyList<ViewDefinitionModel> Items { get; }

		public ICommand FilterCommand { get; }

		public string FilterValue { private get; set; } = string.Empty;

		public IEnumerable<ViewDefinitionModel> FilteredItems { get; private set; } = Enumerable.Empty<ViewDefinitionModel>();

		protected abstract IEnumerable<ViewDefinitionModel> CreateItems();

		void Filter()
		{
			FilterValue ??= string.Empty;
			FilteredItems = Items.Where(item => item.Title.IndexOf(FilterValue, StringComparison.InvariantCultureIgnoreCase) >= 0);
			OnPropertyChanged(nameof(FilteredItems));
		}
    }
}
