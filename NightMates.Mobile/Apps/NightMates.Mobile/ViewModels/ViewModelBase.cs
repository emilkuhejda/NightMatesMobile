using NightMates.Common.Utils;
using NightMates.Domain.Interfaces.Services;
using NightMates.Logging.Interfaces;
using Prism.Mvvm;
using Prism.Navigation;

namespace NightMates.Mobile.ViewModels
{
    public abstract class ViewModelBase : BindableBase
    {
        protected ViewModelBase(
            IDialogService dialogService,
            INavigationService navigationService,
            ILoggerFactory loggerFactory)
        {
            DialogService = dialogService;
            NavigationService = navigationService;
            Logger = loggerFactory.CreateLogger(GetType());
            OperationScope = new AsyncOperationScope();
        }

        protected IDialogService DialogService { get; }

        protected INavigationService NavigationService { get; }

        protected ILogger Logger { get; }

        public AsyncOperationScope OperationScope { get; }
    }
}
