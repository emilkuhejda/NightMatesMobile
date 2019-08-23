using System;
using NightMates.Domain.Interfaces.Required;

namespace NightMates.Mobile.Droid.Providers
{
    public class DirectoryProvider : IDirectoryProvider
    {
        public string GetPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        }
    }
}