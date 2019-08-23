using NightMates.Domain.Interfaces.Required;
using NightMates.Mobile.Configuration;
using NightMates.Mobile.iOS.Localization;
using Prism.Ioc;

namespace NightMates.Mobile.iOS.Configuration
{
    public class OsxBootstrapper : Bootstrapper
    {
        protected override void RegisterPlatformServices(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<ILocalizer, Localizer>();
        }
    }
}