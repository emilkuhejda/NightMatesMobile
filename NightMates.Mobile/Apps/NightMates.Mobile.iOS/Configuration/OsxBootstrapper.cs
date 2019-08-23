using NightMates.Domain.Interfaces.ExceptionHandling;
using NightMates.Domain.Interfaces.Required;
using NightMates.Logging.Interfaces;
using NightMates.Mobile.Configuration;
using NightMates.Mobile.iOS.ExceptionHandling;
using NightMates.Mobile.iOS.Localization;
using NightMates.Mobile.iOS.Logging;
using Prism.Ioc;

namespace NightMates.Mobile.iOS.Configuration
{
    public class OsxBootstrapper : Bootstrapper
    {
        protected override void RegisterPlatformServices(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<ILocalizer, Localizer>();
            containerRegistry.RegisterSingleton<ILoggerConfiguration, NLogLoggerConfiguration>();
            containerRegistry.RegisterSingleton<ILogFileReader, NLogFileReader>();
            containerRegistry.RegisterSingleton<ILoggerFactory, NLogLoggerFactory>();
            containerRegistry.RegisterSingleton<IExceptionHandler, ExceptionHandler>();
        }
    }
}