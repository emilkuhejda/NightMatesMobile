using NightMates.Mobile.UWP.Configuration;
using Application = NightMates.Mobile.App;

namespace NightMates.Mobile.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            var bootstrapper = new UwpBootstrapper();
            LoadApplication(new Application(bootstrapper));
        }
    }
}
