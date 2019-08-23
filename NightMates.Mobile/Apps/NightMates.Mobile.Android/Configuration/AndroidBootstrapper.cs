using NightMates.Domain.Interfaces.Required;
using NightMates.Mobile.Configuration;
using NightMates.Mobile.Droid.Localization;
using Prism.Ioc;

namespace NightMates.Mobile.Droid.Configuration
{
    public class AndroidBootstrapper : Bootstrapper
    {
        protected override void RegisterPlatformServices(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<ILocalizer, Localizer>();
        }
    }
}