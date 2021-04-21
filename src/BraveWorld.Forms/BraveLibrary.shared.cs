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
        static Assembly AssemblyCache;

        public static string Name => "BraveWorld.Forms";
        public static Version Version => Assembly.GetExecutingAssembly().GetName().Version;

        /// <summary>
        ///     Initializes the BraveWorld.Forms Library, enables custom namespace http://braveworldinc.com/forms to be used in XAML.
        ///     <remarks>This should be called once per application, typically in the `App.xaml.cs` constructor. </remarks>
        /// </summary>
        [ExcludeFromCodeCoverage]
        public static void Init()
        {
#if XAMARIN_IOS
            Xamarin.Forms.Internals.Registrar.Registered.Register(typeof(Views.SymbolImageSource), typeof(Views.SymbolImageSourceHandler));
#endif
        }

        /// <summary>
        /// Registers the assembly.
        /// </summary>
        /// <param name="typeHavingResource">Type having resource.</param>
        public static void RegisterAssembly(Type typeHavingResource = null)
        {
            if (typeHavingResource == null)
            {
#if NETSTANDARD2_0
                AssemblyCache = Assembly.GetCallingAssembly();
#else
                MethodInfo callingAssemblyMethod = typeof(Assembly).GetTypeInfo().GetDeclaredMethod("GetCallingAssembly");
                if (callingAssemblyMethod != null)
                {
                    AssemblyCache = (Assembly)callingAssemblyMethod.Invoke(null, new object[0]);
                }
#endif
            }
            else
            {
                AssemblyCache = typeHavingResource.GetTypeInfo().Assembly;
            }
        }


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

            public static void EnableFeatures(string[] previewFeatures)
            {
                for (int i = 0; i < previewFeatures.Length; i++)
                    EnableFeature(previewFeatures[i]);
            }
        }
    }
}
