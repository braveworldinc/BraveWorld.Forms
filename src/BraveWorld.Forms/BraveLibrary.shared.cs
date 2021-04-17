using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace BraveWorld.Forms
{
    /// <summary>
    ///     A static class to initialize BraveWorld,Forms Library
    /// </summary>
    public static class BraveLibrary
    {
        public static Version Version => Assembly.GetExecutingAssembly().GetName().Version;

        /// <summary>
        ///     Initializes the BraveWorld.Forms Library, enables custom namespace http://braveworldinc.com/forms to be used in XAML.
        ///     <remarks>This should be called once per application, typically in the `App.xaml.cs` constructor. </remarks>
        /// </summary>
        [ExcludeFromCodeCoverage]
        public static void Init()
        { }


        internal static Exception NotImplementedInReferenceAssembly() =>
            new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");


        public static class PreviewFeatures
        {
            /// <summary>
            ///     Enables Apple SFSymbols <see cref="Views.SymbolImageSource" />
            /// </summary>
            public static bool SymbolImageSource { get; private set; }


            public static void EnableFeature(string previewFeature)
            {
                switch (previewFeature)
                {
                    case nameof(SymbolImageSource):
                        SymbolImageSource = true;
                        break;
                }
            }
        }
    }
}
