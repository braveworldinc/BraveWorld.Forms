using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using BraveWorld.Forms.Views;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

using PreserveAttribute = Foundation.PreserveAttribute;

namespace BraveWorld.Forms.Extensions
{
    public static partial class UIKitExtensions
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


		public static UIImage? GetSymbolWithWeight(string systemImage, SymbolWeight weight = SymbolWeight.Regular)
		{
			if (UIDevice.CurrentDevice.CheckSystemVersion(13, 0))
				throw new Exceptions.FeatureNotSupportedException();

			var config = UIImageSymbolConfiguration.Create(16, weight.ToUIKit());
			var symbol = UIImage.GetSystemImage(systemImage, config);
			return symbol;
		}
	}
}
