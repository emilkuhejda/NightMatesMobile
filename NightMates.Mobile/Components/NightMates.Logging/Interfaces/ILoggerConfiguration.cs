using System.IO;

namespace NightMates.Logging.Interfaces
{
    public interface ILoggerConfiguration
    {
        void Initialize(string logFileName);

        FileInfo GetLogFileInfo();
    }
}
