using System;

namespace BraveWorld.Forms.Exceptions
{
    public class PreviewFeatureNotEnabledException : Exception
    {
        public PreviewFeatureNotEnabledException(string type) : base(CreateErrorMessage(type))
        { }

        public PreviewFeatureNotEnabledException(Type type) : base(CreateErrorMessage(type))
        { }


        static string CreateErrorMessage(string type) => $"Enable {type} by using BraveWorld.Forms.BraveLibrary.PreviewFeatures.EnableFeature(\"{type}\");";
        static string CreateErrorMessage(Type type) => CreateErrorMessage(nameof(type));
    }
}
