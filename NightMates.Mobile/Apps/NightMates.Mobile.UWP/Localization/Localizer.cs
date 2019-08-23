using System;
using System.Globalization;
using NightMates.Domain.Events;
using NightMates.Domain.Interfaces.Required;

namespace NightMates.Mobile.UWP.Localization
{
    public class Localizer : ILocalizer
    {
        public event EventHandler<CultureInfoChangedEventArgs> CultureInfoChanged;

        public CultureInfo GetCurrentCulture()
        {
            return CultureInfo.CurrentCulture;
        }

        public void SetCultureInfo(CultureInfo cultureInfo)
        {
            if (cultureInfo == null)
                throw new ArgumentNullException(nameof(cultureInfo));

            if (!Equals(CultureInfo.CurrentCulture, cultureInfo) || !Equals(CultureInfo.CurrentUICulture, cultureInfo))
            {
                CultureInfo.CurrentCulture = cultureInfo;
                CultureInfo.CurrentUICulture = cultureInfo;

                CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
                CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

                OnCultureInfoChanged(cultureInfo);
            }
        }

        private void OnCultureInfoChanged(CultureInfo cultureInfo)
        {
            CultureInfoChanged?.Invoke(this, new CultureInfoChangedEventArgs(cultureInfo));
        }
    }
}
