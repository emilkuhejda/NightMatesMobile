using NightMates.Common;
using NightMates.DataAccess.Providers;
using NightMates.DataAccess.Repositories;
using NightMates.Domain.Interfaces.Repositories;
using Prism.Ioc;

namespace NightMates.DataAccess
{
    public class DataAccessMobule : IUnityModule
    {
        public void RegisterServices(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppDbContext, AppDbContext>();
            containerRegistry.RegisterSingleton<IAppDbContextProvider, AppDbContextProvider>();
            containerRegistry.RegisterSingleton<IStorageInitializer, StorageInitializer>();
            containerRegistry.RegisterSingleton<IInternalValueRepository, InternalValueRepository>();
        }
    }
}
