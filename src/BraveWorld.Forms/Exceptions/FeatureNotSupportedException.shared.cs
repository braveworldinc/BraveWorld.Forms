using System;
using Xamarin.Forms;

namespace BraveWorld.Forms.Exceptions
{
    public class FeatureNotSupportedException : Exception
    {
        public FeatureNotSupportedException(string? platform = null) : base(CreateErrorMessage(platform))
        { }

        static string CreateErrorMessage(string? platform = null) => $"Current platform ({platform ?? Device.RuntimePlatform}) does not support this feature.";
    }
}
