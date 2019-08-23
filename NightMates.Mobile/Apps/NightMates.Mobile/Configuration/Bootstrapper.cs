using NightMates.Business;
using NightMates.DataAccess;
using NightMates.Domain.Interfaces.ExceptionHandling;
using NightMates.Domain.Interfaces.Required;
using NightMates.Logging;
using NightMates.Mobile.Localization;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using Unity;

namespace NightMates.Mobile.Configuration
{
    public abstract class Bootstrapper : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            var mobileModule = new MobileModule();
            mobileModule.RegisterServices(containerRegistry);

            var businessModule = new BusinessModule();
            businessModule.RegisterServices(containerRegistry);

            var dataAccessMobule = new DataAccessMobule();
            dataAccessMobule.RegisterServices(containerRegistry);

            var loggingModule = new LoggingModule();
            loggingModule.RegisterServices(containerRegistry);

            RegisterPlatformServices(containerRegistry);
            InitializeServices(containerRegistry);
        }

        protected abstract void RegisterPlatformServices(IContainerRegistry containerRegistry);

        private void InitializeServices(IContainerRegistry containerRegistry)
        {
            LocalizationExtension.Init(() => containerRegistry.GetContainer().Resolve<ILocalizer>());

            containerRegistry.GetContainer().Resolve<IExceptionHandler>().RegisterForExceptions();
        }
    }
}
