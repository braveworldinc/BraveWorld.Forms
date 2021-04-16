using System;

namespace BraveWorld.Forms
{
    public static class Library
    {
        static Lazy<IBraveWorldLibrary> implementation = new Lazy<IBraveWorldLibrary>(() => CreateBraveWorldForms(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

        /// <summary>
        /// Gets if the plugin is supported on the current platform.
        /// </summary>
        public static bool IsSupported => implementation.Value == null ? false : true;

        /// <summary>
        /// Current plugin implementation to use
        /// </summary>
        public static IBraveWorldLibrary Current
        {
            get
            {
                IBraveWorldLibrary ret = implementation.Value;
                if (ret == null)
                {
                    throw NotImplementedInReferenceAssembly();
                }
                return ret;
            }
        }

        static IBraveWorldLibrary CreateBraveWorldForms()
        {
#if MONOANDROID10_0 || XAMARIN_IOS10 || WINDOWS_UWP
#pragma warning disable IDE0022 // Use expression body for methods
            return new BraveWorldFormsImplementation();
#pragma warning restore IDE0022 // Use expression body for methods
#else
            return null;
#endif
        }

        internal static Exception NotImplementedInReferenceAssembly() =>
            new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");
    }
}
