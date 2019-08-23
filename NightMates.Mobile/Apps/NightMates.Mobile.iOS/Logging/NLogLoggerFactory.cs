using System;
using NightMates.Logging;
using NightMates.Logging.Interfaces;

namespace NightMates.Mobile.iOS.Logging
{
    public class NLogLoggerFactory : ILoggerFactory
    {
        private const string LogFileName = "NightMates.log";

        public NLogLoggerFactory(ILoggerConfiguration loggerConfiguration)
        {
            if (loggerConfiguration == null)
            {
                throw new ArgumentNullException(nameof(loggerConfiguration));
            }

            loggerConfiguration.Initialize(LogFileName);
        }

        public ILogger CreateLogger(Type dependantType)
        {
            if (dependantType == null)
            {
                throw new ArgumentNullException(nameof(dependantType));
            }

            return new NLogLogger(dependantType.Name);
        }
    }
}