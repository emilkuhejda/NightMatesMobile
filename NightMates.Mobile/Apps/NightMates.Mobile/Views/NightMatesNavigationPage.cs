using System;
using Xamarin.Forms;

namespace NightMates.Mobile.Views
{
    public class NightMatesNavigationPage : NavigationPage
    {
        public NightMatesNavigationPage()
        {
            Popped += HandlePopped;
        }

        private void HandlePopped(object sender, NavigationEventArgs e)
        {
            var disposable = e.Page.BindingContext as IDisposable;
            disposable?.Dispose();
        }
    }
}
