using System;
using System.Collections;
using System.Collections.Generic;
using Xamarin.Forms;

namespace BraveWorld.Forms.Views
{
    public struct WhatsNewInfo
    {
        public string Title { get; }
        public string Version { get; }
        public IEnumerable<string> Changes { get; }
        public string? Header { get; }
        public string? Icon { get; }
        public ImageSource? BannerSource { get; }

        public WhatsNewInfo(string title, string version, IEnumerable<string> changes, string? header = null, string? icon = null, ImageSource? bannerSource = null)
        {
            Title = title;
            Version = version;
            Changes = changes;
            Header = header;
            Icon = icon;
            BannerSource = bannerSource;
        }
    }
}
