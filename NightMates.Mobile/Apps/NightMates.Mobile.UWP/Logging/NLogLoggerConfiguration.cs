using System.IO;
using NightMates.Logging.Interfaces;
using NightMates.Logging.Layouts;
using NLog;
using NLog.Config;

namespace NightMates.Mobile.UWP.Logging
{
    public class NLogLoggerConfiguration : ILoggerConfiguration
    {
        private string _fileName;

        public void Initialize(string logFileName)
        {
            _fileName = logFileName;

            var config = new LoggingConfiguration();
            var layout = NLogLayouts.GetDefaultLayout();

            // Debug Target
            var debugTarget = NLogTargets.GetDebugTarget(layout);
            config.AddTarget("debug", debugTarget);

            var debugRule = new LoggingRule("*", LogLevel.Trace, debugTarget);
            config.LoggingRules.Add(debugRule);

            // File Target
            var logFilePath = GetLogFileInfo().FullName;
            var fileTarget = NLogTargets.GetFileTarget(layout, logFilePath);
            config.AddTarget("file", fileTarget);

            var fileRule = new LoggingRule("*", LogLevel.Trace, fileTarget);
            config.LoggingRules.Add(fileRule);

            LogManager.Configuration = config;
        }

        public FileInfo GetLogFileInfo()
        {
            var folder = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
            if (!Directory.Exists(folder))
            {
                folder = Directory.CreateDirectory(folder).FullName;
            }
            var filePath = Path.Combine(folder, _fileName);
            return new FileInfo(filePath);
        }
    }
}