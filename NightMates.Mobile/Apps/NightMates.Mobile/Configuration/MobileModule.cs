using NightMates.Common;
using NightMates.Mobile.Navigation;
using NightMates.Mobile.ViewModels;
using NightMates.Mobile.Views;
using Prism.Ioc;

namespace NightMates.Mobile.Configuration
{
    public class MobileModule : IUnityModule
    {
        public void RegisterServices(IContainerRegistry containerRegistry)
        {
            RegisterPages(containerRegistry);
        }

        private static void RegisterPages(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>(Pages.Main);
        }
    }
}
