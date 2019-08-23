using System;
using System.Globalization;

namespace NightMates.Domain.Events
{
    public class CultureInfoChangedEventArgs : EventArgs
    {
        public CultureInfoChangedEventArgs(CultureInfo cultureInfo)
        {
            CultureInfo = cultureInfo;
        }

        public CultureInfo CultureInfo { get; }
    }
}
