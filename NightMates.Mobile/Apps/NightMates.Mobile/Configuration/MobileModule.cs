using NightMates.Common;
using NightMates.Domain.Interfaces.ExceptionHandling;
using NightMates.Domain.Interfaces.Services;
using NightMates.Mobile.ExceptionHandling;
using NightMates.Mobile.Navigation;
using NightMates.Mobile.Services;
using NightMates.Mobile.ViewModels;
using NightMates.Mobile.Views;
using Prism.Ioc;

namespace NightMates.Mobile.Configuration
{
    public class MobileModule : IUnityModule
    {
        public void RegisterServices(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IDialogService, DialogService>();
            containerRegistry.RegisterSingleton<IAppCenterMetricsService, AppCenterMetricsService>();
            containerRegistry.RegisterSingleton<IExceptionHandlingStrategy, ExceptionHandlingStrategy>();

            RegisterPages(containerRegistry);
        }

        private static void RegisterPages(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NightMatesNavigationPage>(Pages.Navigation);
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>(Pages.Login);
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>(Pages.Main);
            containerRegistry.RegisterForNavigation<SettingsPage, SettingsPageViewModel>(Pages.Settings);
        }
    }
}
