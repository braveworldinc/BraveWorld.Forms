using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BraveWorld.Forms.Extensions
{
    public static partial class FormsExtensions
    {
        public static async Task ShowExceptionAlert(this Page sender, Exception e)
        {
            await sender.DisplayAlert("Exception Thrown", e.Message, "Great...");
        }

        public static async Task ShowExceptionAlert(Exception e)
        {
            await Application.Current.MainPage.DisplayAlert("Exception Thrown", e.Message, "Great...");
        }

        public static string ToHexString(this Color color, bool includeAlpha = false)
        {
            var red = (int)(color.R * 255);
            var green = (int)(color.G * 255);
            var blue = (int)(color.B * 255);
            var alpha = (int)(color.A * 255);
            string hex;

            if (includeAlpha)
                hex = $"#{alpha:X2}{red:X2}{green:X2}{blue:X2}";
            else
                hex = $"#{red:X2}{green:X2}{blue:X2}";

            return hex;
        }
    }
}
