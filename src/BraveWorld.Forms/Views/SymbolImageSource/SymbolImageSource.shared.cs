using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

using BraveWorld.Forms.Views;

using FormsElement = Xamarin.Forms.Image;


namespace BraveWorld.Forms.Views
{
	public class SymbolImageSource : ImageSource
	{
		#region Properties
		public static readonly BindableProperty GlyphProperty =
			BindableProperty.Create(nameof(Glyph), typeof(string), typeof(SymbolImageSource));

		public string Glyph
		{
			get => (string)GetValue(GlyphProperty);
			set => SetValue(GlyphProperty, value);
		}

		public static readonly BindableProperty WeightProperty =
			BindableProperty.Create(nameof(Weight), typeof(SymbolWeight), typeof(SymbolImageSource), SymbolWeight.Regular);

		public SymbolWeight Weight
		{
			get => (SymbolWeight)GetValue(WeightProperty);
			set => SetValue(WeightProperty, value);
		}
		#endregion

		public SymbolImageSource()
		{

		}

		protected override void OnPropertyChanged([CallerMemberName] string? propertyName = null)
		{
			if (propertyName == GlyphProperty.PropertyName || propertyName == WeightProperty.PropertyName)
				OnSourceChanged();

			base.OnPropertyChanged(propertyName);
		}

		public void SetWeight(SymbolWeight symbolWeight)
		{
			Weight = symbolWeight;
		}
	}

	public enum SymbolWeight
	{
		UltraLight,
		Thin,
		Light,
		Regular,
		Medium,
		Semibold,
		Bold,
		Heavy,
		Black
	}
}