using System;
using System.Collections;
using System.Collections.Generic;

namespace BraveWorld.Forms.Views
{
    public struct WhatsNewInfo
    {
        public string Title { get; }
        public string Version { get; }
        public IEnumerable<string> Changes { get; }
        public string? Icon { get; }

        public WhatsNewInfo(string title, string version, IEnumerable<string> changes, string? icon)
        {
            Title = title;
            Version = version;
            Changes = changes;
            Icon = icon;
        }
    }
}
