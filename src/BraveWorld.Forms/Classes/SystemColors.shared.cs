using System;
using System.Collections.Generic;
using Xamarin.Forms;
using BraveWorld.Forms.Classes;

namespace BraveWorld.Forms
{
    public static class SystemColors
    {
        public static SystemColor Red => new SystemColor(nameof(Red), Color.FromRgb(255, 59, 48), Color.FromRgb(255, 69, 58));
        public static SystemColor Orange => new SystemColor(nameof(Orange), Color.FromRgb(255, 149, 0), Color.FromRgb(255, 159, 10));
        public static SystemColor Yellow => new SystemColor(nameof(Yellow), Color.FromRgb(255, 204, 0), Color.FromRgb(255, 214, 10));
        public static SystemColor Green => new SystemColor(nameof(Green), Color.FromRgb(52, 199, 89), Color.FromRgb(48, 209, 88));
        public static SystemColor Teal => new SystemColor(nameof(Teal), Color.FromRgb(90, 200, 250), Color.FromRgb(100, 210, 255));
        public static SystemColor Blue => new SystemColor(nameof(Blue), Color.FromRgb(0, 122, 255), Color.FromRgb(10, 132, 255));
        public static SystemColor Indigo => new SystemColor(nameof(Indigo), Color.FromRgb(88, 86, 214), Color.FromRgb(94, 92, 230));
        public static SystemColor Purple => new SystemColor(nameof(Purple), Color.FromRgb(175, 82, 222), Color.FromRgb(191, 90, 242));
        public static SystemColor Pink => new SystemColor(nameof(Pink), Color.FromRgb(255, 45, 85), Color.FromRgb(255, 55, 95));

        public static SystemColor Gray => new SystemColor(nameof(Gray), Color.FromRgb(142, 142, 147), Color.FromRgb(152, 152, 157));
        public static SystemColor Gray2 => new SystemColor(nameof(Gray2), Color.FromRgb(174, 174, 178), Color.FromRgb(99, 99, 102));
        public static SystemColor Gray3 => new SystemColor(nameof(Gray3), Color.FromRgb(199, 199, 204), Color.FromRgb(72, 72, 74));
        public static SystemColor Gray4 => new SystemColor(nameof(Gray4), Color.FromRgb(209, 209, 214), Color.FromRgb(58, 58, 60));
        public static SystemColor Gray5 => new SystemColor(nameof(Gray5), Color.FromRgb(229, 229, 234), Color.FromRgb(44, 44, 46));
        public static SystemColor Gray6 => new SystemColor(nameof(Gray6), Color.FromRgb(242, 242, 247), Color.FromRgb(28, 28, 30));

        public static SystemColor CardsBackground => new SystemColor(nameof(CardsBackground), Color.White, Gray6.DarkColor);
        public static SystemColor GroupedBackground => new SystemColor(nameof(GroupedBackground), Gray6.LightColor, Color.Black);



        public static void SetAppThemeColor(this BindableObject bindableObject, BindableProperty property, SystemColor systemColor)
        {
            bindableObject.SetAppThemeColor(property, systemColor.LightColor, systemColor.DarkColor);
        }


        public static IEnumerable<SystemColor> AsNumerable() => new[]
        {
            Red,
            Orange,
            Yellow,
            Green,
            Teal,
            Blue,
            Indigo,
            Purple,
            Pink,
            Gray,
            Gray2,
            Gray3,
            Gray4,
            Gray5,
            Gray6,
            CardsBackground,
            GroupedBackground
        };
    }
}
