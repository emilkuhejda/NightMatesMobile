using NightMates.Domain.Interfaces.Required;
using NightMates.Logging.Interfaces;
using NightMates.Mobile.Configuration;
using NightMates.Mobile.Droid.Localization;
using NightMates.Mobile.Droid.Logging;
using Prism.Ioc;

namespace NightMates.Mobile.Droid.Configuration
{
    public class AndroidBootstrapper : Bootstrapper
    {
        protected override void RegisterPlatformServices(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<ILocalizer, Localizer>();
            containerRegistry.RegisterSingleton<ILoggerConfiguration, NLogLoggerConfiguration>();
            containerRegistry.RegisterSingleton<ILogFileReader, NLogFileReader>();
            containerRegistry.RegisterSingleton<ILoggerFactory, NLogLoggerFactory>();
        }
    }
}