using NightMates.Domain.Interfaces.Required;
using NightMates.Mobile.Configuration;
using NightMates.Mobile.UWP.Localization;
using Prism.Ioc;

namespace NightMates.Mobile.UWP.Configuration
{
    public class UwpBootstrapper : Bootstrapper
    {
        protected override void RegisterPlatformServices(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<ILocalizer, Localizer>();
        }
    }
}
