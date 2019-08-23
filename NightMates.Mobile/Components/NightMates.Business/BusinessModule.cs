using NightMates.Business.Services;
using NightMates.Common;
using NightMates.Domain.Interfaces.Services;
using Prism.Ioc;

namespace NightMates.Business
{
    public class BusinessModule : IUnityModule
    {
        public void RegisterServices(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IInternalValueService, InternalValueService>();
        }
    }
}
