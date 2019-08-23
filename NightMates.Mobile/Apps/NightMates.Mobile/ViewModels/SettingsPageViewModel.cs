using NightMates.Domain.Interfaces.Services;
using NightMates.Logging.Interfaces;
using Prism.Navigation;

namespace NightMates.Mobile.ViewModels
{
    public class SettingsPageViewModel : ViewModelBase
    {
        public SettingsPageViewModel(
            IDialogService dialogService,
            INavigationService navigationService,
            ILoggerFactory loggerFactory)
            : base(dialogService, navigationService, loggerFactory)
        {
        }
    }
}
