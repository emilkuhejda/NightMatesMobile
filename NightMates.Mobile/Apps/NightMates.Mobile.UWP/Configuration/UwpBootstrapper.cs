﻿using NightMates.Domain.Interfaces.ExceptionHandling;
using NightMates.Domain.Interfaces.Required;
using NightMates.Logging.Interfaces;
using NightMates.Mobile.Configuration;
using NightMates.Mobile.UWP.ExceptionHandling;
using NightMates.Mobile.UWP.Localization;
using NightMates.Mobile.UWP.Logging;
using NightMates.Mobile.UWP.Providers;
using Prism.Ioc;

namespace NightMates.Mobile.UWP.Configuration
{
    public class UwpBootstrapper : Bootstrapper
    {
        protected override void RegisterPlatformServices(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<ILocalizer, Localizer>();
            containerRegistry.RegisterSingleton<IDirectoryProvider, DirectoryProvider>();
            containerRegistry.RegisterSingleton<ILoggerConfiguration, NLogLoggerConfiguration>();
            containerRegistry.RegisterSingleton<ILogFileReader, NLogFileReader>();
            containerRegistry.RegisterSingleton<ILoggerFactory, NLogLoggerFactory>();
            containerRegistry.RegisterSingleton<IExceptionHandler, ExceptionHandler>();
        }
    }
}
