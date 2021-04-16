using System.Threading;
using System.Threading.Tasks;
using BraveWorld.Forms.Views;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportImageSourceHandler(typeof(SymbolImageSource), typeof(SymbolImageSourceHandler))]

namespace BraveWorld.Forms.Views
{
    public partial class SymbolImageSourceHandler : IImageSourceHandler
	{
		public static bool IsSupported() => UIDevice.CurrentDevice.CheckSystemVersion(13, 0);

		UIImage? GetSymbol(string systemImage, SymbolWeight weight = SymbolWeight.Regular)
		{
			var config = UIImageSymbolConfiguration.Create(weight.ToUIKit());
			var symbol = UIImage.GetSystemImage(systemImage, config);
			return symbol;
		}

		public async Task<UIImage?> LoadImageAsync(ImageSource imagesource, CancellationToken cancelationToken = default, float scale = 1)
		{
			if (!IsSupported())
				return null;

			var source = imagesource as SymbolImageSource;

			if (source == null)
				return null;

			return GetSymbol(source.Glyph, source.Weight);
		}

	}

	static class SFSymbolHelpersiOS
	{
		public static UIImageSymbolWeight ToUIKit(this SymbolWeight weight) => weight switch
		{
			SymbolWeight.UltraLight => UIImageSymbolWeight.UltraLight,
			SymbolWeight.Thin => UIImageSymbolWeight.Thin,
			SymbolWeight.Light => UIImageSymbolWeight.Light,
			SymbolWeight.Medium => UIImageSymbolWeight.Medium,
			SymbolWeight.Semibold => UIImageSymbolWeight.Semibold,
			SymbolWeight.Bold => UIImageSymbolWeight.Bold,
			SymbolWeight.Heavy => UIImageSymbolWeight.Heavy,
			SymbolWeight.Black => UIImageSymbolWeight.Black,
			_ => UIImageSymbolWeight.Regular,
		};
	}
}
