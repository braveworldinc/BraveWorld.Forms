using System;
using System.Diagnostics.CodeAnalysis;

namespace BraveWorld.Forms
{
    /// <summary>
    ///     A static class to initialize BraveWorld.Forms Library
    /// </summary>
    public static class Library
    {
        public const string Name = "BraveWorld.Forms";


        /// <summary>
        ///     Initializes the BraveWorld.Forms Library, enables custom namespace http://braveworld.forms.com to be used in XAML.
        ///     <remarks>This should be called once per application, typically in the `App.xaml.cs` constructor. </remarks>
        /// </summary>
        [ExcludeFromCodeCoverage]
        public static void Initialize()
        {
        }

        /// <summary>
        ///     A static class used to enable features that are in preview.
        /// </summary>
        public static class PreviewFeatures
        {
            /// <summary>
            ///     Toggles animations for the badge on the <see cref="MenuButton" />
            /// </summary>
            //public static bool MenuButtonAnimations { get; private set; }

            /// <summary>
            ///     Toggles usage of SkeletonView <see cref="SkeletonView" />
            /// </summary>
            //public static bool SkeletonView { get; private set; }

            public static bool TestPreviewFeature { get; private set; }

            /// <summary>
            ///     Enable a feature that's in preview.
            /// </summary>
            /// <param name="previewFeature">A string specifying which preview feature you want to enable.</param>
            public static void EnableFeature(string previewFeature)
            {
                //if (previewFeature == nameof(MenuButtonAnimations))
                //    MenuButtonAnimations = true;

                //if (previewFeature == nameof(SkeletonView))
                //    SkeletonView = true;

                if (previewFeature == nameof(TestPreviewFeature))
                    TestPreviewFeature = true;
            }
        }
    }
}
