using NightMates.Business;
using NightMates.DataAccess;
using NightMates.Logging;
using Prism;
using Prism.Ioc;

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
        }
    }
}
