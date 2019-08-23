using System;
using System.Globalization;
using NightMates.Domain.Events;

namespace NightMates.Domain.Interfaces.Required
{
    public interface ILocalizer
    {
        event EventHandler<CultureInfoChangedEventArgs> CultureInfoChanged;

        CultureInfo GetCurrentCulture();

        void SetCultureInfo(CultureInfo cultureInfo);
    }
}
