using System;
using System.Threading.Tasks;
using System.Windows.Input;
using BWFSamples.Models;
using BWFSamples.ViewModels;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace BWFSamples.Pages
{
	public class BasePage : ContentPage
	{
		public BasePage()
		{
			On<iOS>().SetPrefersHomeIndicatorAutoHidden(true);

			NavigateCommand = CommandFactory.Create<ViewDefinitionModel>(sectionModel =>
			{
				if (sectionModel != null)
					return Navigation.PushAsync(PreparePage(sectionModel));

				return Task.CompletedTask;
			});
		}

		public Color DetailColor { get; set; }

		public ICommand NavigateCommand { get; }

		Xamarin.Forms.Page PreparePage(ViewDefinitionModel model)
		{
			var page = (BasePage)Activator.CreateInstance(model.Type);
			page.Title = model.Title;
			page.DetailColor = model.Color;
			return page;
		}
	}
}
