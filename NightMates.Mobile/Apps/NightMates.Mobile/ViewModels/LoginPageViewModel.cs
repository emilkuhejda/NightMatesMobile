using System.Threading.Tasks;
using NightMates.Common.Utils;
using NightMates.Domain.Interfaces.Services;
using NightMates.Logging.Interfaces;
using NightMates.Mobile.Extensions;
using NightMates.Mobile.Navigation;
using Prism.Navigation;

namespace NightMates.Mobile.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        public LoginPageViewModel(
            IDialogService dialogService,
            INavigationService navigationService,
            ILoggerFactory loggerFactory)
            : base(dialogService, navigationService, loggerFactory)
        {
        }

        protected override async Task LoadDataAsync(INavigationParameters navigationParameters)
        {
            using (new OperationMonitor(OperationScope))
            {
                await NavigationService.NavigateWithoutAnimationAsync($"/{Pages.Navigation}/{Pages.Main}").ConfigureAwait(false);
            }
        }
    }
}
