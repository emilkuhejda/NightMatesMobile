using Windows.Storage;
using NightMates.Domain.Interfaces.Required;

namespace NightMates.Mobile.UWP.Providers
{
    public class DirectoryProvider : IDirectoryProvider
    {
        public string GetPath()
        {
            return ApplicationData.Current.LocalFolder.Path;
        }
    }
}
