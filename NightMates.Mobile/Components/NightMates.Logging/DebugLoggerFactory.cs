using System;
using NightMates.Logging.Interfaces;

namespace NightMates.Logging
{
    public class DebugLoggerFactory : ILoggerFactory
    {
        public ILogger CreateLogger(Type dependantType)
        {
            return new DebugLogger(dependantType.Name);
        }
    }
}
