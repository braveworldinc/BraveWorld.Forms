using Xamarin.Forms;
using BraveWorld.Forms.Extensions;

namespace BraveWorld.Forms.Classes
{
    public struct SystemColor
    {
        public string Name { get; }
        public Color LightColor { get; }
        public Color DarkColor { get; }

        public string LightColorHex => LightColor.ToHexString();
        public string DarkColorHex => DarkColor.ToHexString();

        public SystemColor(string name, Color light, Color dark)
        {
            Name = name;
            LightColor = light;
            DarkColor = dark;
        }


        public Color Get(OSAppTheme appTheme = OSAppTheme.Light)
        {
            return (appTheme == OSAppTheme.Dark) ? DarkColor : LightColor;
        }
    }
}
