using System;
using System.IO;
using System.Reflection;
using Piranha.Extend;
using Piranha;
using Innologix.Layouts.Blocks;

namespace Innologix.Layout.Modules
{
    public sealed class Module : IModule
    {
        /// <summary>
        /// Gets the Author
        /// </summary>
        public string Author => "Innologix";

        /// <summary>
        /// Gets the Name
        /// </summary>
        public string Name => "Innologix.Layouts";

        /// <summary>
        /// Gets the Version
        /// </summary>
        public string Version => Piranha.Utils.GetAssemblyVersion(this.GetType().Assembly);

        /// <summary>
        /// Gets the description
        /// </summary>
        public string Description => "More Blocks for Piranha CMS";

        /// <summary>
        /// Gets the package url.
        /// </summary>
        public string PackageUrl => "https://www.nuget.org/packages/Piranha.Manager";

        /// <summary>
        /// Gets the icon url.
        /// </summary>
        public string IconUrl => "http://piranhacms.org/assets/twitter-shield.png";

        /// <summary>
        /// The assembly.
        /// </summary>
        internal static readonly Assembly Assembly;

        /// <summary>
        /// Last modification date of the assembly.
        /// </summary>
        internal static readonly DateTime LastModified;

        /// <summary>
        /// Static initialization.
        /// </summary>
        static Module()
        {
            // Get assembly information
            Assembly = typeof(Module).GetTypeInfo().Assembly;
            LastModified = new FileInfo(Assembly.Location).LastWriteTime;
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Module()
        {
        }

        /// <summary>
        /// Initializes the module.
        /// </summary>
        public void Init()
        {
            App.Blocks.Register<TabsContentBlock>();
            App.Blocks.Register<CollapsibleContentBlock>();
            App.Blocks.Register<BlockGroupItem>();
            App.Blocks.Register<ImageAndTextBlock>();
            App.Blocks.Register<TwoColumnImageAndTextBlock>();
            App.Blocks.Register<TwoColumnVImageAndTextBlock>();
            App.Blocks.Register<ThreeColumnVImageAndTextBlock>();
            App.Blocks.Register<FourColumnVImageAndTextBlock>();
            App.Blocks.Register<TwoColumnThreeImagesBlock>();
            App.Blocks.Register<ImageLinkBlock>();

        }
    }
}
