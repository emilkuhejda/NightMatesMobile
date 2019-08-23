using System.IO;
using System.Threading.Tasks;

namespace NightMates.Logging.Interfaces
{
    public interface ILogFileReader
    {
        Task<string> ReadLogFileAsync();

        Task ClearLogFileAsync();

        FileInfo GetLogFileInfo();
    }
}
