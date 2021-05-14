using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BraveWorld.Forms.Extensions
{
    public static class AppearanceExtensions
    {

        public static Color GetBlendedColor(int percentage)
        {
            if (percentage < 50)
                return Interpolate(Color.Red, Color.Yellow, percentage / 50.0);
            return Interpolate(Color.Yellow, Color.Lime, (percentage - 50) / 50.0);
        }

        public static Color Interpolate(Color color1, Color color2, double fraction)
        {
            double r = Interpolate(color1.R, color2.R, fraction) * 255;
            double g = Interpolate(color1.G, color2.G, fraction) * 255;
            double b = Interpolate(color1.B, color2.B, fraction) * 255;
            return Color.FromRgb((int)Math.Round(r), (int)Math.Round(g), (int)Math.Round(b));
        }

        public static double Interpolate(double d1, double d2, double fraction)
            => d1 + (d2 - d1) * fraction;


        public static Color WithAlpha(this Color color, double alpha)
            => Color.FromRgba(color.R, color.G, color.B, alpha);


        public static bool IsDarkColor(this Color color) => color.Luminosity <= 0.5;
        public static bool IsLightColor(this Color color) => !color.IsDarkColor();
    }
}
