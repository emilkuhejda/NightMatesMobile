using Prism.Ioc;

namespace NightMates.Common
{
    public interface IUnityModule
    {
        void RegisterServices(IContainerRegistry containerRegistry);
    }
}
