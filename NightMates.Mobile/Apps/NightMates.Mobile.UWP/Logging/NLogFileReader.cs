using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using NightMates.Logging.Interfaces;

namespace NightMates.Mobile.UWP.Logging
{
    public class NLogFileReader : ILogFileReader
    {
        private readonly ILoggerConfiguration _loggerConfiguration;

        public NLogFileReader(ILoggerConfiguration loggerConfiguration)
        {
            _loggerConfiguration = loggerConfiguration;
        }

        public async Task<string> ReadLogFileAsync()
        {
            var logFile = GetLogFileInfo();
            if (!logFile.Exists)
            {
                throw new FileNotFoundException(logFile.FullName);
            }

            var storageFolder = ApplicationData.Current.LocalFolder;
            var storageFile = await storageFolder.GetFileAsync(logFile.Name);
            var content = await FileIO.ReadTextAsync(storageFile);
            return content;
        }

        public async Task ClearLogFileAsync()
        {
            var logFile = GetLogFileInfo();
            if (!logFile.Exists)
            {
                throw new FileNotFoundException(logFile.FullName);
            }

            var storageFolder = ApplicationData.Current.LocalFolder;
            var storageFile = await storageFolder.GetFileAsync(logFile.Name);
            await FileIO.WriteTextAsync(storageFile, string.Empty);
        }

        public FileInfo GetLogFileInfo()
        {
            return _loggerConfiguration.GetLogFileInfo();
        }
    }
}