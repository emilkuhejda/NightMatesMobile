using System;
using NightMates.Common.Utils;
using NightMates.Domain.Interfaces.ExceptionHandling;
using NightMates.Domain.Interfaces.Services;
using NightMates.Logging.Extensions;
using NightMates.Logging.Interfaces;

namespace NightMates.Mobile.ExceptionHandling
{
    public class ExceptionHandlingStrategy : IExceptionHandlingStrategy
    {
        private readonly IAppCenterMetricsService _appCenterMetricsService;
        private readonly ILogger _logger;

        public ExceptionHandlingStrategy(
            IAppCenterMetricsService appCenterMetricsService,
            ILoggerFactory loggerFactory)
        {
            _appCenterMetricsService = appCenterMetricsService;
            _logger = loggerFactory.CreateLogger(typeof(ExceptionHandlingStrategy));
        }

        public bool HandleException(Exception exception)
        {
            _logger.Error(ExceptionFormatter.FormatException(exception));
            _appCenterMetricsService.TrackException(exception);

            return false;
        }
    }
}
