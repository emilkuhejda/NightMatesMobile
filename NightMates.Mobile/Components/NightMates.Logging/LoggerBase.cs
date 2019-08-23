using System;
using System.Diagnostics;
using NightMates.Logging.Enums;
using NightMates.Logging.Interfaces;

namespace NightMates.Logging
{
    public abstract class LoggerBase : ILogger
    {
        public abstract string Name { get; }

        protected abstract void WriteCore(LogEntry entry);

        public abstract bool IsCategoryEnabled(Category category);

        [DebuggerStepThrough]
        public void Write(Category category, string message)
        {
            if (IsCategoryEnabled(category))
            {
                var entry = new LogEntry(category, message);
                WriteCore(entry);
            }
        }

        [DebuggerStepThrough]
        public void Write(Category category, Exception exception, string message)
        {
            if (IsCategoryEnabled(category))
            {
                var entry = new LogEntry(category, exception, message);
                WriteCore(entry);
            }
        }

        [DebuggerStepThrough]
        public void Write(LogEntry entry)
        {
            if (IsCategoryEnabled(entry.Category))
            {
                WriteCore(entry);
            }
        }
    }
}
