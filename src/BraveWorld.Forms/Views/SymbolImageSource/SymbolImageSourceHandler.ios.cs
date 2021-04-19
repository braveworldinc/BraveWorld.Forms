using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using BraveWorld.Forms.Views;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using BraveWorld.Forms.Extensions;

using PreserveAttribute = Foundation.PreserveAttribute;
using Foundation;

[assembly: ExportImageSourceHandler(typeof(SymbolImageSource), typeof(SymbolImageSourceHandler))]
namespace BraveWorld.Forms.Views
{
    public partial class SymbolImageSourceHandler : IImageSourceHandler
    {
        [Preserve(Conditional = true)]
        public SymbolImageSourceHandler()
        { }

        public Task<UIImage?> LoadImageAsync(ImageSource imagesource, CancellationToken cancelationToken = default, float scale = 1)
        {
            SymbolImageSource? source = (SymbolImageSource)imagesource;
            var img = UIKitExtensions.GetSymbolWithWeight(source.Glyph, source.Weight);

            return Task.FromResult(img);
        }
    }
}
