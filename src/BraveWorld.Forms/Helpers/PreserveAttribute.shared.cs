using System;
using System.ComponentModel;

namespace BraveWorld.Forms.Helpers
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	[AttributeUsage(AttributeTargets.Assembly)]
	public sealed class PreserveAttribute : Attribute
    {

    }
}
