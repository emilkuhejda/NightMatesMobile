using System;

namespace NightMates.Logging.Interfaces
{
    public interface ILoggerFactory
    {
        ILogger CreateLogger(Type dependantType);
    }
}
