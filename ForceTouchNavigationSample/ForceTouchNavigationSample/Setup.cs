using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Platform.Plugins;
using UIKit;

namespace ForceTouchNavigationSample
{
    public class Setup : MvxIosSetup
    {
        public Setup(IMvxApplicationDelegate applicationDelegate, UIWindow window) : base(applicationDelegate, window)
        {
        }

        public Setup(IMvxApplicationDelegate applicationDelegate, IMvxIosViewPresenter presenter) : base(applicationDelegate, presenter)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new MvxApp();
        }

		protected override void AddPluginsLoaders(MvxLoaderPluginRegistry registry)
		{
			registry.Register<MvvmCross.Plugins.File.PluginLoader, MvvmCross.Plugins.File.iOS.Plugin>();
			registry.Register<MvvmCross.Plugins.DownloadCache.PluginLoader, MvvmCross.Plugins.DownloadCache.iOS.Plugin>();
			base.AddPluginsLoaders(registry);
		}

		public override void LoadPlugins(IMvxPluginManager pluginManager)
		{
			pluginManager.EnsurePluginLoaded<MvvmCross.Plugins.File.PluginLoader>();
			pluginManager.EnsurePluginLoaded<MvvmCross.Plugins.DownloadCache.PluginLoader>();
			base.LoadPlugins(pluginManager);
		}
    }
}
