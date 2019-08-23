using System;
using System.Globalization;
using System.Threading;
using NightMates.Domain.Events;
using NightMates.Domain.Interfaces.Required;

namespace NightMates.Mobile.iOS.Localization
{
    public class Localizer : ILocalizer
    {
        public event EventHandler<CultureInfoChangedEventArgs> CultureInfoChanged;

        public CultureInfo GetCurrentCulture()
        {
            return Thread.CurrentThread.CurrentCulture;
        }

        public void SetCultureInfo(CultureInfo cultureInfo)
        {
            if (cultureInfo == null)
                throw new ArgumentNullException(nameof(cultureInfo));

            if (!Equals(Thread.CurrentThread.CurrentCulture, cultureInfo) || !Equals(Thread.CurrentThread.CurrentUICulture, cultureInfo))
            {
                Thread.CurrentThread.CurrentCulture = cultureInfo;
                Thread.CurrentThread.CurrentUICulture = cultureInfo;

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