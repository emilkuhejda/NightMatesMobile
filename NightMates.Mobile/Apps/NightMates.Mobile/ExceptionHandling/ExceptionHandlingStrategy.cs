using System;
using System.Threading.Tasks;
using NightMates.Common.Utils;
using NightMates.Domain.Interfaces.ExceptionHandling;
using NightMates.Domain.Interfaces.Services;
using NightMates.Logging.Extensions;
using NightMates.Logging.Interfaces;
using NightMates.Resources.Localization;

namespace NightMates.Mobile.ExceptionHandling
{
    public class ExceptionHandlingStrategy : IExceptionHandlingStrategy
    {
        private readonly IAppCenterMetricsService _appCenterMetricsService;
        private readonly IDialogService _dialogService;
        private readonly ILogger _logger;

        public ExceptionHandlingStrategy(
            IAppCenterMetricsService appCenterMetricsService,
            IDialogService dialogService,
            ILoggerFactory loggerFactory)
        {
            _appCenterMetricsService = appCenterMetricsService;
            _dialogService = dialogService;
            _logger = loggerFactory.CreateLogger(typeof(ExceptionHandlingStrategy));
        }

        public async Task<bool> HandleException(Exception exception)
        {
            _logger.Error(ExceptionFormatter.FormatException(exception));
            _appCenterMetricsService.TrackException(exception);

            try
            {
                await _dialogService.AlertAsync(
                    Loc.Text(TranslationKeys.UnhandledExceptionAlertMessage),
                    Loc.Text(TranslationKeys.UnhandledExceptionAlertTitle),
                    Loc.Text(TranslationKeys.UnhandledExceptionAlertOkButtonText))
                    .ConfigureAwait(false);
            }
            catch (Exception)
            {
                // It's already too late to show a message to the user. Just crash.
            }

            return false;
        }
    }
}
