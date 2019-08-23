using NightMates.Domain.Interfaces.Services;
using NightMates.Logging.Interfaces;
using Prism.Navigation;

namespace NightMates.Mobile.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(
            IDialogService dialogService,
            INavigationService navigationService,
            ILoggerFactory loggerFactory)
            : base(dialogService, navigationService, loggerFactory)
        {
        }
    }
}
