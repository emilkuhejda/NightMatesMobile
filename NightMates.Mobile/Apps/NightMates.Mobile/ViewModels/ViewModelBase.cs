using NightMates.Common.Utils;
using NightMates.Logging.Interfaces;
using Prism.Mvvm;

namespace NightMates.Mobile.ViewModels
{
    public abstract class ViewModelBase : BindableBase
    {
        protected ViewModelBase(ILoggerFactory loggerFactory)
        {
            Logger = loggerFactory.CreateLogger(GetType());
            OperationScope = new AsyncOperationScope();
        }

        protected ILogger Logger { get; }

        public AsyncOperationScope OperationScope { get; }
    }
}
