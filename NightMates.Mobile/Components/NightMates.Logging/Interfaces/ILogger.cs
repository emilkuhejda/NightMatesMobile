using System;
using NightMates.Logging.Enums;

namespace NightMates.Logging.Interfaces
{
    public interface ILogger
    {
        string Name { get; }

        void Write(Category category, string message);

        void Write(Category category, Exception exception, string message);
    }
}
