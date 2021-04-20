using System;
using System.Collections;
using System.Collections.Generic;

namespace BraveWorld.Forms.Views
{
    public struct WhatsNewInfo
    {
        public string Version { get; }
        public IEnumerable<Change> Changes { get; }

        public struct Change
        {
            public string Description { get; set; }
        }
    }

}
